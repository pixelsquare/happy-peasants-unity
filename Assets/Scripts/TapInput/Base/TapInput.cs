using UnityEngine;
using System.Collections;

using Utils.Constants;

public class TapInput : MonoBehaviour 
{
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

	public void Update()
	{
		updateTapInput();
		onUpdate();
	}

	public virtual void onInitialize() { }

	public virtual void onEnable() { }

	public virtual void onDisable() { }

	public virtual void onUpdate() { }

	public virtual void onTap() 
	{ 
		AudioManager.Instance.playSFX(Constants.SFX_BUTTONS);
//		Debug.Log(gameObject.name);
	}

	private void updateTapInput()
	{
		if(Input.GetMouseButtonUp(0))
		{
			onTap();
		}
	}
}
