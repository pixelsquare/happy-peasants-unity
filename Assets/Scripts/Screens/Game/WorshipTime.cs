using UnityEngine;
using System.Collections;

public class WorshipTime : MonoBehaviour 
{
	private Animator m_animator = null;

	private float m_timer = 0.0f;
	private float m_killTimer = 0.0f;

	public void Start()
	{
		m_animator = GetComponent<Animator>();
		m_timer = 3.0f;
	}

	public void Update()
	{
		if(m_timer > 0.0f)
		{
			if(m_animator.GetCurrentAnimatorStateInfo(0).IsName("WorshipTime"))
			{
				m_timer -= Time.deltaTime;

				if(m_timer <= 0.0f)
				{
					m_animator.SetTrigger("Ease Out");
					Destroy(gameObject, 0.75f);
				}
			}
		}
	}
}
