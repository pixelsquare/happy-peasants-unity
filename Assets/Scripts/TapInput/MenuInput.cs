using UnityEngine;
using System.Collections;

using Utils.Enums;

public class MenuInput : TapInput 
{
//	[SerializeField] private GameObject m_bookflip 	= null;

	private bool m_hasGameStarted					= false;

	public override void onInitialize ()
	{
		m_hasGameStarted = false;
//		setBookflipActive(false);
	}

	public override void onTap ()
	{
		base.onTap();
		if(m_hasGameStarted)
		{
			return;
		}

		m_hasGameStarted = true;
		GameManager.Instance.setGameState(GameState.GAME_STATE);
//		setBookflipActive(true);
	}

//	public void setBookflipActive(bool p_active)
//	{
//		if(m_bookflip == null)
//		{
//			Debug.LogWarning("Book flip not attached!");
//			return;
//		}
//
//		m_bookflip.SetActive(p_active);
//	}
}
