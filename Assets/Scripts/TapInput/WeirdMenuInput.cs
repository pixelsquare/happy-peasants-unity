using UnityEngine;
using System.Collections;

using Utils.Enums;

public class WeirdMenuInput : TapInput 
{
	[SerializeField] private GameState m_nextState = GameState.EMPTY_GAME_STATE;

	public override void onTap ()
	{
		base.onTap ();
		GameManager.Instance.setGameState(m_nextState);
	}
}
