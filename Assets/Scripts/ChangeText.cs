using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeText : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    private Blockgenerator blockgenerator;

    private void Start()
    {
        //textMeshPro.text = "����� �����";
        blockgenerator = GetComponent<Blockgenerator>();
        TextUpdate();
    }

    private void TextUpdate()
    {
        textMeshPro.text = "����� ������: " + (blockgenerator.columns * blockgenerator.rows);
    }

    void Update()
    {

    }
}
