using UnityEngine;
using System.Collections;

using PixelSquare.Events;
using UnityEngine.UI;
using Utils.Constants;

[RequireComponent(typeof(Collider2D))]
public class BloodSplatter : MonoBehaviour 
{
	[SerializeField] private Sprite m_sprite = null;
	[SerializeField] private Image m_image = null;

	private float m_timer = 0.0f;

	public void Update()
	{
		if(m_timer > 0.0f)
		{
			m_timer -= Time.deltaTime;

			if(m_timer <= 0.0f)
			{
				EventBroadcaster.Instance.notifyObservers(EventNames.SCREEN_FADE_IN);
				EventBroadcaster.Instance.notifyObservers(EventNames.SCREEN_CUTSCENE_IN);
			}
		}
	}

	public void OnMouseDown()
	{
		m_image.sprite = m_sprite;
		EventBroadcaster.Instance.notifyObservers(EventNames.SCREEN_FADE_OUT);
		EventBroadcaster.Instance.notifyObservers(EventNames.SCREEN_CUTSCENE_OUT);
		AudioManager.Instance.playSFX(Constants.SFX_BLOOD);
		m_timer = 3.0f;
	}
}
