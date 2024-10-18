using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    public Transform camPos;
    public Transform orientation;

    public float sens;
    float xRotation;
    float yRotation;
    float sensX;
    float sensY;
    void Start()
    {
        sensX = sens; 
        sensY = sens;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = camPos.position;

        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
