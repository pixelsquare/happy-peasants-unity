using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TestUI : MonoBehaviour
{
    public Text text;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        text.text = PeasantManager.s_touchCounter.ToString();

    }
}
