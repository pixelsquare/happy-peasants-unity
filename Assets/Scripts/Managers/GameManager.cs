using UnityEngine;
using System.Collections;

using Utils.Constants;
using Utils.Enums;
using PixelSquare.Events;

public class GameManager : MonoBehaviour 
{
	private static GameManager s_instance = null;
	public static GameManager Instance
	{
		get 
		{ 
//			if(s_instance == null)
//			{
//				GameObject gameManagerObj = new GameObject("GameManager");
//				GameManager gameManager = gameManagerObj.AddComponent<GameManager>();
//				s_instance = gameManager;
//			}

			return s_instance; 
		}
	}

	[SerializeField] private GameState m_gameState = GameState.MAIN_MENU_STATE;
	[SerializeField] private LevelState m_levelState = LevelState.LEVEL_CONTINUE;

	public void Awake()
	{
		if(s_instance == null)
		{
			s_instance = this;
		}
		else
		{
			Destroy(this);
		}

		DontDestroyOnLoad(this);
	}

	public void Start()
	{
		setGameState(m_gameState);
//		AudioManager.Instance.playBGM(Constants.BGM_FOOLBOY);
	}

	public void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			EventBroadcaster.Instance.notifyObservers(EventNames.ON_GAME_FAILED);
		}
//		if(Input.GetKeyDown(KeyCode.V))
//		{
//			EventBroadcaster.Instance.notifyObservers(EventNames.SCREEN_FADE_OUT);
////			ScreenFade.Instance.fadeOut();
////			AudioManager.Instance.playSFX(Constants.SFX_REITANNA);
//		}
//
//		if(Input.GetKeyDown(KeyCode.B))
//		{
//			EventBroadcaster.Instance.notifyObservers(EventNames.SCREEN_FADE_IN);
////			ScreenFade.Instance.fadeIn();
//		}
	}

	// Call this method to invoke Load Scene
	public void setGameState(GameState p_gameState)
	{
		// We don't need to check for comparison
//		if(m_gameState == p_gameState)
//		{
//			return;
//		}

		m_gameState = p_gameState;
		setGameScene(m_gameState);
	}

	// Call this method to invoke Load Scene
	public void setLevelState(LevelState p_levelState)
	{
		// We don't need to check for comparison
//		if(m_levelState == p_levelState)
//		{
//			return;
//		}

		m_levelState = p_levelState;
		setLevelScene(m_levelState);
	}

	private void setGameScene(GameState p_gameState)
	{
		switch(p_gameState)
		{
			case GameState.MAIN_MENU_STATE:
			{
				AudioManager.Instance.stopAllBGM();
				Application.LoadLevel(Constants.SCENE_MAIN_MENU);
				AudioManager.Instance.playBGM(Constants.BGM_MAINMENU);
				break;
			}
			case GameState.GAME_STATE:
			{
				AudioManager.Instance.stopAllBGM();
				Application.LoadLevel(Constants.SCENE_GAME);
				AudioManager.Instance.playBGM(Constants.BGM_GAMEPLAY);
				break;
			}
			case GameState.GAME_OVER_STATE:
			{
				AudioManager.Instance.stopAllBGM();
				Application.LoadLevel(Constants.SCENE_GAME_OVER);
				break;
			}
			case GameState.WEIRD_MENU_STATE:
			{
				AudioManager.Instance.stopAllBGM();
				Application.LoadLevel(Constants.SCENE_WEIRD_MENU);
				AudioManager.Instance.playBGM(Constants.BGM_WEIRDMAINMENU);
				break;
			}
			case GameState.EMPTY_GAME_STATE:
			{
				AudioManager.Instance.stopAllBGM();
				Application.LoadLevel(Constants.SCENE_EMPTY_GAME);
				break;
			}
		}
	}

	private void setLevelScene(LevelState p_levelState)
	{
		switch(p_levelState)
		{
			case LevelState.LEVEL_CONTINUE:
			{
				Application.LoadLevel(Constants.SCENE_GAME_CONTINUE);
				break;
			}
			case LevelState.LEVEL_FAILED:
			{
				Application.LoadLevel(Constants.SCENE_GAME_FAILED);
				break;
			}
		}
	}
}
