using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableConnector : MonoBehaviour
{

    //public GameObject objectToSpawn;
    Renderer renderer;
    private Color defaultColor;
    private Color newColor = Color.yellow;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        defaultColor = renderer.material.color;
    }

    void Update()
    {
/*        // Проверяем, была ли нажата левая кнопка мыши
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
                    //Debug.Log("Object " + objectToSpawn.name + " spawned on object " + hitObject.name);

                }
            }
            //}
        }*/
    }

    private void OnMouseEnter()
    {
        renderer.material.color = newColor;
    }

    private void OnMouseExit()
    {
        renderer.material.color = defaultColor;
    }

}
