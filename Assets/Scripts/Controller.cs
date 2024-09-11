using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Simple camera controller

public class Controller : MonoBehaviour
{
    public Camera m_camera;

    public float speed = 10.0f;


    // Start is called before the first frame update
    void Start()
    {
        if (m_camera == null)
        {
            m_camera = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // move the camera
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");        
        float altitude = Input.GetAxis("Altitude");

        Vector3 move = new Vector3(horizontal, altitude, vertical);
        m_camera.transform.Translate(move * speed * Time.deltaTime);

        // rotate the camera
        if (Input.GetMouseButton(1)) 
        {
            float rotationX = Input.GetAxis("Mouse X");
            float rotationY = Input.GetAxis("Mouse Y");

            m_camera.transform.Rotate(Vector3.up, -rotationX * 500 * Time.deltaTime);
            m_camera.transform.Rotate(Vector3.right, rotationY * 500 * Time.deltaTime);

        }

    }
}
