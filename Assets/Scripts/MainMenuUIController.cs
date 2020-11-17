using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUIController : MonoBehaviour
{
    [SerializeField] private Text hiScoreText;
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;
    void Start()
    {
        hiScoreText.text = PlayerData.Instance.HighScore.ToString();
       startButton.onClick.AddListener(OnStartClicked);
       exitButton.onClick.AddListener(OnExitClicked);
    }

    public void OnStartClicked()
    {
        SceneManager.LoadScene(1);
    }

    public void OnExitClicked()
    {
        Application.Quit();
    }
  
}
