using UnityEngine;
using System.Collections;

public class AnimationTransition : MonoBehaviour 
{
	private const float ANIMATION_KILL_THRESHOLD = 1.0f;

	private Animator m_animator 	= null;

	public void Start()
	{
		m_animator = GetComponent<Animator>();
		if(m_animator == null)
		{
			Debug.LogWarning("Missing Animator Component!");
		}
	}

	public void Update()
	{
		updateAnimation();
	}

	public virtual void onAnimationEnd() { }

	public void updateAnimation()
	{
		if(m_animator == null)
		{
			return;
		}

		float animationThreshold = getAnimationThreshold();
		if(animationThreshold >= ANIMATION_KILL_THRESHOLD)
		{
			// Do Something!
			onAnimationEnd();
		}
	}

	public float getAnimationThreshold()
	{
		if(m_animator == null)
		{
			return 0.0f;
		}

		return m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
	}
}
