using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIManager : MonoBehaviour {

    public static GameUIManager manager;
    public GameObject ElementsSeenWhenZoomedIn, ElementsSeenWhenZoomedOut;
	// Use this for initialization
	void Start () {

        manager = this;
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
