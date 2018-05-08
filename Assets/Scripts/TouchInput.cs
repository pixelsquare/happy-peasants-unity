using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TouchInput : MonoBehaviour 
{
	protected Camera camera;

	private List<GameObject> touchList = new List<GameObject>();
	private GameObject[] touchesOld;

	private Ray ray;
	[HideInInspector]
	public RaycastHit2D[] hit;

	public virtual void OnTouchUp(){}	
    public virtual void OnTouchDown(){}
	public virtual void OnTouchExit(){}
	public virtual void OnTouchStay(Vector2 point){}
    public virtual void OnTouchDownScreen(Vector2 point){}
    public virtual void OnTouchUpScreen(Vector2 point){}
    public virtual void DoUpdate(){}
    public virtual void DoAwake(){}

    void Awake()
    {
        camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        DoAwake();
    }

	void Update () 
	{
		if(Input.touchCount == 1)
		{
			touchesOld = new GameObject[touchList.Count];
			touchList.CopyTo(touchesOld);
			touchList.Clear();

			foreach (Touch touch in Input.touches)
			{
				hit = Physics2D.RaycastAll(camera.ScreenToWorldPoint(touch.position), Vector2.zero);


				int i = 0;
				
				while (i < hit.Length) 
				{
					if(hit[i].collider != null)
					{

						GameObject recipient = hit[i].transform.gameObject;
						touchList.Add(recipient);

						if(touch.phase == TouchPhase.Began)
						{
                            if(recipient.transform == transform)
                                OnTouchDown();
						}
						if(touch.phase == TouchPhase.Ended)
						{
                            if(recipient.transform == transform)
                                OnTouchUp();

                            OnTouchUp();
						}
						if(touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
						{
                            if(recipient.transform == transform)
                                OnTouchStay(hit[i].point);
						}
						if(touch.phase == TouchPhase.Canceled)
						{
                            if(recipient.transform == transform)
                                OnTouchExit();
						}
			        }
			        i++;
		        }

                switch(touch.phase)
                {
                    case TouchPhase.Began:
                        OnTouchDownScreen(touch.position);
                        break;
                    case TouchPhase.Ended:
                        OnTouchUpScreen(touch.position);
                        break;
                }
                
				foreach (GameObject g in touchesOld)
				{
					if(!touchList.Contains(g))
					{
                        if(g.transform == transform)
                            OnTouchExit();
                    }
    			}
	        }
        }
        DoUpdate();
    }
}
