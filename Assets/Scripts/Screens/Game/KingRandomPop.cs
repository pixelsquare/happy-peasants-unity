using UnityEngine;
using System.Collections;

public class KingRandomPop : MonoBehaviour 
{
	[SerializeField] private SpriteRenderer m_spriteRenderer = null;
	[SerializeField] private Sprite[] m_sprites = null;

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
				int idx = getRandomSpriteIdx();
				setSprite(idx < m_sprites.Length ? m_sprites[idx] : null);
				m_timer = Random.Range(m_min, m_max);
			}
		}
	}

	private int getRandomSpriteIdx()
	{
		int len = m_sprites.Length;
		return Random.Range(0, len + 1);
	}

	private void setSprite(Sprite p_spr)
	{
		m_spriteRenderer.sprite = p_spr;
	}
}
