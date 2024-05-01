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
        float verticalInput = Input.GetAxis("Vertical"); // Получаем ввод по вертикали (W и S для движения вперед и назад)
        float horizontalInput = Input.GetAxis("Horizontal"); // Получаем ввод по горизонтали (A и D для движения по оси Y)

        Vector3 localMovement = new Vector3(horizontalInput * speed, 0, verticalInput * speed); // Вектор движения в локальных координатах
        Vector3 globalMovement = transform.TransformDirection(localMovement); // Преобразуем вектор движения в глобальные координаты
        
        globalMovement.y = 0;

        globalMovement *= Time.deltaTime; // Умножаем на deltaTime для согласования движения с фреймами
        transform.position += globalMovement; // Применяем глобальное движение к позиции камеры
    }
}
