using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WireManager : Manager {

    public static WireManager wireManager;
    public Wire prefabWire;
    public float wireScale;
    public float spaceBetweenWires;

    Wire[] instWires;
    Color[] colors = { Color.red, Color.blue, Color.yellow, Color.white, Color.green };
    int wireToCut;

	
    // Use this for initialization
	void Start ()
    {
        if(wireManager==null)
        {
            wireManager = this;
            CreateWires();
            CalculateWireToCut();
            enabled = false;
        }
        else
        {
            Destroy(this.gameObject);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 100))
            {
                Wire clickedWire = hit.transform.parent.GetComponent<Wire>();
                if (!clickedWire.IsCut)
                {
                    clickedWire.Cut();
                    if (instWires[wireToCut].Equals(clickedWire))
                    {
                        isPuzzleSolved = true;
                        AudioManager.instance.PlaySuccess();
                        GameManager.CheckAllPuzzles();
                    }
                    else
                    {
                        AudioManager.instance.PlayFailed();
                        TimeManager.AccelerateTime();
                    }
                }
            }
        }	
	}
    void CreateWires()
    {
        int amountOfWires = Random.Range(4, 7);
        float firstWirePosY = transform.position.y + ((amountOfWires - 1) * 0.3f);
        Vector3 pos;
        instWires = new Wire[amountOfWires];
        
        for (int i=0; i<instWires.Length; i++)
        {
            pos = new Vector3(transform.position.x, firstWirePosY + (spaceBetweenWires * i), transform.position.z);
            instWires[i] = Instantiate(prefabWire, pos, transform.rotation);
            instWires[i].Colorize(colors[Random.Range(0, colors.Length)]);
            instWires[i].transform.parent = gameObject.transform;
            instWires[i].transform.localScale *= wireScale;
        }
    }
    void CalculateWireToCut()
    {
        switch(instWires.Length)
        {
            case 4:
                CalculateWireToCutFrom4Wires();break;
            case 5:
                CalculateWireToCutFrom5Wires(); break;
            case 6:
                CalculateWireToCutFrom6Wires(); break;
        }

        Debug.Log("cut wire number " + (wireToCut+1));
    }
    void CalculateWireToCutFrom4Wires()
    {

        if (CountRedWires() > 1)//If there is more than one red wire
        {
            SetWireToLastRed();// Cut the last red wire
        }
        else if(instWires[instWires.Length-1].GetColor() == Color.yellow || CountRedWires() == 0) //Otherwise, if the last wire is yellow and there are no red wires
        {
            wireToCut = 0; // cut the first wire
        }
        else if(CountBlueWires() == 1) // Otherwise, if there is exactly one blue wire
        {
            wireToCut = 0;// cut the first wire
        }
        else if(CountYellowWires() > 1) //Otherwise, if there is more than one yellow wire
        {
            wireToCut = instWires.Length - 1; //cut the last wire
        }
        else
        {
            wireToCut = 1; //Otherwise, cut the second wire.
        }
    }
    void CalculateWireToCutFrom5Wires()
    {
        if(instWires[instWires.Length-1].GetColor() == Color.green)
        {
            wireToCut = 3;
        }
        else if (CountRedWires() == 1 && CountYellowWires() > 1)
        {
            wireToCut = 0;
        }
        else if (CountgreenWires() == 0)
        {
            wireToCut = 1;
        }
        else
        {
            wireToCut = 0;
        }
    }
    void CalculateWireToCutFrom6Wires()
    {
        if (CountYellowWires() == 0)
        {
            wireToCut = 2;
        }
        else if (CountYellowWires() == 1 && CountWhiteWires() > 1)
        {
            wireToCut = 3;
        }
        else if (CountRedWires() == 0)
        {
            wireToCut = instWires.Length - 1;
        }
        else
        {
            wireToCut = 3;
        }
    }

    #region wire counting methods
    int CountRedWires()
    {
        int count = 0;
        for(int i=0; i<instWires.Length; i++)
        {
            if (instWires[i].GetColor() == Color.red)
                count++;
        }
        return count;
    }
    int CountBlueWires()
    {
        int count = 0;
        for (int i = 0; i < instWires.Length; i++)
        {
            if (instWires[i].GetColor() == Color.blue)
                count++;
        }
        return count;
    }
    int CountYellowWires()
    {
        int count = 0;
        for (int i = 0; i < instWires.Length; i++)
        {
            if (instWires[i].GetColor() == Color.yellow)
                count++;
        }
        return count;
    }
    int CountgreenWires()
    {
        int count = 0;
        for (int i = 0; i < instWires.Length; i++)
        {
            if (instWires[i].GetColor() == Color.green)
                count++;
        }
        return count;
    }
    int CountWhiteWires()
    {
        int count = 0;
        for (int i = 0; i < instWires.Length; i++)
        {
            if (instWires[i].GetColor() == Color.white)
                count++;
        }
        return count;
    }
    void SetWireToLastRed()
    {
        for (int i = 0; i < instWires.Length; i++)
        {
            if (instWires[i].GetColor() == Color.red)
                wireToCut = i;
        }
    }
    #endregion
}
