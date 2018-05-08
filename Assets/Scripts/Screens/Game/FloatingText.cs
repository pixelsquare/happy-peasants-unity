using UnityEngine;
using System.Collections;

public class FloatingText : MonoBehaviour 
{
	[SerializeField] private TextMesh m_textMesh = null;
	[SerializeField] private float m_duration = 0.5f;
	[SerializeField] private float m_speed = 5.0f;

	private Renderer m_renderer = null;

	public void Start()
	{
		Destroy(gameObject, m_duration);

		if(m_textMesh == null)
		{
			m_textMesh = transform.GetComponentInChildren<TextMesh>();

		}

		m_renderer = m_textMesh.GetComponent<Renderer>();
		m_renderer.sortingLayerName = "UI";
		m_renderer.sortingOrder = 5;
	}

	public void Update()
	{
		transform.position += Vector3.up * m_speed * Time.deltaTime;
	}

	public void setText(string p_text)
	{
		m_textMesh.text = p_text;
	}
}
