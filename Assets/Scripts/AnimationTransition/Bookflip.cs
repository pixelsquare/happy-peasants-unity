using UnityEngine;
using System.Collections;

using Utils.Enums;

public class Bookflip : AnimationTransition 
{
	[SerializeField] private GameState m_nextState = GameState.GAME_STATE;

	public override void onAnimationEnd ()
	{
		GameManager.Instance.setGameState(m_nextState);
	}
}
