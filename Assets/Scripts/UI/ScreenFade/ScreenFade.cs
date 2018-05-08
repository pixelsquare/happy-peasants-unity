using UnityEngine;
using System.Collections;

using UnityEngine.UI;
using PixelSquare.Events;

[RequireComponent(typeof(Canvas))]
public class ScreenFade : MonoBehaviour 
{
//	private static ScreenFade s_instance = null;
//	public static ScreenFade Instance
//	{
//		get { return s_instance; }
//	}

	private const string FADE_IN_TRIGGER = "FadeIn";
	private const string FADE_OUT_TRIGGER = "FadeOut";

	private Canvas m_canvas 			= null;
	private Animator m_animator 		= null;

//	public void Awake()
//	{
//		if(s_instance == null)
//		{
//			s_instance = this;
//		}
//		else 
//		{
//			Destroy(gameObject);
//		}
//
//		DontDestroyOnLoad(gameObject);
//	}

	public void Start()
	{
		m_canvas = GetComponent<Canvas>();
		m_animator = GetComponent<Animator>();

//		initializeCanvas();
	}

	public void OnEnable()
	{
		EventBroadcaster.Instance.addObserver(EventNames.SCREEN_FADE_IN, fadeIn);
		EventBroadcaster.Instance.addObserver(EventNames.SCREEN_FADE_OUT, fadeOut);
	}

	public void OnDisable()
	{
		EventBroadcaster.Instance.removeObserver(EventNames.SCREEN_FADE_IN, fadeIn);
		EventBroadcaster.Instance.removeObserver(EventNames.SCREEN_FADE_OUT, fadeOut);
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
