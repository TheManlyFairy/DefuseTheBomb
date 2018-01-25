using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submit : MonoBehaviour {

    public void Click()
    {
        GameManager.instance.Check();
    }
}
