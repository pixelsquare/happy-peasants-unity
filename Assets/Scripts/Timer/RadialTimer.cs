using UnityEngine;
using System.Collections;

using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class RadialTimer : Timer 
{
	private Image m_image 						= null;
	
	public override void onInitialize ()
	{
		m_image = GetComponent<Image>();
		if(m_image.type != Image.Type.Filled)
		{
			Debug.LogWarning("Image type not set to filled!");
		}
	}

	public override void onUpdate ()
	{
		updateImageFilled();
	}

	public override void onTimerEnd ()
	{
		// Do Something!
	}

	private void updateImageFilled()
	{
		m_image.fillAmount = 1.0f - (m_timer / m_timeout);
	}
}
