using UnityEngine;
using System.Collections;

using PixelSquare.Events;

public class CutsceneFade : MonoBehaviour 
{
	private const string FADE_IN_TRIGGER = "Fade In";
	private const string FADE_OUT_TRIGGER = "Fade Out";
	
	private Canvas m_canvas 			= null;
	private Animator m_animator 		= null;

	public void Start()
	{
		m_canvas = GetComponent<Canvas>();
		m_animator = GetComponent<Animator>();
		
		//		initializeCanvas();
	}
	
	public void OnEnable()
	{
		EventBroadcaster.Instance.addObserver(EventNames.SCREEN_CUTSCENE_IN, fadeIn);
		EventBroadcaster.Instance.addObserver(EventNames.SCREEN_CUTSCENE_OUT, fadeOut);
	}
	
	public void OnDisable()
	{
		EventBroadcaster.Instance.removeObserver(EventNames.SCREEN_CUTSCENE_IN, fadeIn);
		EventBroadcaster.Instance.removeObserver(EventNames.SCREEN_CUTSCENE_OUT, fadeOut);
	}
	
	public void fadeIn()
	{
		if(m_animator == null)
		{
			return;
		}
		
		m_animator.SetTrigger(FADE_IN_TRIGGER);
	}
	
	public void fadeOut()
	{
		if(m_animator == null)
		{
			return;
		}
		
		m_animator.SetTrigger(FADE_OUT_TRIGGER);
	}
	
	private void initializeCanvas()
	{
		if(m_canvas == null)
		{
			return;
		}
		
		m_canvas.overrideSorting = true;
		m_canvas.sortingLayerName = "UI";
		m_canvas.sortingLayerID = 1000;
	}
}
