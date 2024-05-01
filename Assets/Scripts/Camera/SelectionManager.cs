using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    private GameObject selectedObject;

    private void Update()
    {
        // ���������, ���� �� ��������� ������� ����
        if (Input.GetMouseButtonDown(0))
        {
            // �������� ������ ��� ���������� ����
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {

                // ��������� ������ �� ��������� ������
                selectedObject = hit.collider.gameObject;

                // �������� ����� ��� ��������� ���������� �������
                HandleSelectedObject(selectedObject);

            }
        }
    }

    private void HandleSelectedObject(GameObject obj)
    {
        // ����� ����� �������� ��� ��� ��������� ���������� �������
        Debug.Log("Click on object: " + obj.name);
    }

}
