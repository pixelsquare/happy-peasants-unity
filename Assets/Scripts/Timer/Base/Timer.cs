using UnityEngine;
using System.Collections;


public class Timer : MonoBehaviour 
{
	[SerializeField] protected float m_timeout 	= 2.0f;
	
	protected float m_timer 						= 0.0f;

	public void Start()
	{
		m_timer = 0.0f;

		setTimerTimeout(m_timeout);
		onInitialize();
	}

	public void Update()
	{
		updateTimer();
		onUpdate();
	}

	public virtual void onInitialize() { }

	public virtual void onUpdate() { }

	public virtual void onTimerEnd() { }

	public void setTimerTimeout(float p_timeout)
	{
		m_timer = p_timeout;
	}

	private void updateTimer()
	{
		if(m_timer > 0.0f)
		{
			m_timer -= Time.deltaTime;

			if(m_timer <= 0.0f)
			{
				// Do Something!
				onTimerEnd();
			}
		}
	}
}
