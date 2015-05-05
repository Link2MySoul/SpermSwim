using UnityEngine;
using System.Collections;

public class AppControl : Core.MonoSingleton<AppControl>
{

    
    
	void Start () {
        Application.targetFrameRate = 60;
        
	}
	
	void Update () {
        
	}
    public void HandleTap(Vector3 position)
    {
		SceneControl.Instance.HandleTap (position);
        
    }
    
}
