using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public static AudioManager instance;

	public AudioClip success;
	public AudioClip failed;
	AudioSource audioSource;

	// Use this for initialization
	void Start () 
	{
		if (instance == null)
			instance = this;
		else
			Destroy (gameObject);

		audioSource = GetComponent<AudioSource> ();	
	}
	
	public void PlaySuccess()
	{
		audioSource.clip = success;
		audioSource.Play ();
	}

	public void PlayFailed()
	{
		audioSource.clip = failed;
		audioSource.Play ();
	}
}
