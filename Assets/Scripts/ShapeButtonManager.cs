﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeButtonManager : MonoBehaviour {

    public static ShapeButtonManager sbManager;
    public List<Texture> textures;
    public List<ShapeButton> buttons;
    static List<ShapeButton> staticButtons;
    Dictionary<Texture, int> dict;
    static int nextButton;
    public bool isFocused;

    void Awake () 
    {
        if (sbManager == null)
        {
            InitDictionary(); // for storing each textures and its order ID
            ShuffleTextures(); // shuffles the texture list
            InitButtons(); // initiate four buttons with random textures
            staticButtons = buttons;
            nextButton = 0;
            sbManager = this;
            isFocused = true;
        }
            
        else
            Destroy(this.gameObject);
    }

    void InitButtons()
    {
        //buttons = new ShapeButton[4];
        for (int i=0; i< buttons.Count; i++)
        {
            buttons[i].SetButton(dict[textures[i]], textures[i]);
        }

        buttons.Sort(new SortByOrderId());
    }
    void InitDictionary()
    {
        dict = new Dictionary<Texture, int>();
        for (int i = 0; i < textures.Count; i++)
        {
            dict.Add(textures[i], i);
        }
    }
    void ShuffleTextures()
    {
        int length = textures.Count;
        for (int i = 0; i < length; i++)
        {
            int random = i + Random.Range(0, length - i);
            Texture t = textures[random];
            textures[random] = textures[i];
            textures[i] = t;
        }
    }

    public static void CheckPressOrder(int buttonId)
    {
       if (buttonId == staticButtons[nextButton].orderID)
        {
            
            staticButtons[nextButton].LightUp();
            nextButton++;
        }
        else
        {
            ResetAllButtons();
            nextButton = 0;
        }
    }
    public static void ResetAllButtons()
    {
       for (int i=0; i<staticButtons.Count; i++)
        {
            staticButtons[i].LightOff();
        }
        nextButton = 0;
    }
}
