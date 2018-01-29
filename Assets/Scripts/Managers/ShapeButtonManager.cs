﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeButtonManager : Manager {

    public static ShapeButtonManager sbManager;
    public List<Texture> textures;
    public List<ShapeButton> buttons;

    AudioSource falseBuzzer;
    Dictionary<Texture, int> dict;
    LayerMask lightMask;
    int nextButton;

    void Awake () 
    {
        if (sbManager == null)
        {
            InitDictionary(); // for storing each textures and its order ID
            ShuffleTextures(); // shuffles the texture list
            InitButtons(); // initiate four buttons with random textures
            nextButton = 0;
            lightMask = ~(1 << 8);
            falseBuzzer = GetComponent<AudioSource>();
            sbManager = this;
            enabled = false;
        }
            
        else
            Destroy(this.gameObject);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 30f, lightMask))
            {
                if (!hit.collider.gameObject.GetComponent<ShapeButton>().IsPressed())
                {
                    CheckPressOrder(hit.collider.gameObject.GetComponent<ShapeButton>().orderID);
                    if(AllButtonsLit())
                    {
                        isPuzzleSolved = true;
                        AudioManager.instance.PlaySuccess();
                        GameManager.CheckAllPuzzles();
                    }
                }
            }
        }
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

    public void CheckPressOrder(int buttonId)
    {
       if (buttonId == buttons[nextButton].orderID)
        {
            buttons[nextButton].LightUp();
            nextButton++;
        }
        else
        {
            StartCoroutine(FlashRed());
        }
    }

    public bool AllButtonsLit()
    {
        for(int i=0; i<buttons.Count; i++)
        {
            if (!buttons[i].IsPressed())
                return false;
        }
        return true;
    }
    IEnumerator FlashRed()
    {

        TimeManager.AccelerateTime();
        falseBuzzer.Play();
        enabled = false;
        for(int i=0; i<buttons.Count; i++)
        {
            buttons[i].FlashRed();
        }

        yield return new WaitForSeconds(falseBuzzer.clip.length);
        enabled = true;
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].LightOff();
        }
        nextButton = 0;
    }
}
