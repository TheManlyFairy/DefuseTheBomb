using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

    public static TimeManager timeManager;
    public int minutes, seconds;

    AudioSource timerRush;
    Text timerText;
    float countdownDelay;

	// Use this for initialization
	void Start ()
    {
        if (timeManager == null)
        {
            timeManager = this;

            timerText = GetComponent<Text>();
            timerRush = GetComponent<AudioSource>();

            countdownDelay = 1f;
            Time.timeScale = 1;

            StartCoroutine(Countdown());
        }
        else
        {
            Destroy(timerText.gameObject);
            Destroy(this.gameObject);
        }
	}

    IEnumerator Countdown()
    {
        while (!(minutes == 0 && seconds == 0))
        {
            yield return new WaitForSeconds(countdownDelay);
            seconds--;
            if (seconds < 0)
            {
                seconds = 59;
                minutes--;
            }
            if (minutes == 0 && seconds <= 15)
            {
                Debug.Log("Sounds");
                timerRush.Play();
            }

            timerText.text = DigitalTimeDisplay();
        }
    }
    string DigitalTimeDisplay()
    {
        string secondString, minuteString;
        if (seconds < 10)
            secondString = "0" + seconds;
        else
            secondString = "" + seconds;

        if (minutes < 10)
            minuteString = "0" + minutes;
        else
            minuteString = "" + minutes;

        return minuteString + ":" + secondString;
    }

}
