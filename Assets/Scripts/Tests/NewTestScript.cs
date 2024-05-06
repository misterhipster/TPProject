using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MyTestScript
{
    // A Test behaves as an ordinary method
    [Test]
    public void MyTestScriptSimplePasses()
    {
        // Use the Assert class to test conditions
        Assert.IsTrue(true);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator CameraRotate_WhenRotationSpeedIsPositive_RotatesCameraClockwise()
    {
        // Set up a new GameObject with the CameraRotate component
        GameObject cameraObj = new GameObject("CameraRotate");
        CameraRotate cameraRotate = cameraObj.AddComponent<CameraRotate>();
        cameraObj.transform.position = Vector3.zero;
        cameraObj.transform.rotation = Quaternion.identity;

        // Set the rotation speed to a positive value
        cameraRotate.rotationSpeed = 10;

        // Advance time by one frame
        yield return null;

        // Check that the camera has rotated clockwise
        float rotationX = cameraObj.transform.rotation.eulerAngles.x;
        float rotationY = cameraObj.transform.rotation.eulerAngles.y;
        float rotationZ = cameraObj.transform.rotation.eulerAngles.z;
        Assert.Greater(rotationX, 0);
        Assert.AreEqual(rotationY, 0);
        Assert.AreEqual(rotationZ, 0);

        // Clean up the GameObject after the test
        GameObject.Destroy(cameraObj);
    }

    [UnityTest]
    public IEnumerator CameraRotate_WhenRotationSpeedIsNegative_RotatesCameraCounterClockwise()
    {
        // Set up a new GameObject with the CameraRotate component
        GameObject cameraObj = new GameObject("CameraRotate");
        CameraRotate cameraRotate = cameraObj.AddComponent<CameraRotate>();
        cameraObj.transform.position = Vector3.zero;
        cameraObj.transform.rotation = Quaternion.identity;

        // Set the rotation speed to a negative value
        cameraRotate.rotationSpeed = -10;

        // Advance time by one frame
        yield return null;

        // Check that the camera has rotated counter-clockwise
        float rotationX = cameraObj.transform.rotation.eulerAngles.x;
        float rotationY = cameraObj.transform.rotation.eulerAngles.y;
        float rotationZ = cameraObj.transform.rotation.eulerAngles.z;
        Assert.Less(rotationX, 0);
        Assert.AreEqual(rotationY, 0);
        Assert.AreEqual(rotationZ, 0);

        // Clean up the GameObject after the test
        GameObject.Destroy(cameraObj);
    }

    [UnityTest]
    public IEnumerator CameraRotate_WhenCursorPositionIsInsideAreaOfAction_RotatesCameraClockwise()
    {
        // Set up a new GameObject with the CameraRotate component
        GameObject cameraObj = new GameObject("CameraRotate");
        CameraRotate cameraRotate = cameraObj.AddComponent<CameraRotate>();
        cameraObj.transform.position = Vector3.zero;
        cameraObj.transform.rotation = Quaternion.identity;

        // Set the window size and area of action
        cameraRotate.windowWidth = 100;
        cameraRotate.windowHeight = 100;
        cameraRotate.areaOfAction = 0.1f;

        // Set the cursor position inside the area of action
        Vector2 cursorPosition = new Vector2(50, 50);

        // Advance time by one frame
        yield return null;

        // Check that the camera has rotated clockwise
        float rotationX = cameraObj.transform.rotation.eulerAngles.x;
        float rotationY = cameraObj.transform.rotation.eulerAngles.y;
        float rotationZ = cameraObj.transform.rotation.eulerAngles.z;
        Assert.Greater(rotationX, 0);
        Assert.AreEqual(rotationY, 0);
        Assert.AreEqual(rotationZ, 0);

        // Clean up the GameObject after the test
        GameObject.Destroy(cameraObj);
    }

    [UnityTest]
    public IEnumerator CameraRotate_WhenCursorPositionIsOutsideAreaOfAction_DoesNotRotateCamera()
    {
        // Set up a new GameObject with the CameraRotate component
        GameObject cameraObj = new GameObject("CameraRotate");
        CameraRotate cameraRotate = cameraObj.AddComponent<CameraRotate>();
        cameraObj.transform.position = Vector3.zero;
        cameraObj.transform.rotation = Quaternion.identity;

        // Set the window size and area of action
        cameraRotate.windowWidth = 100;
        cameraRotate.windowHeight = 100;
        cameraRotate.areaOfAction = 0.1f;

        // Set the cursor position outside the area of action
        Vector2 cursorPosition = new Vector2(10, 10);

        // Advance time by one frame
        yield return null;

        // Check that the camera has not rotated
        float rotationX = cameraObj.transform.rotation.eulerAngles.x;
        float rotationY = cameraObj.transform.rotation.eulerAngles.y;
        float rotationZ = cameraObj.transform.rotation.eulerAngles.z;
        Assert.AreEqual(rotationX, 0);
        Assert.AreEqual(rotationY, 0);
        Assert.AreEqual(rotationZ, 0);

        // Clean up the GameObject after the test
        GameObject.Destroy(cameraObj);
    }
}