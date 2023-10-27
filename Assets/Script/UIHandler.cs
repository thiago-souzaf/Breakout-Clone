using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UIHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] GameObject gameOverPanel;
    [SerializeField] TextMeshProUGUI finalScoreText;
    private void Start()
    {
        gameOverPanel.SetActive(false);
    }

    public void UpdateScoreText(int score)
    {
        scoreText.text = $"Score: {score}";
    }

    public void ShowGameOverScreen(int finalScore)
    {
        gameOverPanel.SetActive(true);
        finalScoreText.text = finalScore.ToString();

    }
}
