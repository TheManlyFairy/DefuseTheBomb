using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

public class ButtonInputControl : MonoBehaviour {

	public bool isSelected;
	public uint stepNumber;
	public bool isOnRightStep;
	public int codeNumber;

	// Use this for initialization
	void Start () 
	{
		isSelected = false;
		isOnRightStep = false;
		stepNumber = 1;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isSelected) {
			
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

		if (stepNumber == codeNumber)
			isOnRightStep = true;
		else
			isOnRightStep = false;
	}
}
