using UnityEngine;
using System.Collections;

using PixelSquare.Events;
using Utils.Constants;

public class Peasant : TouchInput
{
	public bool m_isDiver = false;
    private bool m_bIsInit = true;
    public LevelManager levelManager;
    public SkeletonAnimation m_anim;

    private bool m_bIsTouched = false;
	public bool m_bIsBowing = false;

    private int m_touchesToBow;
    private int m_touchCounter;

    private bool m_bTimeOn = false;
    private float m_startTime;
    private float m_goalTime = 3.0f;
    private float m_timer = 0.0f;

    public Sprite[] m_popUpSprites;
    public SpriteRenderer m_popUpCurSprites;
    private int m_popRandNum;

	[SerializeField] private FloatingText m_floatingText;

    void Start()
    {
        if (m_bIsBowing)
        {
            BowDown();
        }
        else
        {
            StandUp();
        }
    }


    public void SetPeasant(bool p_bIsBow, float p_startTime, int p_touchesToBow)
    {
		m_bIsInit = true;
        m_touchCounter = 0;
        m_timer = 0;

        m_startTime = p_startTime;
        m_bIsBowing = p_bIsBow;
        m_touchesToBow = p_touchesToBow;

        m_timer = m_startTime;

        if (m_bIsBowing)
        {
            BowDown();
        }
        else
        {
            StandUp();
        }

        m_popUpCurSprites.enabled = false;

		m_bIsInit = false;
    }

    public override void OnTouchExit()
    {
        m_bIsTouched = false;
    }

    public override void OnTouchDown()
    {
        m_bIsTouched = true;
    }

    public override void OnTouchUp()
    {
        if (m_bIsTouched)
        {
			if(m_isDiver && LevelManager.s_curLevel == 9)
			{
				Debug.Log (PeasantManager.s_touchCounter);
				if(PeasantManager.s_touchCounter < PeasantManager.s_touchGoal - 1)
				{
					m_anim.state.SetAnimation(0, "PeasantResist", false);

					return;
				}

				m_touchCounter++;
				AudioManager.Instance.playSFX(Constants.SFX_GRUNT01);
				
				if(m_touchCounter < 30)
				{
					m_anim.state.SetAnimation(0, "PeasantResist", false);
				}
				else if(m_touchCounter < 40)
				{
					m_anim.state.SetAnimation(0, "PeasantStruggle", false);
				}
				else if(m_touchCounter < 60)
				{
					m_anim.state.SetAnimation(0, "PeasantBleed", false);
					AudioManager.Instance.stopAllBGM();
					StartCoroutine(DelayedGameOver(5.0f));

				}
				
				return;
			}

			if (!m_bIsBowing)
			{
				m_touchCounter++;
				AudioManager.Instance.playSFX(Constants.SFX_GRUNT01);

				if(m_touchCounter < m_touchesToBow)
				{
					GameObject floatingTextObj2 = Instantiate(m_floatingText.gameObject) as GameObject;
					Transform floatingTextT2 = floatingTextObj2.transform;
					floatingTextT2.position = transform.position + (Vector3.up * 150.0f);
					FloatingText floatingText2 = floatingTextObj2.GetComponent<FloatingText>();
					floatingText2.setText("!");
				}
			}



            if(m_touchCounter >= m_touchesToBow)
            {
                if (!m_bIsBowing)
                {
                    PeasantManager.s_touchCounter++;

					EventParameters param = new EventParameters();
					param.addParam(EventNames.CURRENT_SCORE, PeasantManager.s_touchCounter);
					param.addParam(EventNames.CURRENT_GOAL, PeasantManager.s_touchGoal);
					EventBroadcaster.Instance.notifyObservers(EventNames.ON_SCORE_CHANGED, param);

					GameObject floatingTextObj = Instantiate(m_floatingText.gameObject) as GameObject;
					Transform floatingTextT = floatingTextObj.transform;
					floatingTextT.position = transform.position + (Vector3.up * 150.0f);
					FloatingText floatingText = floatingTextObj.GetComponent<FloatingText>();
					floatingText.setText(m_touchesToBow.ToString());

                    //m_touchCounter++;
                    StartCoroutine(ShowPopup());
                    BowDown();
                }
            }


//            if(PeasantManager.s_touchCounter >= PeasantManager.s_touchGoal)
//            {
//				EventBroadcaster.Instance.notifyObservers(EventNames.ON_GAME_CONTINUE);
//                levelManager.LoadLevel();
//            }

            m_bIsTouched = false;
        }
    }

	private IEnumerator DelayedGameOver(float p_time)
	{
		AudioManager.Instance.playSFX(Constants.SFX_BLOODSPLAT);

		yield return new WaitForSeconds(6.0f);

		AudioManager.Instance.playSFX(Constants.SFX_CROWDGASP);

		yield return new WaitForSeconds(p_time);
		levelManager.gameOver();
	}

    public override void DoUpdate()
    {
        UpdateTimer();
    }

	public void setTimeOn(bool p_timeOn)
	{
		m_bTimeOn = p_timeOn;
	}

    public void BowDown()
    {
		m_bTimeOn = true;
        m_bIsBowing = true;
        m_touchCounter = 0;

        if (m_anim.state != null)
		{
			if(!m_bIsInit)
				m_anim.state.SetAnimation(0, "PeasantOppress", false);
			else
				m_anim.state.SetAnimation(0, "PeasantBow", false);
		}
           
    }

    void StandUp()
    {
        m_bTimeOn = false;
        m_bIsBowing = false;

        if (m_anim.state != null)
		{
			if(!m_bIsInit)
				m_anim.state.SetAnimation(0, "PeasantStand", false);
			else
				m_anim.state.SetAnimation(0, "PeasantIdle", false);
		}
           
    }
    void UpdateTimer()
    {
		if(LevelManager.s_curLevel == 9)
			return;

        if (m_timer > 0 && m_bTimeOn)
            m_timer -= Time.deltaTime;

        if(m_timer <= 0)
        {
            StandUp();
            m_timer = m_goalTime;
        }
    }

    IEnumerator ShowPopup()
    {
        if(LevelManager.s_curLevel < 6)
            m_popRandNum = Random.Range(0, 3);
        else
            m_popRandNum = Random.Range(3, 6);

        m_popUpCurSprites.sprite = m_popUpSprites[m_popRandNum];
        m_popUpCurSprites.enabled = true;

        yield return new WaitForSeconds(1.0f);

        m_popUpCurSprites.enabled = false;
        
    }

	public void ShowHail()
	{
		StopAllCoroutines();
		m_popUpCurSprites.sprite = m_popUpSprites[1];
		m_popUpCurSprites.enabled = true;
		
	}
}
