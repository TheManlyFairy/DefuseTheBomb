using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    float speed;
    [SerializeField]
    float max_delta_y;

    private void Update()
    {
        float x = Input.acceleration.x * speed * Time.deltaTime;
        float z = Input.acceleration.y * speed * Time.deltaTime;
        transform.Translate(x, 0, z);
    }

    private void LateUpdate()
    {
        if (Mathf.Abs(gameObject.transform.position.y-0.5f)>max_delta_y)
            GameManager.instance.Fail();
    }
}
