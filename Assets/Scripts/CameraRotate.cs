using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    private Transform transform;
    private int windowHeight = Screen.height;
    private int windowWidth = Screen.width;
    public int rotationSpeed;
    private int maxAngleCameraRotationX = 50;
    private int minAngleCameraRotationX = 5;
    // Percentage for this parametr;
    private float areaOfAction = 0.1f;

    void Start()
    {
        transform = GetComponent<Transform>();   
    }

    void Update()
    {
        Vector2 cursorPosition = new Vector2(Input.mousePosition.x - (Screen.width - windowWidth) / 2,
            Input.mousePosition.y - (Screen.height - windowHeight) / 2);
        float rotationX = 0f;
        float rotationY = 0f;
        if (cursorPosition.y < ((windowHeight / 100) * areaOfAction) && Math.Abs(transform.rotation.eulerAngles.x) < (maxAngleCameraRotationX))
        {
            rotationX = rotationSpeed;
        }
        else if (cursorPosition.y > ((windowHeight / 100) * (100 - areaOfAction)) && Math.Abs(transform.rotation.eulerAngles.x) > (minAngleCameraRotationX))
        {
            rotationX = -rotationSpeed;
        }
        else if (cursorPosition.x > (windowWidth/ 100)*(100 - areaOfAction))
        {
            rotationY = rotationSpeed;
        }
        else if (cursorPosition.x < (windowWidth / 100) * (areaOfAction))
        {
            rotationY =  -rotationSpeed;
        }
        Vector3 newRotation = new Vector3(rotationX, rotationY, 0);
        //transform.Rotate(newRotation * Time.deltaTime, Space.World);
        transform.eulerAngles += newRotation * Time.deltaTime;

    }
}
