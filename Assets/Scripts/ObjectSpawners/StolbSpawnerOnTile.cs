using UnityEngine;

public class StolbSpawnerOnTile : MonoBehaviour
{
    public GameObject objectToSpawn;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // �������� ������ �� ������, �� ������� ����� ���
                GameObject hitObject = hit.collider.gameObject;

                if (hitObject.tag == "FreeTile")
                {
                    // ����� ��������� �������������� �������� � ��������, �� ������� ����� ���
                    hitObject.tag = "OccupedTile";

                    Transform hitTransform = hit.transform;

                    Vector3 spawnPosition = hitTransform.position + new Vector3(0, 1, 0);
                    GameObject newObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
                    newObject.transform.Rotate(-90, 0, 0);
                    Debug.Log("Object " + objectToSpawn.name + " spawned on object " + hitObject.name);

                }
            }
        }
    }
}
