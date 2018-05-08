using UnityEngine;
using System.Collections;

using PixelSquare.Events;

public class GameFailed : Clickable 
{
	private Animator m_animator = null;

	public override void onInitialize ()
	{
		base.onInitialize ();
		m_animator = GetComponent<Animator>();
		disableChildren();
	}

	public override void onEnable ()
	{
		base.onEnable ();
		EventBroadcaster.Instance.addObserver(EventNames.ON_GAME_FAILED, enableChildren);
		EventBroadcaster.Instance.addObserver(EventNames.ON_GAME_TIME, disableChildren);
	}

	public override void onDisable ()
	{
		base.onDisable ();
		EventBroadcaster.Instance.removeObserver(EventNames.ON_GAME_FAILED, enableChildren);
		EventBroadcaster.Instance.removeObserver(EventNames.ON_GAME_TIME, disableChildren);
	}

//	public override void onTap ()
//	{
//		base.onTap ();
//
////		EventBroadcaster.Instance.notifyObservers(EventNames.SCREEN_FADE_IN);
//		disableChildren();
//	}

	public override void onButtonClick ()
	{
		base.onButtonClick ();

		// Do something to reset the current level
		EventBroadcaster.Instance.notifyObservers(EventNames.ON_GAME_TIME);
	}
	
	private void enableChildren()
	{
		setChildrenActive(true);
		m_animator.SetTime(0.0);
	}
	
	private void disableChildren()
	{
		setChildrenActive(false);
		m_animator.SetTime(0.0);
	}
	
	private void setChildrenActive(bool p_active)
	{
		foreach(Transform child in transform)
		{
			child.gameObject.SetActive(p_active);
		}
	}
}
