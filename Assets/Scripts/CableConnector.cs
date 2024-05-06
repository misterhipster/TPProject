using System;
using UnityEngine;

public class CableConnector : MonoBehaviour
{
    [SerializeField] GameObject toDelegatePrice;
    public GameObject selectedObject;
    public Renderer selectedObjectRenderer = null;
    public bool isObjectSelected = false;
    private Color selectColor = Color.green;
    private Color defaultColor;

    [SerializeField] GameObject cableStartPrefab;

    private void LateUpdate()
    {
        // Проверяем, было ли совершено нажатие мыши
        if (Input.GetMouseButtonDown(0))
        {
            // Получаем объект под указателем мыши
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                GameObject hittedObject = hit.collider.gameObject;

                if (!isObjectSelected && hittedObject.tag == "Stolb")
                {
                    selectedObject = hittedObject;
                    selectedObjectRenderer = selectedObject.GetComponent<Renderer>();

                    defaultColor = selectedObjectRenderer.material.color;
                    selectedObjectRenderer.material.color = selectColor;
                    isObjectSelected = true;
                }
                else if (isObjectSelected)
                {
                    Vector3 spawnPosition = selectedObject.transform.position + new Vector3(0, 3, 0);
                    // Тут вычисляем расстояние между столбами
                    Vector3 startPosition = spawnPosition;
                    Vector3 endPosition = hittedObject.transform.position + new Vector3(0, 3, 0);
                    float distance = (float)Math.Pow(
                        Mathf.Pow(startPosition.x - endPosition.x, 2) +
                        Mathf.Pow(startPosition.y - endPosition.y, 2) +
                        Mathf.Pow(startPosition.z - endPosition.z, 2), 0.5);

                    if (distance <= 12)
                    {
                        // Используем координаты selectedObject как стартовую позицию
                        GameObject newCable = Instantiate(cableStartPrefab, spawnPosition, Quaternion.identity);
                        CableProceduralStatic cableProceduralStatic = newCable.GetComponent<CableProceduralStatic>();
                        cableProceduralStatic.endPointTransform.position = hittedObject.transform.position + new Vector3(0, 3, 0);
                        
                        int price = Convert.ToInt32(distance) / 2;
                        PriceStats priceStats = toDelegatePrice.GetComponent<PriceStats>();
                        priceStats.PriceForCables += price * 1500;
                        Debug.Log(price);

                        isObjectSelected = false;
                        selectedObjectRenderer.material.color = defaultColor;
                        selectedObjectRenderer = null;
                    }
                }
            }
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            if (isObjectSelected)
            {
                if (selectedObjectRenderer)
                {
                    selectedObjectRenderer.material.color = defaultColor;
                }
            }
            isObjectSelected = false;
            selectedObjectRenderer = null;
        }

    }

}
