using UnityEngine;

public class CableConnector : MonoBehaviour
{
    public GameObject selectedObject;
    public Renderer selectedObjectRenderer=null;
    public bool isObjectSelected = false;
    private Color selectColor = Color.green;
    private Color defaultColor;

    [SerializeField] GameObject cableStartPrefab;

    private void LateUpdate()
    {
        // ���������, ���� �� ��������� ������� ����
        if (Input.GetMouseButtonDown(0))
        {
            // �������� ������ ��� ���������� ����
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
                    // ���������� ���������� selectedObject ��� ��������� �������
                    Vector3 spawnPosition = selectedObject.transform.position + new Vector3(0, 3, 0);
                    GameObject newCable = Instantiate(cableStartPrefab, spawnPosition, Quaternion.identity);

                    CableProceduralStatic cableProceduralStatic = newCable.GetComponent<CableProceduralStatic>();
                    cableProceduralStatic.endPointTransform.position = hittedObject.transform.position + new Vector3(0, 3, 0);
                    //cableProceduralStatic.endPointTransform.position += new Vector3(0, 3, 0);

                    isObjectSelected = false;
                    selectedObjectRenderer.material.color=defaultColor;
                    selectedObjectRenderer = null;
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
