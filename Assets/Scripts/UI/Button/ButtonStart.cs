using UnityEngine;
using System.Collections;

using Utils.Enums;

public class ButtonStart : MonoBehaviour 
{
	private SkeletonAnimation m_skeletonAnim = null;

	public void OnDisable()
	{
		m_skeletonAnim.state.Complete -= resetAnim;
	}

	public void Start()
	{
		m_skeletonAnim = GetComponent<SkeletonAnimation>();
		m_skeletonAnim.state.Complete += resetAnim;
	}

	public void OnMouseDown()
	{
		m_skeletonAnim.AnimationName = "KingMenuPress";
	}

	public void resetAnim(Spine.AnimationState p_state, int p_trackIdx, int p_loopCount)
	{
		m_skeletonAnim.AnimationName = "KingMenuIdle";
		GameManager.Instance.setGameState(GameState.GAME_STATE);
	}
}
