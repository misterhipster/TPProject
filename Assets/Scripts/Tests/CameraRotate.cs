using System;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    private Transform transform;
    public int windowHeight = Screen.height;
    public int windowWidth = Screen.width;
    public int rotationSpeed;
    private int maxAngleCameraRotationX = 50;
    private int minAngleCameraRotationX = 5;
    // Percentage for this parametr;
    public float areaOfAction = 0.1f;

    private void Start()
    {
        try
        {
            transform = GetComponent<Transform>();
        }
        catch (Exception e)
        {
            Debug.LogError("Error getting transform component: " + e.Message);
        }
    }

    private void Update()
    {
        Vector2 cursorPosition = new Vector2(Input.mousePosition.x - (Screen.width - windowWidth) / 2,
            Input.mousePosition.y - (Screen.height - windowHeight) / 2);
        float rotationX = 0f;
        float rotationY = 0f;
        if (cursorPosition.y < ((windowHeight / 100) * areaOfAction) && Math.Abs(transform.rotation.eulerAngles.x) < (maxAngleCameraRotationX))
        {
            try
            {
                rotationX = rotationSpeed;
            }
            catch (Exception e)
            {
                Debug.LogError("Error setting rotationX: " + e.Message);
            }
        }
        else if (cursorPosition.y > ((windowHeight / 100) * (100 - areaOfAction)) && Math.Abs(transform.rotation.eulerAngles.x) > (minAngleCameraRotationX))
        {
            try
            {
                rotationX = -rotationSpeed;
            }
            catch (Exception e)
            {
                Debug.LogError("Error setting rotationX: " + e.Message);
            }
        }
        else if (cursorPosition.x > (windowWidth / 100) * (100 - areaOfAction))
        {
            try
            {
                rotationY = rotationSpeed;
            }
            catch (Exception e)
            {
                Debug.LogError("Error setting rotationY: " + e.Message);
            }
        }
        else if (cursorPosition.x < (windowWidth / 100) * areaOfAction)
        {
            try
            {
                rotationY = -rotationSpeed;
            }
            catch (Exception e)
            {
                Debug.LogError("Error setting rotationY: " + e.Message);
            }
        }
        Vector3 newRotation = new Vector3(rotationX, rotationY, 0);
        try
        {
            //transform.Rotate(newRotation * Time.deltaTime, Space.World);
            transform.eulerAngles += newRotation * Time.deltaTime;
        }
        catch (Exception e)
        {
            Debug.LogError("Error rotating camera: " + e.Message);
        }
    }
}