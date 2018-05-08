using UnityEngine;
using System.Collections;

using PixelSquare.Events;

public class PeasantManager : MonoBehaviour
{
    private int m_numOfPeasants = 9;
    public Transform m_peasantSet;
    private GameObject m_prefabPeasant;
    private GameObject[] m_aPeasantObjs;
    private Peasant[] m_aPeasantScripts;

    private float[] m_aPeasantsStartTime;
    private bool m_isStartBow;
    private float m_peasantIntervals;
    public static int s_touchCounter = 0;
    public static int s_touchGoal;
    private int m_touchesToBow;

	public bool m_hasTriggerdGameEvent = false;

	public void OnEnable()
	{
//		EventBroadcaster.Instance.addObserver(EventNames.ON_GAME_CONTINUE, peasantAllBow);
		EventBroadcaster.Instance.addObserver(EventNames.ON_GAME_TIME, onGameTime);
		EventBroadcaster.Instance.addObserver(EventNames.ON_SCORE_CHANGED, onScoreChanged);
	}

	public void OnDisable()
	{
//		EventBroadcaster.Instance.removeObserver(EventNames.ON_GAME_CONTINUE, peasantAllBow);
		EventBroadcaster.Instance.removeObserver(EventNames.ON_GAME_TIME, onGameTime);
		EventBroadcaster.Instance.removeObserver(EventNames.ON_SCORE_CHANGED, onScoreChanged);
	}

	public void Update()
	{
		if(isAllStandingUp() && !m_hasTriggerdGameEvent && LevelManager.s_curLevel < 9)
		{
			EventBroadcaster.Instance.notifyObservers(EventNames.ON_GAME_FAILED);
			m_hasTriggerdGameEvent = true;
		}
	}

	public void onScoreChanged(EventParameters p_param)
	{
		int curScore = p_param.getParam(EventNames.CURRENT_SCORE, 0);
		int curGoal = p_param.getParam(EventNames.CURRENT_GOAL, 0);

		if(curScore >= curGoal && !m_hasTriggerdGameEvent)
		{
			EventBroadcaster.Instance.notifyObservers(EventNames.ON_GAME_CONTINUE);
			peasantAllBow();
			m_hasTriggerdGameEvent = true;
		}
	}

	public void onGameTime()
	{
		m_hasTriggerdGameEvent = false;
		LevelManager levelManager = GameOver.FindObjectOfType<LevelManager>();
		levelManager.LoadLevel(false);
//		peasantAllBow(true);
	}

    public void SetPeasants(bool p_isStartBow, float p_peasantIntervals, int p_totalTouchGoal, int p_touchesToBow)
    {
        s_touchCounter = 0;

        m_isStartBow = p_isStartBow;
        m_peasantIntervals = p_peasantIntervals;
        s_touchGoal = p_totalTouchGoal;
        m_touchesToBow = p_touchesToBow;

        m_aPeasantObjs = new GameObject[m_numOfPeasants];
        m_aPeasantScripts = new Peasant[m_numOfPeasants];
        m_aPeasantsStartTime = new float[m_numOfPeasants];

		EventParameters param = new EventParameters();
		param.addParam(EventNames.CURRENT_SCORE, PeasantManager.s_touchCounter);
		param.addParam(EventNames.CURRENT_GOAL, PeasantManager.s_touchGoal);
		EventBroadcaster.Instance.notifyObservers(EventNames.ON_SCORE_CHANGED, param);

        InitPeasantsStartTime(m_peasantIntervals);
        RandPeasantsStartTime();
        SetupPeasants();
    }

    void InitPeasantsStartTime(float p_intervals)
    {
        for (int i = 0; i < m_aPeasantsStartTime.Length; i++)
        {
            m_aPeasantsStartTime[i] = i * p_intervals;
        }
    }

    void RandPeasantsStartTime()
    {
        for (int i = m_aPeasantsStartTime.Length - 1; i > 0; i--)
        {
            var rand = Random.Range(0, i);
            var tmp = m_aPeasantsStartTime[i];
            m_aPeasantsStartTime[i] = m_aPeasantsStartTime[rand];
            m_aPeasantsStartTime[rand] = tmp;
        }
    }

    void SetupPeasants()
    {
        int counter = 0;
        foreach (Transform child in m_peasantSet)
        {
            m_aPeasantObjs[counter] = child.gameObject;
            counter++;
        }

        for (int i = 0; i < m_aPeasantObjs.Length; i++)
        {
            m_aPeasantScripts[i] = m_aPeasantObjs[i].GetComponent<Peasant>();
            m_aPeasantScripts[i].SetPeasant(m_isStartBow, m_aPeasantsStartTime[i], m_touchesToBow);
        }
    }

	public void peasantAllBow(bool p_untimed = false)
	{
		for(int i = 0; i < m_aPeasantScripts.Length; i++)
		{
			Peasant peasant = m_aPeasantScripts[i];
			if(!peasant.m_bIsBowing)
			{
				peasant.BowDown();
			}
			peasant.setTimeOn(p_untimed);
			peasant.ShowHail();
		}
	}

	public bool isAllStandingUp()
	{
		if(m_aPeasantScripts == null || m_aPeasantScripts.Length <= 0)
		{
			return false;
		}

		int counter = 0;

		for(int i = 0; i < m_aPeasantScripts.Length; i++)
		{
			Peasant peasant = m_aPeasantScripts[i];
			if(!peasant.m_bIsBowing)
			{
				counter++;
			}
		}

		return counter == m_aPeasantScripts.Length;
	}
}
