using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeManager : MonoBehaviour {

	public static CodeManager instance;

	public FirstButtonStep button1;
	public ButtonInputControl button2;
	public ButtonInputControl button3;

	public int codeNumber1;
	public int codeNumber2;
	public int codeNumber3;

	void Awake()
	{
		if (instance == null)
			instance = this;
		else
			Destroy (gameObject);

		button1.codeNumber = Random.Range(1,6);
	}

	// Use this for initialization
	void Start () 
	{
		MakeCodeNumber (button1.codeNumber);

		codeNumber1 = button1.codeNumber;
		codeNumber2 = button2.codeNumber;
		codeNumber3 = button3.codeNumber;

	}


	void MakeCodeNumber(int firstCodeNumber)
	{

		switch (firstCodeNumber) 
		{
		case 1:
			
			button2.codeNumber = firstCodeNumber + 1;
			button3.codeNumber = firstCodeNumber + 3;
			break;

		case 2:

			button2.codeNumber = firstCodeNumber + 3;
			button3.codeNumber = firstCodeNumber - 1;
			break;
		case 3:

			button2.codeNumber = firstCodeNumber - 2;
			button3.codeNumber = firstCodeNumber + 3;
			break;
		case 4:

			button2.codeNumber = firstCodeNumber + 1;
			button3.codeNumber = firstCodeNumber - 2;
			break;
		case 5:

			button2.codeNumber = firstCodeNumber + 1;
			button3.codeNumber = firstCodeNumber - 3;
			break;
		case 6:

			button2.codeNumber = firstCodeNumber - 1;
			button3.codeNumber = firstCodeNumber - 3;
			break;

		}

	}
}
