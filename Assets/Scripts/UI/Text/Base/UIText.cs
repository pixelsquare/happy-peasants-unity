using UnityEngine;
using System.Collections;

using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class UIText : MonoBehaviour 
{
	private Text m_textComponent 	= null;
	private string m_text		 	= "";

	public void Start()
	{
		onInitialize();
	}

	public void OnEnable()
	{
		onEnable();
	}

	public void OnDisable()
	{
		onDisable();
	}

	public virtual void onInitialize()
	{
		m_textComponent = GetComponent<Text>();
		m_text = "";
		
		setTextDirty();
	}

	public virtual void onEnable() { }

	public virtual void onDisable() { }

	public void setText(string p_text)
	{
		m_text = p_text;
		setTextDirty();
	}

	public void setTextDirty()
	{
		if(m_textComponent == null)
		{
			return;
		}

		m_textComponent.text = m_text;
	}
}
