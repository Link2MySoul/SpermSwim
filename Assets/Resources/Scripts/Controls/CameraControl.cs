using UnityEngine;
using System.Collections;

public class CameraControl : Core.MonoSingleton<CameraControl>
{



		
	void Update () {
		if (SceneControl.Instance != null) {
			Vector3 position = Camera.main.transform.position;
			Vector3 targetPosition = SceneControl.Instance.GetFlockPosition();
			Vector3 delta = targetPosition-position;
			if(delta.magnitude > .05f)
			{
				position.z = targetPosition.z;
				position += (delta)*.1f;
				position.z = Camera.main.transform.position.z;
				Camera.main.transform.position = position;
			}
			else
			{
				position = targetPosition;
				position.z = Camera.main.transform.position.z;
				Camera.main.transform.position = position;
			}

		}
	}
}
