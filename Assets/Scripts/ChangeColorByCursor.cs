using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorByCursor : MonoBehaviour
{
    private Renderer renderer;
    private Color defaultColor;
    private Color newColor = Color.yellow;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        defaultColor = renderer.material.color;
    }

    private void OnMouseEnter()
    {
        renderer.material.color=newColor;
    }

    private void OnMouseExit()
    {
        renderer.material.color=defaultColor;
    }
}
