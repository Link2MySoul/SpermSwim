using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Flock  {

	private Form _form;
	private List<Sperm>_sperms;
    private Vector3 _targetPosition = Vector3.zero;
    public Flock()
    {
		_sperms = new List<Sperm> ();
        _form = new TriangleForm();
	}
	
	public void AddUnit(Sperm sperm)
	{
		if (!_sperms.Contains (sperm)) {
			_sperms.Add (sperm);
		}
	}
	
	public void RemoveUnit(Sperm sperm)
	{
		if (_sperms.Contains (sperm)) {
			_sperms.Remove (sperm);
		}
	}

	public void Simulate()
	{
		for (int i = 0; i < _sperms.Count; i++)
        {
		    
            Sperm sperm = _sperms[i];
            sperm.UpdateAxis(GetLeader().GetReverseDirection());
            AddRepulsionForce(sperm);
            sperm.SteerTo(GetLeader().transform.localPosition - GetLeader().GetFormPosition());
            sperm.Simulate();
            
		}
	}

    public void LineUp()
    {
        for (byte i = 0; i < _sperms.Count; i++)
        {
            Sperm sperm = _sperms[i];
			sperm.formIndex = _form.GetEmptyFormIndex(i);
			//Debug.Log(sperm.formIndex);
			_form.Occupy(sperm.formIndex);
			sperm.SetAxisPosition(_form.GetMoveDirection() * -1f, _form.GetFormPositionByIndex(sperm.formIndex));
            sperm.UpdateWorldOriginalPosition(GetLeader().transform.localPosition - GetLeader().GetFormPosition());
            sperm.Steer(_form.GetMoveDirection(), 1f);
        }
    }

	public Sperm GetLeader()
    {
        if (_sperms.Count > 0)
        {
            return _sperms[0];
        }
        return null;
    }
    public void AddRepulsionForce(Sperm sperm)
    {
        for (int i = 0; i < _sperms.Count; i++)
        {
            Sperm candidate = _sperms[i];
			if (candidate != sperm && candidate!=GetLeader() && sperm!=GetLeader())
            {
                Vector3 delta = candidate.transform.position - sperm.transform.position;
                if (delta.magnitude < .4f)
                {
					sperm.Steer(delta*-1f,.1f);
					candidate.Steer(delta,.1f);
                }
            }
        }
    }
    public bool InSight(Sperm a, Sperm b)
    {
        Vector3 distance = b.transform.localPosition - a.transform.localPosition;
        if (distance.magnitude < 3f)
        {
            float angle = Vector3.Angle(distance.normalized, a.GetDirection());
            return angle < 90f;
        }
        return false;
    }
    

	public Flock Split()
	{	
		return null;
	}

	public void Follow(Vector3 position)
	{
        
        _targetPosition = position;
        _targetPosition.z = 0;

        if (_sperms.Count>0)
        {
            GetLeader().Steer(_targetPosition - GetLeader().transform.position, .05f);
        }
	}

}
