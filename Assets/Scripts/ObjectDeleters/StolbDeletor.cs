using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StolbDeletor : MonoBehaviour
{
    private Renderer selectedRenderer=null;
    private bool selected = false;
    private GameObject selectedObject;
    private Color defaultColor = Color.white;
    private Color toDeleteColor = Color.red;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                GameObject hittedObject = hit.collider.gameObject;
                if (hittedObject.tag == "Stolb")
                {
                    if (!selected)
                    {
                        selectedRenderer = hittedObject.GetComponent<Renderer>();
                        defaultColor = selectedRenderer.material.color;
                        selectedRenderer.material.color = toDeleteColor;
                        selectedObject = hittedObject;
                        selected = true;
                    }
                    else if (selected && selectedObject == hittedObject)
                    {
                        LinkOnTile linkOnTileToDelete = hittedObject.GetComponent<LinkOnTile>();
                        linkOnTileToDelete.tileLink.tag = "FreeTile";
                        Destroy(hittedObject);
                        selectedRenderer = null;
                        selected = false;
                    }
                }

            }
        }
        else if (Input.GetKey(KeyCode.Escape))
        {
            if (selectedRenderer!= null)
            {
                selectedRenderer.material.color = defaultColor;
                selectedRenderer = null;
            }
            selectedObject = null;
            selected = false;
        }
    }
}