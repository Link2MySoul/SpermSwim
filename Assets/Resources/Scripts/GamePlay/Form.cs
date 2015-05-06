using UnityEngine;
using System.Collections;

public class Form  {
   	
	private int[] masks = new int[4]{0,0,0,0};
	public virtual void Occupy(byte index)
	{
		byte i = (byte)(index / 32);
		masks[i] |= (1 << index);
	}
	public virtual bool IsOccupy(byte index)
	{
		byte i = (byte)(index / 32);
		int mask = masks[i];
		return ((mask >> index) & 1) == 1;
	}
	public virtual void Free(byte index)
	{
		byte i = (byte)(index / 32);
		masks[i] &= (0 << index);
	}
	public virtual void ResetOccupy()
	{
		masks = new int[4]{0,0,0,0};
	}
  	
    public virtual Vector3 GetMoveDirection()
    {
        return Vector3.zero;
    }
	public virtual Vector3 GetFormPositionByIndex(byte index)
    {
        return Vector3.zero;
    }
	public virtual byte GetEmptyFormIndex(byte index)
	{
		return 0;
	}
}
