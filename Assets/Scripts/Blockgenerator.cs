using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockgenerator : MonoBehaviour
{
    public GameObject blockPrefab;
    public int rows = 10;
    public int columns = 10;
    public float differenceBetweenBlocks = 0.5f;

    void Start()
    {
        GenerateField(rows, columns);
    }

    private void GenerateField(int rows, int columns)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                //Vector3 position = new Vector3(columns * tileSize, 0.0f, rows * tileSize);
                Vector3 position = new Vector3(j * differenceBetweenBlocks, 0.0f, i * differenceBetweenBlocks);

                GameObject block = Instantiate(blockPrefab, position, Quaternion.identity);
                block.name = "Tile_" + (i+1) + "_" + (j+1);
                block.SetActive(true);

                //block.transform.position = position;
            }
        }
    }

}
