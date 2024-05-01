using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Blockgenerator : MonoBehaviour
{
    public GameObject blockPrefab;
    [SerializeField] GameObject managerBetweenScenesobj;
    public int rows;
    public int columns;
    public float differenceBetweenBlocks = 0.5f;

    void Start()
    {
        // Получаем объект DataManagerBetweenScenes
        DataManagerBetweenScenes managerBetweenScenes = managerBetweenScenesobj.GetComponent<DataManagerBetweenScenes>();

        // Обновляем значения rows и columns
        rows = managerBetweenScenes.getScore();
        columns = managerBetweenScenes.getScore();

        // Генерируем поле
        GenerateField(rows, columns);
    }

    private void GenerateField(int rows, int columns)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Vector3 position = new Vector3(j * differenceBetweenBlocks, 0.0f, i * differenceBetweenBlocks);

                GameObject block = Instantiate(blockPrefab, position, Quaternion.identity);
                block.name = "Tile_" + (i + 1) + "_" + (j + 1);
                block.SetActive(true);
            }
        }
    }
}
