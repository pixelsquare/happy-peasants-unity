using UnityEngine;
using System.Collections;

public class KingRandomAnim : MonoBehaviour 
{
	public enum KingAnimState
	{
		STATE_IDLE = 0,
		STATE_FAN,
		STATE_SCRATCH
	}
	
	private SkeletonAnimation m_skelAnim = null;

	private float m_min = 3.0f;
	private float m_max = 5.0f;


	private float m_timer = 0.0f;

	public void Start()
	{
		m_skelAnim = GetComponent<SkeletonAnimation>();
		m_timer = Random.Range(m_min, m_max);
	}

	public void Update()
	{
		if(m_timer > 0.0f)
		{
			m_timer -= Time.deltaTime;

			if(m_timer <= 0.0f)
			{
				int randIdx = Random.Range(0, 3);
				string anim = getAnimState(randIdx);
				m_skelAnim.AnimationName = anim;
				m_timer = Random.Range(m_min, m_max);
			}
		}
	}


	private string getAnimState(int p_idx)
	{
		if(p_idx == 0)
		{
			return "KingIdle";
		}
		else if(p_idx == 1)
		{
			return "KingFan";
		}
		else if(p_idx == 2)
		{
			return "KingScratch";
		}

		return "";
	}
}
