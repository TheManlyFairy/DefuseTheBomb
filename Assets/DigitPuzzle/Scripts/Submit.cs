using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submit : MonoBehaviour {

    public void Click()
    {
        DigitPuzzleManager.instance.Check();
    }
}
