using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyCamera : MonoBehaviour
{
    private Transform transform;
    public int speed = 10;

    private void Start()
    {
        transform = GetComponent<Transform>();
    }

    private void Update()
    {
        float verticalInput = Input.GetAxis("Vertical"); // �������� ���� �� ��������� (W � S ��� �������� ������ � �����)
        float horizontalInput = Input.GetAxis("Horizontal"); // �������� ���� �� ����������� (A � D ��� �������� �� ��� Y)

        Vector3 localMovement = new Vector3(horizontalInput * speed, 0, verticalInput * speed); // ������ �������� � ��������� �����������
        Vector3 globalMovement = transform.TransformDirection(localMovement); // ����������� ������ �������� � ���������� ����������
        
        globalMovement.y = 0;

        globalMovement *= Time.deltaTime; // �������� �� deltaTime ��� ������������ �������� � ��������
        transform.position += globalMovement; // ��������� ���������� �������� � ������� ������
    }
}
