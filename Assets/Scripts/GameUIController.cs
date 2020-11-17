using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using  UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    public static GameUIController Instance = null;

    [SerializeField] private Canvas scoreCanvas;
    [SerializeField] private Canvas gameOverCanvas;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text hiScoreText;
    [SerializeField] private Text livesText;
    [SerializeField] private Canvas mobileControllerCanvas;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        PlayerData.Instance.ScoreChanged += UpdateScoreText;
        UpdateScoreText(PlayerData.Instance.Score);
        PlayerData.Instance.HiScoreChanged += UpdateHiScoreText;
        UpdateHiScoreText(PlayerData.Instance.HighScore);
        PlayerData.Instance.CurrentLivesChanged += UpdateLivesText;
        UpdateLivesText(PlayerData.Instance.Lives);

#if UNITY_STANDALONE
        mobileControllerCanvas.gameObject.SetActive(false);
#elif UNITY_ANDROID || UNITY_IOS
mobileControllerCanvas.gameObject.SetActive(true);
#endif
    }

    public void UpdateScoreText(int score)
    {
        scoreText.text = score.ToString();
    }

    public void UpdateHiScoreText(int hiscore)
    {
        hiScoreText.text = hiscore.ToString();
    }

    public void UpdateLivesText(int newlives)
    {
        livesText.text = newlives.ToString();
    }

    public void ShowGameOverCanvas(bool state)
    {
        gameOverCanvas.gameObject.SetActive(state);
    }

    public void OnExitButtonClicked()
    {
         Application.Quit();
    }

    public void OnRestartButtonClicked()
    {
      GameManger.Instance.StartNewGame();
      ShowGameOverCanvas(false);
    }
    private void OnDestroy()
    {
        PlayerData.Instance.ScoreChanged -= UpdateScoreText;
        PlayerData.Instance.HiScoreChanged -= UpdateHiScoreText;
    }

    void Update()
    {
        
    }
}
