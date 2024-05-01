using UnityEngine;

public class CableConnector : MonoBehaviour
{
    public GameObject selectedObject;
    public Renderer selectedObjectRenderer;
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
                GameObject hittedObject= hit.collider.gameObject;

                if (!isObjectSelected && hittedObject.tag=="Stolb")
                {
                    selectedObject = hittedObject;
                    selectedObjectRenderer = selectedObject.GetComponent<Renderer>();

                    defaultColor = selectedObjectRenderer.material.color;
                    selectedObjectRenderer.material.color = selectColor;
                    isObjectSelected = true;
                }
                else if (isObjectSelected)
                {
                    // Используем координаты selectedObject как стартовую позицию
                    Vector3 spawnPosition = selectedObject.transform.position + new Vector3(0, 3, 0);
                    GameObject newCable = Instantiate(cableStartPrefab, spawnPosition, Quaternion.identity);

                    CableProceduralStatic cableProceduralStatic = newCable.GetComponent<CableProceduralStatic>();
                    cableProceduralStatic.endPointTransform.position = hittedObject.transform.position + new Vector3(0, 3, 0);
                    //cableProceduralStatic.endPointTransform.position += new Vector3(0, 3, 0);

                    isObjectSelected = false;
                    selectedObjectRenderer.material.color=defaultColor;
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (isObjectSelected)
            {
                selectedObjectRenderer.material.color = defaultColor;
            }
            isObjectSelected = false;
        }

    }

}
