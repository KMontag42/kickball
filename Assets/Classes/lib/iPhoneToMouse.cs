using UnityEngine;
using System.Collections;

public class iPhoneToMouse
{
	public int touchCount
	{
		get
		{
			if(Input.GetMouseButton(0) || Input.GetMouseButton(1) || 
			   Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1) )
				return 1;
			else
				return 0;
		}
	}
	
	
	public pos GetTouch(int ID)
	{
		pos tempPos = new pos();
		
		tempPos.position = Input.mousePosition;
		
		if(Input.GetMouseButtonDown(ID))
			tempPos.phase = iPhoneTouchPhase.Began;
		else if(Input.GetMouseButton(ID))
			tempPos.phase = iPhoneTouchPhase.Moved;
		
		if(Input.GetMouseButtonUp(ID))
			tempPos.phase = iPhoneTouchPhase.Ended;
		
		return tempPos;
	} 
	
	
	public struct pos
	{
		public Vector2 position;
		public iPhoneTouchPhase phase;
	}
}


public enum iPhoneTouchPhase
{
	Moved,
	Ended,
	Began
}