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
        float y = Input.acceleration.y * speed * Time.deltaTime;
        transform.Translate(x, y,0);
    }

    //private void LateUpdate()
    //{
    //    if (Mathf.Abs(gameObject.transform.position.y-gameObject.GetComponent<Renderer>().bounds.size.y)>max_delta_y)
    //        MazePuzzleManager.instance.Fail();
    //}
}
