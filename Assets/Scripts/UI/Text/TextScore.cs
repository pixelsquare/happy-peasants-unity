using UnityEngine;
using System.Collections;

using PixelSquare.Events;

public class TextScore : UIText 
{
	private const string SCORE_FORMAT 	= "{0}/{1}";
	
	public override void onInitialize ()
	{
		base.onInitialize ();

		setScore(0, 10);
	}

	public override void onEnable ()
	{
		base.onEnable ();
		EventBroadcaster.Instance.addObserver(EventNames.ON_SCORE_CHANGED, onScoreChanged);
	}

	public override void onDisable ()
	{
		base.onDisable ();
		EventBroadcaster.Instance.removeObserver(EventNames.ON_SCORE_CHANGED, onScoreChanged);
	}

	private void onScoreChanged(EventParameters p_param)
	{
		int score = p_param.getParam(EventNames.CURRENT_SCORE, 0);
		int goal = p_param.getParam(EventNames.CURRENT_GOAL, 0);
		setScore(score, goal);
	}

	public void setScore(int p_score, int p_scoreMax)
	{
//		m_score = p_score;
		setText(string.Format(SCORE_FORMAT, p_score, p_scoreMax));
	}
}
