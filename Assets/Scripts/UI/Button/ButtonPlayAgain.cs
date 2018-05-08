using UnityEngine;
using System.Collections;

using Utils.Enums;

public class ButtonPlayAgain : Clickable 
{
	[SerializeField] private GameState m_nextState = GameState.EMPTY_GAME_STATE;

	public override void onButtonClick ()
	{
		base.onButtonClick();
		GameManager.Instance.setGameState(m_nextState);
	}
}
