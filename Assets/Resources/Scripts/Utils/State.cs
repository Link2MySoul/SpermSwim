using UnityEngine;
using System.Collections;
using System;

public class State  {
	public StateMachine machine;
	public bool running;
	private Action _enterAction;
	private Action _updateAction;
	private Action _leaveAction;
	public State (Action enterAction, Action updateAction, Action leaveAction)
	{
		_enterAction = enterAction;
		_updateAction  = updateAction;
		_leaveAction = leaveAction;
	}
	public virtual void OnEnter()
	{
		running = true;
		if (_enterAction != null)_enterAction();
	}
	public virtual void OnLeave()
	{
		running = false;
		if (_leaveAction != null)_leaveAction();
	}
	public virtual void OnUpdate()
	{
		if (_updateAction != null)_updateAction();

	}
	public virtual bool IsDone()
	{
		return false;
	}
}
