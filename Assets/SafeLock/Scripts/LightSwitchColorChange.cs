using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

public class LightSwitchColorChange : MonoBehaviour {


	FirstButtonStep button1;
	ButtonInputControl button2;
	ButtonInputControl button3;

	Renderer rend;

	// Update is called once per frame
	void Start () 
	{
		button1 = CodeManager.instance.button1;
		button2 = CodeManager.instance.button2;
		button3 = CodeManager.instance.button3;

	}

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
		}
	

		else 
		{
			StartCoroutine (SwitchToRed());
		}
			
	}

	IEnumerator SwitchToRed()
	{
		rend = button1.GetComponent<Renderer> ();
		rend.material.color = Color.red;

		rend = button2.GetComponent<Renderer> ();
		rend.material.color = Color.red;

		rend = button3.GetComponent<Renderer> ();
		rend.material.color = Color.red;

		yield return new WaitForSeconds(1);

		rend = button1.GetComponent<Renderer> ();
		rend.material.color = Color.white;

		rend = button2.GetComponent<Renderer> ();
		rend.material.color = Color.white;

		rend = button3.GetComponent<Renderer> ();
		rend.material.color = Color.white;
	}
	
}
