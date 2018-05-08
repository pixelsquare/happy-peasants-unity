using UnityEngine;
using System.Collections;

using Utils.Enums;
using UnityEngine.UI;
using PixelSquare.Events;
using Utils.Constants;

[RequireComponent(typeof(Collider2D))]
public class Door : MonoBehaviour 
{
	[SerializeField] private Sprite m_sprite = null;
	[SerializeField] private Image m_image = null;
	
//	private float m_timer = 0.0f;
	
//	public void Update()
//	{
//		if(m_timer > 0.0f)
//		{
//			m_timer -= Time.deltaTime;
//			
//			if(m_timer <= 0.0f)
//			{
//				EventBroadcaster.Instance.notifyObservers(EventNames.SCREEN_FADE_IN);
//				EventBroadcaster.Instance.notifyObservers(EventNames.SCREEN_CUTSCENE_IN);
//			}
//		}
//	}
	
	public void OnMouseDown()
	{
		m_image.sprite = m_sprite;
		m_image.SetNativeSize();
		EventBroadcaster.Instance.notifyObservers(EventNames.SCREEN_FADE_OUT);
		EventBroadcaster.Instance.notifyObservers(EventNames.SCREEN_CUTSCENE_OUT);
		AudioManager.Instance.playSFX(Constants.SFX_DOOR01);
		AudioManager.Instance.playBGM(Constants.BGM_CUTSCENE);
		StartCoroutine(delayedMainMenu(8.0f));
//		m_timer = 5.0f;
	}

	private IEnumerator delayedMainMenu(float p_timer)
	{
		yield return new WaitForSeconds(p_timer);
		GameManager.Instance.setGameState(GameState.MAIN_MENU_STATE);
	}
}
