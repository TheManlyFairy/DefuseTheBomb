using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstButtonStep : MonoBehaviour {

	int firstButtonCodeNumber;
	public int codeNumber;

	// Use this for initialization
	void Start () 
	{
		RotateToStep (codeNumber);
	}
	
	void RotateToStep(int digit)
	{
		switch (digit) 
		{
		case 1:
			break;

		case 2:

			transform.Rotate (Vector3.down, 60f);
			break;
		case 3:

			transform.Rotate (Vector3.down, 120f);
			break;
		case 4:

			transform.Rotate (Vector3.down, 180f);
			break;
		case 5:

			transform.Rotate (Vector3.down, 240f);
			break;
		case 6:

			transform.Rotate (Vector3.down, 300f);
			break;
		}

	}
}
