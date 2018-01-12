using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeManager : MonoBehaviour {

	public LightSwitchColorChange button1;
	public LightSwitchColorChange button2;
	public LightSwitchColorChange button3;

	public int codeNumber1;
	public int codeNumber2;
	public int codeNumber3;

	// Use this for initialization
	void Start () 
	{
		codeNumber1 = button1.codeNumber;
		codeNumber2 = button2.codeNumber;
		codeNumber3 = button3.codeNumber;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (button1.buttonInputControll.isOnRightStep && button2.buttonInputControll.isOnRightStep && button3.buttonInputControll.isOnRightStep)
			Debug.Log ("You diffused the bomb and saved millions of lives!\nGet this man a cookie!");
		
	}
}
