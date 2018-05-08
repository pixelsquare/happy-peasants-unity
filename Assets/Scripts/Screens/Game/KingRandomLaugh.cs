using UnityEngine;
using System.Collections;

using Utils.Constants;

public class KingRandomLaugh : MonoBehaviour 
{	
	private float m_timer = 0.0f;
	
	private float m_min = 3.0f;
	private float m_max = 5.0f;
	
	public void Start()
	{
		m_timer = Random.Range(m_min, m_max);
	}
	
	public void Update()
	{
		if(m_timer > 0.0f)
		{
			m_timer -= Time.deltaTime;
			
			if(m_timer <= 0.0f)
			{
				AudioManager.Instance.playSFX(Constants.SFX_KINGLAUGH);
				m_timer = Random.Range(m_min, m_max);
			}
		}
	}
}
