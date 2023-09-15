using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float _panborderThickness = 10f;
    float _speed = 20f;

    // Update is called once per frame
    void Update()
    {
        if (Input.mousePosition.y >= Screen.height - _panborderThickness || Input.GetKey(KeyCode.W))
            transform.position += Vector3.forward * _speed * Time.deltaTime;
        
        if (Input.mousePosition.y <= _panborderThickness || Input.GetKey(KeyCode.S))
            transform.position += Vector3.back * _speed * Time.deltaTime;
        
        if (Input.mousePosition.x >= Screen.width - _panborderThickness || Input.GetKey(KeyCode.D))
            transform.position += Vector3.right * _speed * Time.deltaTime;
        
        if (Input.mousePosition.x <= _panborderThickness || Input.GetKey(KeyCode.A))
            transform.position += Vector3.left * _speed * Time.deltaTime;
    }
}
