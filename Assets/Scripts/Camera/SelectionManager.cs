using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    private GameObject selectedObject;

    private void Update()
    {
        // Проверяем, было ли совершено нажатие мыши
        if (Input.GetMouseButtonDown(0))
        {
            // Получаем объект под указателем мыши
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {

                // Сохраняем ссылку на выбранный объект
                selectedObject = hit.collider.gameObject;

                // Вызываем метод для обработки выбранного объекта
                HandleSelectedObject(selectedObject);

            }
        }
    }

    private void HandleSelectedObject(GameObject obj)
    {
        // Здесь можно добавить код для обработки выбранного объекта
        Debug.Log("Click on object: " + obj.name);
    }

}
