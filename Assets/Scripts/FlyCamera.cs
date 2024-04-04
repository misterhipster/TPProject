using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyCamera : MonoBehaviour
{
    private Transform transform;
    public int asd = 0;

    void Start()
    {
        transform = GetComponent<Transform>();
    }

    void Update()
    {
/*        // Получаем позицию курсора мыши в экранных координатах
        Vector2 cursorPosition = Input.mousePosition;

        // Конвертируем экранные координаты в координаты относительно видимой области экрана
        Vector2 viewportPosition = Camera.main.ScreenToViewportPoint(cursorPosition);

        // Получаем координаты относительно игрового окна
        Vector2 windowPosition = new Vector2(viewportPosition.x * Screen.width, viewportPosition.y * Screen.height);

        // Выводим координаты в консоль
        Debug.Log("Cursor Position: " + windowPosition);
*/
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position = new Vector3((float)transform.position.x, (float)transform.position.y, (float)transform.position.z + 1);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position = new Vector3((float)transform.position.x - 1, (float)transform.position.y, (float)transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position = new Vector3((float)transform.position.x, (float)transform.position.y, (float)transform.position.z - 1);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position = new Vector3((float)transform.position.x+1, (float)transform.position.y, (float)transform.position.z);
        }
    }
}
