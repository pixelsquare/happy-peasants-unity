using UnityEngine;
using System.Collections;

using PixelSquare.Events;

public class CameraPan : MonoBehaviour 
{
	private const float CAMERA_PAN_THRESHOLD = 0.99f;

	private Animator m_animator = null;
	private bool m_hasStarted = false;

	public void Start()
	{
		m_animator = GetComponent<Animator>();
		m_hasStarted = false;
	}

	public void Update()
	{
		updateCameraPanAnimation();
	}

	private void updateCameraPanAnimation()
	{
		float animThreshold = getAnimationThreshold();
		if(animThreshold >= CAMERA_PAN_THRESHOLD && !m_hasStarted)
		{
			EventBroadcaster.Instance.notifyObservers(EventNames.ON_GAME_PAN_FINISHED);
			m_hasStarted = true;
		}
	}

	private float getAnimationThreshold()
	{
		if(m_animator == null)
		{
			return 0.0f;
		}

		return m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
	}
}
