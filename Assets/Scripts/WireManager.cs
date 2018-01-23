using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireManager : MonoBehaviour {

    public Wire prefabWire;
    public WireManager wireManager;
    public float wireHeight;
    public float spaceBetweenWires;

    Wire[] instWires;
    Color[] colors = { Color.red, Color.blue, Color.yellow, Color.white, Color.black };
    int wireToCut;

	
    // Use this for initialization
	void Start ()
    {
        if(wireManager==null)
        {
            wireManager = this;
            CreateWires();
            CalculateWireToCut();
            Debug.Log("cut wire number " + (wireToCut + 1));
        }
        else
        {
            Destroy(this.gameObject);
        }
        this.enabled = false;
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
                if(instWires[wireToCut].Equals(hit.collider.gameObject.GetComponent<Wire>()))
                {
                    Debug.Log("Correct");
                }
                else
                {
                    Debug.Log("False");
                }
            }
        }	
	}
    void CreateWires()
    {
        int amountOfWires = Random.Range(4, 7);
        float firstWirePosY = transform.position.y + ((amountOfWires - 1) * 0.3f);
        Vector2 pos;
        instWires = new Wire[amountOfWires];
        
        for (int i=0; i<instWires.Length; i++)
        {
            pos = new Vector2(transform.position.x, firstWirePosY + (spaceBetweenWires * i));
            instWires[i] = Instantiate(prefabWire, pos, transform.rotation);
            instWires[i].Colorize(colors[Random.Range(0, colors.Length)]);
            instWires[i].transform.localScale = new Vector3(instWires[i].transform.localScale.x, wireHeight, instWires[i].transform.localScale.z);
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
        if(instWires[instWires.Length-1].GetColor() == Color.black)
        {
            wireToCut = 3;
        }
        else if (CountRedWires() == 1 && CountYellowWires() > 1)
        {
            wireToCut = 0;
        }
        else if (CountBlackWires() == 0)
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
    int CountBlackWires()
    {
        int count = 0;
        for (int i = 0; i < instWires.Length; i++)
        {
            if (instWires[i].GetColor() == Color.black)
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
}
