using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSelectionController : MonoBehaviour {

	public ButtonInputControl selectedObject;

	RaycastHit hit;

	// Update is called once per frame
	void FixedUpdate () 
	{
		if (Input.touchCount > 0) 
		{
			Touch touch = Input.GetTouch (0);

			Ray ray = Camera.main.ScreenPointToRay (touch.position);

			if (Physics.Raycast (ray, out hit) && touch.phase == TouchPhase.Ended) {

				if (hit.collider.GetComponent<ButtonInputControl>()) 
				{
					ButtonInputControl hitObject = hit.collider.gameObject.GetComponent<ButtonInputControl>();
					SelectedButton (hitObject);
				}
			}
		}
	}

	public void SelectedButton(ButtonInputControl obj)
	{
		
		if (selectedObject != null)
		{
			if (selectedObject == obj)
				return;
		
			ClearSelection();
		}
		selectedObject = obj;

		Renderer rend = selectedObject.GetComponent<Renderer> ();
		rend.material.color = Color.red;
		selectedObject.isSelected = true;
	}

	public void ClearSelection()
	{
		Renderer rend = selectedObject.GetComponent<Renderer> ();
		rend.material.color = Color.white;
		selectedObject.isSelected = false;
		selectedObject = null;

	}
}
