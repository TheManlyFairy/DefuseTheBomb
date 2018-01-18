using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

public class LightSwitchColorChange : MonoBehaviour {

	public int codeNumber;
	public ButtonInputControl buttonInputControll;

	// Use this for initialization
	void Awake () 
	{
		//codeNumber = Random.Range(1,6);
		buttonInputControll = GetComponent<ButtonInputControl> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (buttonInputControll.isOnRightStep) {
			Renderer rend = GetComponent<Renderer> ();
			rend.material.color = Color.green;
		}
		else if(!buttonInputControll.isOnRightStep && buttonInputControll.isSelected)
		{
			Renderer rend = GetComponent<Renderer> ();
			rend.material.color = Color.red;
		}
		
	}

}
