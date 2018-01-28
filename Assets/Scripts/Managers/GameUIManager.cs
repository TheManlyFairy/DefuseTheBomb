using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIManager : MonoBehaviour {

    public static GameUIManager manager;
    GameObject ElementsSeenWhenZoomedIn, ElementsSeenWhenZoomedOut;
	// Use this for initialization
	void Start () {
        manager = this;

        ElementsSeenWhenZoomedIn = transform.GetChild(0).gameObject;
        ElementsSeenWhenZoomedOut = transform.GetChild(1).gameObject;

        ElementsSeenWhenZoomedIn.SetActive(false);
    }

    public static void HideGameUI()
    {
        manager.ElementsSeenWhenZoomedOut.SetActive(false);
        manager.ElementsSeenWhenZoomedIn.SetActive(false);
    }
    public static void ZoomInUI()
    {
        manager.ElementsSeenWhenZoomedIn.SetActive(true);
    }

    public static void ZoomOutUI()
    {
        manager.ElementsSeenWhenZoomedOut.SetActive(true);
    }
}
