using UnityEngine;
using System.Collections;

using Utils.Enums;
using PixelSquare.Events;

public class ButtonRestart : Clickable 
{
	public override void onButtonClick ()
	{
		base.onButtonClick();
		// Do Something!
//		GameManager.Instance.setGameState(GameState.GAME_STATE);
		EventBroadcaster.Instance.notifyObservers(EventNames.ON_GAME_TIME);
	}
}
