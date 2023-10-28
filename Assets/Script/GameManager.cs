using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;

    [SerializeField] UIHandler uiHandler;

    [SerializeField] BallController ballController;

    [SerializeField] BrickSpawner brickSpawner;


    public bool IsGameOver {  get; private set; }

    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        brickSpawner.InstantiateBricks();
        uiHandler.UpdateScoreText(score);
        IsGameOver = false;
        uiHandler.ShowInstructionText(true);
    }

    private void Update()
    {
        if (!IsGameOver && Input.GetKeyDown(KeyCode.Space))
        {
            ballController.ThrowBall();
            uiHandler.ShowInstructionText(false);
        }
    }

    public void AddScore(int pointsToAdd)
    {
        score += pointsToAdd;
        uiHandler.UpdateScoreText(score);

    }

    public void GameOver()
    {
        ballController.ResetPosition();
        uiHandler.ShowGameOverScreen(score);
        IsGameOver = true;
        if (score > DataManager.Instance.bestScorePoints)
        {
            DataManager.Instance.SetNewBestScore(score);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);

    }
}
