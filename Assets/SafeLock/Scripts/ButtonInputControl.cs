using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

public class ButtonInputControl : MonoBehaviour {

	public bool isSelected;
	public uint stepNumber;
	public bool isOnRightStep;
	public int codeNumber;

	void Start () 
	{
		isSelected = false;
		isOnRightStep = false;
		stepNumber = 1;
		enabled = false;
	}
	
	void Update () 
	{
		if (isSelected) // If selected = get input
		{
			
			if (Input.touchCount > 0) {
				if (Input.GetTouch (0).phase == TouchPhase.Began) {
					if (stepNumber <= 6) {
						transform.Rotate (Vector3.down * CnInputManager.GetAxis ("Horizontal"), 60f);

						if (CnInputManager.GetAxis ("Horizontal") > 0) {
							if (stepNumber < 6)
								stepNumber++;
							else
								stepNumber = 1;
						} else if (CnInputManager.GetAxis ("Horizontal") < 0) {
							if (stepNumber > 1)
								stepNumber--;
							else
								stepNumber = 6;
						}
					}
				}
			}


		}

		// Check if the dial is on the right step
		if (stepNumber == codeNumber)
			isOnRightStep = true;
		else
			isOnRightStep = false;
	}
}
