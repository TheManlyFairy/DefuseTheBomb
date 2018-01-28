using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusCamera : MonoBehaviour {

    float timer;
    float zoomOut, zoomIn;
    bool canMove;
    Vector3 startPosition, targetPosition;
    Camera mainCamera;
    Manager focusedManager;

	void Start ()
    {
        canMove = false;
        mainCamera = Camera.main;

        zoomIn = 2.3f;
        zoomOut = mainCamera.orthographicSize;

    }

    public void FocusCameraAtManager(Manager m)
    {
        focusedManager = m;
        startPosition = transform.position;
        targetPosition = new Vector3(focusedManager.transform.position.x, focusedManager.transform.position.y, transform.position.z);
        //zoomIn = zoom;
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
        GameUIManager.HideGameUI();
        while (timer <= 2)
        {
            timer += Time.deltaTime;
            transform.position = Vector3.Lerp(startPosition, targetPosition, timer / 2);
            mainCamera.orthographicSize = Mathf.SmoothStep(zoomOut, zoomIn, timer / 2);
            yield return null;
        }
        timer = 0;
        focusedManager.enabled = true;
        GameUIManager.ZoomInUI();
    }

    IEnumerator ZoomOut()
    {
        GameUIManager.HideGameUI();
        focusedManager.enabled = false;
        while (timer <= 2)
        {
            timer += Time.deltaTime;
            transform.position = Vector3.Lerp(startPosition, targetPosition, timer / 2);
            mainCamera.orthographicSize = Mathf.SmoothStep(zoomIn, zoomOut, timer / 2);
            yield return null;
        }
        timer = 0;
        GameUIManager.ZoomOutUI();
    }

    
}
