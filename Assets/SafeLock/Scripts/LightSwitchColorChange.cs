using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

public class LightSwitchColorChange : MonoBehaviour {


	FirstButtonStep button1;
	ButtonInputControl button2;
	ButtonInputControl button3;

	Renderer rend;

	void Start () 
	{
		//Get buttons from CodeManager
		button1 = CodeManager.instance.button1;
		button2 = CodeManager.instance.button2;
		button3 = CodeManager.instance.button3;

	}

	// Switches dial color between Green and Red 
	// If all dials are on right step, color = Green
	// If one of the dials isn't on the right step, color = Red
	public void SwitchColor() 
	{

		if (CodeManager.instance.button2.isOnRightStep && CodeManager.instance.button3.isOnRightStep) {
			Debug.Log ("Good job");
			rend = button1.GetComponent<Renderer> ();
			rend.material.color = Color.green;

			rend = button2.GetComponent<Renderer> ();
			rend.material.color = Color.green;

			rend = button3.GetComponent<Renderer> ();
			rend.material.color = Color.green;

			CodeManager.instance.isPuzzleSolved = true;

			AudioManager.instance.PlaySuccess ();
		}
	

		else 
		{
			StartCoroutine (SwitchToRed());
		}
			
	}

	IEnumerator SwitchToRed() // Switches dial colors to Red for 1 second
	{
		rend = button1.GetComponent<Renderer> ();
		rend.material.color = Color.red;

		rend = button2.GetComponent<Renderer> ();
		rend.material.color = Color.red;

		rend = button3.GetComponent<Renderer> ();
		rend.material.color = Color.red;

		TimeManager.AccelerateTime ();
		CodeManager.instance.isPuzzleSolved = false;
		AudioManager.instance.PlayFailed ();

		yield return new WaitForSeconds(1);

		rend = button1.GetComponent<Renderer> ();
		rend.material.color = Color.white;

		rend = button2.GetComponent<Renderer> ();
		rend.material.color = Color.white;

		rend = button3.GetComponent<Renderer> ();
		rend.material.color = Color.white;
	}
	
}
