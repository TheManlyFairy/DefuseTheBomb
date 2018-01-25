using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {

    [SerializeField]
    Text text;

    private void Start()
    {
        if (text == null)
            text = gameObject.GetComponent<Text>();
    }

    public void Click()
    {
        int digit = int.Parse(text.text);
        digit++;
        if (digit > 9)
            digit = 0;
        text.text = digit.ToString();
    }
}
