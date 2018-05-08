using UnityEngine;
using System.Collections;

using PixelSquare.Events;

public class TextLevel : UIText 
{
	private const string LEVEL_FORMAT = "Level {0}";

	public override void onInitialize ()
	{
		base.onInitialize ();
	}

	public override void onEnable ()
	{
		base.onEnable ();
		EventBroadcaster.Instance.addObserver(EventNames.ON_LEVEL_CHANGED, onLevelChanged);
	}

	public override void onDisable ()
	{
		base.onDisable ();
		EventBroadcaster.Instance.removeObserver(EventNames.ON_LEVEL_CHANGED, onLevelChanged);
	}

	private void onLevelChanged(EventParameters p_param)
	{
		int level = p_param.getParam(EventNames.CURRENT_LEVEL, 0);
		setLevel(level + 1);
	}

	private void setLevel(int p_level)
	{
		setText(string.Format(LEVEL_FORMAT, p_level));
	}
}
