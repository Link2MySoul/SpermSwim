using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class StateMachine  {

	public State previous;
	public State current;
	public Dictionary<string,State> states = new Dictionary<string, State>();
	public virtual void ChangeState(State state)
	{
		if (states.ContainsValue (state)) {
			previous = current;
			if (current != null && current.running) {
				current.OnLeave();
			}
			current = state;
		}
	}

	public virtual void ChangeState(string name)
	{
		State state;
		if (states.TryGetValue (name , out state)) {
			ChangeState(state);
		}
	}

	public virtual void TickState()
	{
		if (current != null) {
			if(!current.running)current.OnEnter();
			current.OnUpdate();
			if(current.IsDone())current.OnLeave();
		}
	}

	public virtual void AddState(string name, State state)
	{
		if (!states.ContainsKey (name)) {
			states.Add (name, state);
		} else {
			states[name] = state;
		}
	}

	public virtual void RemoveState(string name)
	{
		if (states.ContainsKey (name)) {
			states.Remove(name);
		}
	}

}
