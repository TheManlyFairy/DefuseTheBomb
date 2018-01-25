using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeButton : MonoBehaviour, IComparable<ShapeButton> {

    ShapeButtonManager sbManager;
    AudioSource audio;
    Material ButtonLight;
    float timeToWait;
    bool isPressed;

    public int orderID;

	// Use this for initialization
	void Start ()
    {
        ButtonLight = transform.GetChild(0).GetComponent<Renderer>().material;
        isPressed = false;
        audio = GetComponent<AudioSource>();
        sbManager = ShapeButtonManager.sbManager;
	}
	
	public bool IsPressed() { return isPressed; }
    public void LightUp()
    {
        isPressed = true;
        ButtonLight.SetColor("_EmissionColor", Color.green);
        audio.Play();
    }
    public void LightOff()
    {
        isPressed = false;
        ButtonLight.SetColor("_EmissionColor", new Color(0.5f, 0.5f, 0.5f));
    }
    public void FlashRed()
    {
        ButtonLight.SetColor("_EmissionColor", new Color(1f, 0f, 0f));
    }
    public void SetButton(int id, Texture tex)
    {
        orderID = id;
        GetComponent<Renderer>().material.SetTexture("_MainTex", tex);
    }
    public int CompareTo(ShapeButton other)
    {
        throw new NotImplementedException();
    }
    
}

public class SortByOrderId : IComparer<ShapeButton>
{
    public int Compare(ShapeButton a, ShapeButton b)
    {
        return a.orderID - b.orderID;
    }
}
