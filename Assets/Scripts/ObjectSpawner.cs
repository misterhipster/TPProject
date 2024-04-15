using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    // Объект, который будет спавниться
    public GameObject objectToSpawn;

    void Update()
    {
        // Проверяем, была ли нажата левая кнопка мыши
        if (Input.GetMouseButtonDown(0))
        {
            //if (!objectSpawned)
            //{
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Получаем ссылку на объект, на который попал луч
                GameObject hitObject = hit.collider.gameObject;

                if (hitObject.tag == "NotPlacedStolb")
                {
                    // Можно выполнить дополнительные действия с объектом, на который попал луч
                    hitObject.tag = "PlacedStolb";

                    Transform hitTransform = hit.transform;

                    Vector3 spawnPosition = hitTransform.position + new Vector3(0, 1, 0);
                    GameObject newObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
                    newObject.transform.Rotate(-90, 0, 0);
                    Debug.Log("Object " + objectToSpawn.name + " spawned on object " + hitObject.name);

                }
            }
            //}
        }
    }
}
