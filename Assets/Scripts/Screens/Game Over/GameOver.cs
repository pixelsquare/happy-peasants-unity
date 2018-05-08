using UnityEngine;
using System.Collections;

using Utils.Enums;
using Utils.Constants;
using PixelSquare.Events;

public class GameOver : MonoBehaviour 
{
	private const float ANIMATION_KILL_THRESHOLD = 0.99f;

	[SerializeField] private GameState m_nextState = GameState.WEIRD_MENU_STATE;

	private Animator m_animator = null;
	private bool m_hasDoneAnimation = false;
	private float m_timer = 0.0f;

	public void Start()
	{
		m_animator = GetComponent<Animator>();
		m_hasDoneAnimation = false;
		m_timer = 0.0f;

		AudioManager.Instance.playSFX(Constants.SFX_GAMEOVER);
	}

	public void Update()
	{
		updateAnimation();
		updateTimer();
	}

	public void updateAnimation()
	{
		float animThreshold = getAnimationThreshold();
		if(animThreshold >= ANIMATION_KILL_THRESHOLD && !m_hasDoneAnimation)
		{
			EventBroadcaster.Instance.notifyObservers(EventNames.SCREEN_FADE_OUT);
			m_timer = 1.0f;
			m_hasDoneAnimation = true;
		}
	}

	private void updateTimer()
	{
		if(m_timer > 0.0f)
		{
			m_timer -= Time.deltaTime;

			if(m_timer <= 0.0f)
			{
				GameManager.Instance.setGameState(m_nextState);
			}
		}
	}

	private float getAnimationThreshold()
	{
		if(m_animator == null)
		{
			return 0.0f;
		}

		return m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
	}
}
