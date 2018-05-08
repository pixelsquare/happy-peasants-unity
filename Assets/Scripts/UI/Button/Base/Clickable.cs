using UnityEngine;
using System.Collections;

using UnityEngine.UI;
using Utils.Constants;

[RequireComponent(typeof(Button))]
public class Clickable : MonoBehaviour 
{
	private Button m_button 	= null;

	public void Start()
	{
		m_button = GetComponent<Button>();
		m_button.onClick.AddListener(onButtonClick);

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

	public void Update()
	{
		onUpdate();
	}

	public virtual void onInitialize() { } 

	public virtual void onEnable() { }

	public virtual void onDisable() { }

	public virtual void onUpdate() { }

	public virtual void onButtonClick() 
	{
		// Do Something! Audio?!
		AudioManager.Instance.playSFX(Constants.SFX_BUTTONS);
	}
}
