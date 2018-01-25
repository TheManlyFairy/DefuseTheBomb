using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusCamera : MonoBehaviour {

    float timer;
    float zoomIn, zoomOut;
    bool canMove;
    Vector3 startPosition, targetPosition;
    Camera mainCamera;

	void Start ()
    {
        canMove = false;
        mainCamera = GetComponent<Camera>();

        zoomIn = 2.3f;
        zoomOut = 5f;

    }
	
	void FixedUpdate ()
    {
        
	}

    public void FocusCameraAtObject(Transform target)
    {
        startPosition = transform.position;
        targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
        StartCoroutine(ZoomIn());
    }

    public void FocusCameraAtScreen()
    {
        startPosition = transform.position;
        targetPosition = new Vector3(0, 0, transform.position.z);
        StartCoroutine(ZoomOut());
    }

    IEnumerator ZoomIn()
    {
        while (timer <= 2)
        {
            timer += Time.deltaTime;
            transform.position = Vector3.Lerp(startPosition, targetPosition, timer / 2);
            mainCamera.orthographicSize = Mathf.SmoothStep(zoomOut, zoomIn, timer / 2);
            yield return null;
        }
        timer = 0;
    }

    IEnumerator ZoomOut()
    {
        while (timer <= 2)
        {
            timer += Time.deltaTime;
            transform.position = Vector3.Lerp(startPosition, targetPosition, timer / 2);
            mainCamera.orthographicSize = Mathf.SmoothStep(zoomIn, zoomOut, timer / 2);
            yield return null;
        }
        timer = 0;
    }
}
