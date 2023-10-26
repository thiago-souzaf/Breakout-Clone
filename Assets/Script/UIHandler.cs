using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UIHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    public void UpdateScoreText(int score)
    {
        scoreText.text = $"Score: {score}";
    }
}
