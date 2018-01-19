using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

    public static TimeManager timeManager;
    public int minutes, seconds;
    float countdownDelay;

    Text text;

	// Use this for initialization
	void Start ()
    {
        if (timeManager == null)
            timeManager = this;
        else
        {
            Destroy(this.gameObject);
        }

        countdownDelay = 1f;

        text = GetComponent<Text>();

        StartCoroutine(Countdown());
	}
	
	// Update is called once per frame
	void Update ()
    {
        
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

            text.text = DigitalTimeDisplay();
        }
    }

    public string DigitalTimeDisplay()
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
