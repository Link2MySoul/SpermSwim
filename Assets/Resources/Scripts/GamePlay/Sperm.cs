using UnityEngine;
using System.Collections;

public class Sperm : SwimCreature {


    private Vector3 direction = Vector3.zero;
    private float speed = 3f;
    private float originalSpeed = 3f;
    private Vector3 force = Vector3.zero;
    private Vector3 formPosition;
    private Vector3 axisVector;
    private Vector3 originalFormPosition;
    private Vector3 targetPosition;
	private Counter speedCircle;
	public byte formIndex;
	void Start () {
		speedCircle = new Counter (.3f+UnityEngine.Random.Range (0f, .3f));
		speedCircle.percent = UnityEngine.Random.Range (0f, 1f);
	}

	public void Simulate()
	{
		speedCircle.Tick (Time.deltaTime);
		float resistance = Mathf.Sin(speedCircle.percent*Mathf.PI);
        direction = force;
		this.transform.position += (speed + resistance * .5f) * Time.deltaTime * direction;
        
    }



    public void SetFormPosition(Vector3 position)
    {
        formPosition = position;
    }

    public Vector3 GetFormPosition()
    {
        return formPosition;
    }

    public void SetAxisPosition(Vector3 axis, Vector3 position)
    {
        axisVector = axis;
        originalFormPosition = position;
        formPosition = originalFormPosition;
    }

    public void UpdateAxis(Vector3 axis)
    {
        axisVector = axis;
        Vector3 normalAxis = Vector3.Cross(Vector3.forward, axisVector);
        formPosition = axisVector.normalized * originalFormPosition.x + normalAxis.normalized * originalFormPosition.y;
    }

    public void UpdateWorldOriginalPosition(Vector3 original)
    {
        this.transform.localPosition = original + formPosition;
    }

    public void SteerTo(Vector3 original)
    {
        targetPosition = original + formPosition;
        Vector3 delta = targetPosition - this.transform.localPosition;
		speed = (delta.magnitude > .1f) ? delta.magnitude * 1f + originalSpeed : originalSpeed;
        Steer(delta, .2f);
    }

    public void Steer(Vector3 steerForce, float weight = 1f)
    {
        force += (steerForce.normalized * weight);
        force = force.normalized;
    }
    
   
    public override Vector3 GetReverseDirection()
    {
        return -1f * direction;
    }
	public override Vector3 GetDirection()
    {
        return direction;
    }
}
