using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour {

    Color color;
    AudioSource cutSound;
    Transform cutWire, wireCover;
    bool isCut = false;

    public bool IsCut { get { return isCut; } }
    public void Colorize(Color c)
    {
        cutWire = transform.GetChild(0);
        wireCover = transform.GetChild(1);

        cutWire.GetComponent<Renderer>().material.color = c;
        wireCover.GetComponent<Renderer>().material.color = c;
        cutSound = GetComponent<AudioSource>();

        color = c;
    }

    public Color GetColor() { return color; }

    public void Cut()
    {
        isCut = true;
        cutSound.Play();
        wireCover.gameObject.SetActive(false);
    }


}
