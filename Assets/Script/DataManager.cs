using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }

    public string currentUser;
    public int bestScorePoints { get; private set; }
    public string bestScoreName { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadScore();
        } else
        {
            Destroy(gameObject);
        }
    }

    public void SetNewBestScore(int score)
    {
        bestScoreName = currentUser;
        bestScorePoints = score;

        SaveScore();
    }

    [System.Serializable]
    class BestScore
    {
        public int points;
        public string name;
    }

    private void SaveScore()
    {
        BestScore bestScore = new();
        bestScore.points = this.bestScorePoints;
        bestScore.name = this.bestScoreName;

        string json = JsonUtility.ToJson(bestScore);
        File.WriteAllText(Application.persistentDataPath + "/bestScore.json", json);
    }

    private void LoadScore()
    {
        string path = Application.persistentDataPath + "/bestScore.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            BestScore bestScore = JsonUtility.FromJson<BestScore>(json);

            this.bestScoreName = bestScore.name;
            this.bestScorePoints = bestScore.points;
        }
    }

}
