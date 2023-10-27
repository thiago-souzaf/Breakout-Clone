using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI bestScoreText;
    [SerializeField] TMP_InputField userNameInput;


    private void Start()
    {
        bestScoreText.text = $"Best Score: {DataManager.Instance.bestScoreName} - {DataManager.Instance.bestScorePoints}";
    }
    public void StartGame()
    {
        DataManager.Instance.currentUser = userNameInput.text;
        SceneManager.LoadScene(1); // Loads main scene
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
