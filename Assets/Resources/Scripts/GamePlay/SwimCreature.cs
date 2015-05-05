using UnityEngine;
using System.Collections;

public class SwimCreature : MonoBehaviour {


	public virtual Vector3 GetReverseDirection()
	{
		return Vector3.zero;
	}
	public virtual Vector3 GetDirection()
	{
		return Vector3.zero;
	}
}
