using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuManager : MonoBehaviour {

	public static UIMenuManager instance;

	// Use this for initialization
	void Awake () 
	{

		if (instance == null)
			instance = this;
		else
			Destroy (gameObject);
	}

	void Update()
	{
		if(Input.GetKey(KeyCode.Escape))
			SceneManager.LoadScene("Main");
	}

	public void NewGame()
	{
		SceneManager.LoadScene ("GameScene");
	}

	public void QuitGame()
	{
		Application.Quit ();
	}

}
