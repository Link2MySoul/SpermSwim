using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TriangleForm : Form {
    private float gap = .5f;
    public override Vector3 GetMoveDirection()
    {
        return Vector3.left;
    }

	public override Vector3 GetFormPositionByIndex(byte index)
    {
		byte iPosition = 0;
		byte seg = 0;
		int iGrid = 0;
        while (iPosition <= index)
        {
			++seg;
            iPosition += seg;
        }
        iGrid = (seg - iPosition + index);
        float x = (float)seg * gap;
        float y = ((float)seg / 2f) * gap - (float)iGrid * gap;
        return new Vector3(x, y, 0);
    }

	public override byte GetEmptyFormIndex(byte index)
	{
		byte iPosition = 0;
		byte seg = 0;
		byte iForm = 0;
		while (iPosition <= index)
		{
			++seg;
			iPosition += seg;
		}

		iForm = (byte)(iPosition - seg );
		List<byte> emptys = new List<byte> ();
		while (iForm<iPosition) {
			if(!IsOccupy(iForm))
			{
				emptys.Add(iForm);
			}
			iForm++;
		}
		if (emptys.Count > 0) {
			return emptys[UnityEngine.Random.Range(0,emptys.Count)];
		} else {
			return iForm;
		}
	}
}
