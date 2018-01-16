using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour {

    Color color;
    public void Colorize(Color c)
    {
        GetComponent<Renderer>().material.color = c;
        color = c;
    }

    public Color GetColor() { return color; }


}
