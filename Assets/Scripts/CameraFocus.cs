using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    float zoomInSize = 1.8f, zoomOutSize = 6;
    float timer = 0;
    bool canMove = false;
    Vector3 targetPos, velocity;
    Camera main;

    void Start()
    {
        main = GetComponent<Camera>();
    }

    void FixedUpdate()
    {
        if(canMove)
        {
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, 2);
        }
    }

    public void Focus(Transform t)
    {
        
        float x, y, z;
        x = t.position.x;
        y = t.position.y;
        z = transform.position.z;

        targetPos = new Vector3(x, y, z);

        canMove = true;
    }
    public void Unfocus()
    {
        targetPos = new Vector3();
        canMove = true;
    }
}
