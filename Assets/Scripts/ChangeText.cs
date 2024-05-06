using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeText : MonoBehaviour
{
    [SerializeField] GameObject priceObject;
    PriceStats priceStats;
    public TextMeshProUGUI textMeshPro;

    private void Start()
    {
        priceStats = priceObject.GetComponent<PriceStats>();
    }

    private void FixedUpdate()
    {
        textMeshPro.text = "��������� ���������: " + (priceStats.PriceForStolbs + priceStats.PriceForCables);
    }

}
