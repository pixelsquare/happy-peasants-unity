using UnityEngine;
using System.Collections;

using Utils.Enums;
using Utils.Constants;
using PixelSquare.Events;
using UnityEngine.UI;

public class GameContinueInput : Clickable
{
//	[SerializeField] private GameState m_nextState 	= GameState.GAME_STATE;
	
	[SerializeField] private Image m_image = null;
	[SerializeField] private Sprite[] m_sprites = null;

	private Animator m_animator = null;
	private bool m_isActive 	= false;
//	private bool m_isTappable = false;

	private float m_timer = 0.0f;

	public override void onInitialize ()
	{
		base.onInitialize ();
		m_animator = GetComponent<Animator>();
		m_isActive = false;
//		m_isTappable = false;

		disableChildren();
	}

	public override void onEnable ()
	{
		base.onEnable ();
		EventBroadcaster.Instance.addObserver(EventNames.ON_GAME_CONTINUE, onLevelContinue);
//		EventBroadcaster.Instance.addObserver(EventNames.ON_POST_GAME_CONTINUE, enableChildren);
		EventBroadcaster.Instance.addObserver(EventNames.ON_GAME_TIME, disableChildren);
		EventBroadcaster.Instance.addObserver(EventNames.ON_LEVEL_CHANGED, onLevelChanged);
	}

	public override void onDisable ()
	{
		base.onDisable ();
		EventBroadcaster.Instance.removeObserver(EventNames.ON_GAME_CONTINUE, onLevelContinue);
//		EventBroadcaster.Instance.removeObserver(EventNames.ON_POST_GAME_CONTINUE, enableChildren);
		EventBroadcaster.Instance.removeObserver(EventNames.ON_GAME_TIME, disableChildren);
		EventBroadcaster.Instance.removeObserver(EventNames.ON_LEVEL_CHANGED, onLevelChanged);
	}

	public override void onUpdate ()
	{
		base.onUpdate ();
		if(m_timer > 0.0f)
		{
			m_timer -= Time.deltaTime;

			if(m_timer < 0.0f)
			{
				enableChildren();
				AudioManager.Instance.playSFX(Constants.SFX_ENDCARD01);
//				EventBroadcaster.Instance.notifyObservers(EventNames.ON_POST_GAME_CONTINUE);
			}
		}
	}

//	public override void onUpdate ()
//	{
//		base.onUpdate ();
//		if(m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.99f)
//		{
//			AudioManager.Instance.playSFX(Constants.SFX_ENDCARD01);
////			m_isTappable = true;
//		}
//	}

	public override void onButtonClick ()
	{
		if(!m_isActive)
		{
			return;
		}

		base.onButtonClick ();
		LevelManager levelManager = GameObject.FindObjectOfType<LevelManager>();
		if(levelManager != null)
		{
			levelManager.LoadLevel();
		}

		EventBroadcaster.Instance.notifyObservers(EventNames.ON_GAME_TIME);
	}

//
//	public override void onTap ()
//	{
//		if(!m_isActive || !m_isTappable)
//		{
//			return;
//		}
//
//		base.onTap();
//		// Do Something
////		GameManager.Instance.setGameState(m_nextState);
//		EventBroadcaster.Instance.notifyObservers(EventNames.ON_GAME_TIME);
//	}

	public void onLevelContinue()
	{
		AudioManager.Instance.playSFX(Constants.SFX_ENDCARD02);
		m_timer = 3.0f;
	}

	public void enableChildren()
	{
		setChildrenActive(true);
		m_animator.SetTime(0.0);
		m_isActive = true;
	}

	public void disableChildren()
	{
		setChildrenActive(false);
		m_animator.SetTime(0.0);
		m_isActive = false;
	}

	private void onLevelChanged(EventParameters p_param)
	{
		int level = p_param.getParam(EventNames.CURRENT_LEVEL, 0);
		if(level < m_sprites.Length)
		{
			m_image.sprite = m_sprites[level];
		}
	}

	private void setChildrenActive(bool p_active)
	{
		foreach(Transform child in transform)
		{
			child.gameObject.SetActive(p_active);
		}
	}
}
