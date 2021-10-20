using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    public float speed = 2.0f;

    void Start()
    {
        
    }


    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
}
