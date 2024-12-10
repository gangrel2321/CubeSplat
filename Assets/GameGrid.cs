using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid : MonoBehaviour
{

    private int height = 4;
    private int width = 4;
    private float Spacing = 1.0f;

    [SerializeField] private GameObject gridCellPrefab;
    [SerializeField] private GameObject playerPrefab;
    private GameObject[,] gameGrid;
    private GameObject player; 

    // Start is called before the first frame update
    void Start()
    {
        CreateGrid();
    }

    // Update is called once per frame
    void CreateGrid()
    {
        gameGrid = new GameObject[height, width];
        player = new GameObject();
        if (gridCellPrefab == null)
        {
            Debug.LogError("Error: Grid Cell Prefab is not assigned");
            return;
        }
        if (playerPrefab == null)
        {
            Debug.LogError("Error: Player Prefab is not assigned");
            return;
        }

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                gameGrid[x, y] = Instantiate(gridCellPrefab, new Vector3(x * Spacing, 0, y * Spacing), Quaternion.identity);
                gameGrid[x, y].transform.parent = transform;
                gameGrid[x, y].gameObject.name = "Grid Space ( x: " + x.ToString() + " , z: " + y.ToString() + " )\n";
            }
        }
        float p_x = Random.Range(0, width) * Spacing;
        float p_y = Random.Range(0, height) * Spacing;
        float p_z = Spacing;
        player = Instantiate(playerPrefab, new Vector3(p_x, p_z, p_y), Quaternion.identity);
        player.transform.parent = transform;
        player.gameObject.name = "Player";
    }
}
