using UnityEngine;
using System.Collections;

using Utils.Enums;

public class GameOverInput : TapInput 
{
	[SerializeField] private GameState m_nextState = GameState.WEIRD_MENU_STATE;

	public override void onTap ()
	{
		base.onTap ();
		GameManager.Instance.setGameState(m_nextState);
	}
}
