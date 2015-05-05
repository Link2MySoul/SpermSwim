using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SceneControl : Core.MonoSingleton<SceneControl> {

	
	private List<Flock> _flocks;
	private int _flockCount = 10;
	void Start () {
		_flocks = new List<Flock> ();
		_flocks.Add (new Flock ());

		InitFlock();
	}
	
	// Update is called once per frame
	void Update () {
		foreach (var flock in _flocks) {
			flock.Simulate();
		}
	}

	public void HandleTap(Vector3 position)
	{
		if (_flocks.Count>0)
		{
			_flocks[0].Follow(position);
		}
	}
	public Vector3 GetFlockPosition()
	{
		Vector3 position = Vector3.zero;
		foreach (var flock in _flocks) {
			position+=flock.GetLeader().transform.position;
		}
		position /= _flocks.Count;
		return position;
	}
	public void InitFlock()
	{
		for (int i = 0; i < _flockCount; i++)
		{
			_flocks[0].AddUnit(EntityPool.Instance.Use<Sperm>());
		}
		_flocks[0].LineUp();
	}
}
