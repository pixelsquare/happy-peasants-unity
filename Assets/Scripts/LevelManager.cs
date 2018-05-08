using UnityEngine;
using System.Collections;

using PixelSquare.Events;
using Utils.Constants;

public class LevelManager : MonoBehaviour
{
    public static int s_curLevel = 0;
    public PeasantManager peasantManager;

	[SerializeField] private GameObject m_worshipTime = null;

    void Awake ()
    {
        s_curLevel = 0;

        //Level10();
    }

	public void OnEnable()
	{
		EventBroadcaster.Instance.addObserver(EventNames.ON_GAME_PAN_FINISHED, onGameStart);
		EventBroadcaster.Instance.addObserver(EventNames.ON_GAME_TIME, onGameTime);
	}

	public void OnDisable()
	{
		EventBroadcaster.Instance.removeObserver(EventNames.ON_GAME_PAN_FINISHED, onGameStart);
		EventBroadcaster.Instance.removeObserver(EventNames.ON_GAME_TIME, onGameTime);
	}

	private void onGameStart()
	{
		LoadLevel(false);
	}

	private void onGameTime()
	{
		Instantiate(m_worshipTime);
	}

    public void LoadLevel(bool p_incrementLevel = true)
    {
		if(s_curLevel == 0)
		{
			Instantiate(m_worshipTime);
		}

		if(p_incrementLevel)
		{
        	s_curLevel++;
		}

//		if(s_curLevel > 1)
//		{
//			EventBroadcaster.Instance.notifyObservers(EventNames.ON_GAME_CONTINUE);
//			AudioManager.Instance.playSFX(Constants.SFX_ENDCARD02);
//		}
		
		EventParameters param = new EventParameters();
		param.addParam(EventNames.CURRENT_LEVEL, s_curLevel);
		EventBroadcaster.Instance.notifyObservers (EventNames.ON_LEVEL_CHANGED, param);

        if (s_curLevel == 0)
        {
            Level1();
        }
        else if(s_curLevel == 1)
        {
            Level2();
        }
        else if (s_curLevel == 2)
        {
            Level3();
        }
        else if (s_curLevel == 3)
        {
            Level4();
        }
		else if (s_curLevel == 4)
		{
			Level5();
		}
		else if (s_curLevel == 5)
		{
			Level6();
		}
		else if (s_curLevel == 6)
		{
			Level7();
		}
		else if (s_curLevel == 7)
		{
			Level8();
		}
		else if (s_curLevel == 8)
		{
			Level9();
		}
		else if (s_curLevel == 9)
		{
			Level10();
		}
//		else if (s_curLevel == 10)
//		{
//			gameOver();
//		}
    }
    void Level1()
    {
        peasantManager.SetPeasants(true, 1.0f, 10, 1);
    }
    void Level2()
    {
        peasantManager.SetPeasants(true, 1.0f, 15, 1);
    }
    void Level3()
    {
        peasantManager.SetPeasants(true, 0.8f, 20, 1);
    }
    void Level4()
    {
        peasantManager.SetPeasants(true, 1.5f, 20, 2);
    }
	void Level5()
	{
		peasantManager.SetPeasants(true, 2.0f, 30, 3);
	}
	void Level6()
	{
		peasantManager.SetPeasants(true, 1.0f, 30, 2);
	}
	void Level7()
	{
		peasantManager.SetPeasants(true, 1.5f, 30, 3);
	}
	void Level8()
	{
		peasantManager.SetPeasants(true, 2.0f, 45, 3);
	}
	void Level9()
	{
		peasantManager.SetPeasants(true, 2.0f, 60, 2);
	}
	void Level10()
	{
		peasantManager.SetPeasants(false, 10000f, 9, 1);
	}

	public void gameOver()
	{
		GameManager.Instance.setGameState(Utils.Enums.GameState.GAME_OVER_STATE);
	}
}
