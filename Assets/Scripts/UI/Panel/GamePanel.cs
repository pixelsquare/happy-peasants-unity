using UnityEngine;
using System.Collections;

using PixelSquare.Events;

public class GamePanel : MonoBehaviour 
{
	public void Start()
	{
		disableChildren();
	}

	public void OnEnable()
	{
		EventBroadcaster.Instance.addObserver(EventNames.ON_GAME_PAN_FINISHED, enableChildren);
	}

	public void OnDisable()
	{
		EventBroadcaster.Instance.removeObserver(EventNames.ON_GAME_PAN_FINISHED, enableChildren);
	}

//	public void Update()
//	{
//		if(Input.GetKeyDown(KeyCode.V))
//		{
//			EventBroadcaster.Instance.notifyObservers(EventNames.ON_GAME_CONTINUE);
//		}
//
//		if(Input.GetKeyDown(KeyCode.B))
//		{
//			EventBroadcaster.Instance.notifyObservers(EventNames.SCREEN_FADE_OUT);
//			EventBroadcaster.Instance.notifyObservers(EventNames.ON_GAME_FAILED);
//		}
//
//		if(Input.GetKeyDown(KeyCode.Space))
//		{
//			GameManager.Instance.setGameState(Utils.Enums.GameState.GAME_OVER_STATE);
////			EventBroadcaster.Instance.notifyObservers(EventNames.ON_GAME_TIME);
//		}
//
//	}

	private void enableChildren()
	{
		setChildrenActive(true);
	}

	private void disableChildren()
	{
		setChildrenActive(false);
	}

	private void setChildrenActive(bool p_active)
	{

		foreach(Transform child in transform)
		{
			child.gameObject.SetActive(p_active);
		}
	}
}
