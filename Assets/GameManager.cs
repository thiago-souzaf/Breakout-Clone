using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;

    [SerializeField] GameObject brickPrefab;
    private int lineCount = 6;
    private int bricksPerLine = 9;
    private float xPosFirstInLine = -7;
    private float yPosFirstInCol = 4.5f;

    [SerializeField] UIHandler uiHandler;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        InstantiateBricks();
        uiHandler.UpdateScoreText(score);
        
    }


    public void AddScore(int pointsToAdd)
    {
        score += pointsToAdd;
        uiHandler.UpdateScoreText(score);

    }

    private void InstantiateBricks()
    {
        int[] pointValueArr = { 10, 5, 2, 2, 1, 1 };
        for (int i = 0; i < lineCount; i++)
        {
            for (int j = 0; j < bricksPerLine; j++)
            {
                Vector3 position = new(xPosFirstInLine + j * 1.75f, yPosFirstInCol + i * -0.6f);
                var brickObject = Instantiate(brickPrefab, position, Quaternion.identity);
                Brick brick = brickObject.GetComponent<Brick>();
                brick.PointValue = pointValueArr[i];
                brick.onDestroyed.AddListener(AddScore);
            }
        }
        
    }

    
}
