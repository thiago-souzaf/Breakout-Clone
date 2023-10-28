using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    [SerializeField] GameObject brickPrefab;
    private int lineCount = 6;
    private int bricksPerLine = 9;
    private float xPosFirstInLine = -7;
    private float yPosFirstInCol = 4.5f;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void InstantiateBricks()
    {
        int[] pointValueArr = { 10, 5, 2, 2, 1, 1 };
        for (int i = 0; i < lineCount; i++)
        {
            for (int j = 0; j < bricksPerLine; j++)
            {
                Vector3 position = new(xPosFirstInLine + j * 1.75f, yPosFirstInCol + i * -0.6f);
                var brickObject = Instantiate(brickPrefab, this.transform);
                brickObject.transform.position = position;
                Brick brick = brickObject.GetComponent<Brick>();
                brick.PointValue = pointValueArr[i];
                brick.onDestroyed.AddListener(gameManager.AddScore);
                
            }
        }
    }
}
