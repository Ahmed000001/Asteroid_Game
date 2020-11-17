using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Persistence;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private int maxPlayerLives=3;

    
    public static PlayerData Instance;
    private int _hiscore;
    private int _score;
    private int _lives;
    public event Action<int> ScoreChanged;
    public event Action<int> HiScoreChanged;
    public event Action<int> CurrentLivesChanged; 
    public int HighScore
    {
        get { return _hiscore;}
      private  set
        {
            _hiscore = value;
            HiScoreChanged?.Invoke(_hiscore);
            PlayerPrefs.SetString("HiScore",_hiscore.ToString());
            
        }
    }

    public int Score
    {
        get { return _score; }
        set
        {
            _score = value;
            ScoreChanged?.Invoke(_score);
            if (_score > _hiscore)
            {
                HighScore = _score;
            }
        }
    }

    public int Lives
    {
        get { return _lives;}
        set
        {
            _lives = value;
            CurrentLivesChanged?.Invoke(_lives);
        }
    }

    public void ResetPlayerScore()
    {
        Score = 0;
    }
    public void ResetLives()
    {
        Lives = maxPlayerLives;
    }

    private void Awake()
     {
         if (Instance == null)
         {
             Instance = this;
             DontDestroyOnLoad(this.gameObject);
         }
         else
         {
             Destroy(this.gameObject);
         }
      
     }

    private void Start()
    {
        if (PlayerPrefs.HasKey("HiScore"))
        {
            _hiscore = int.Parse(PlayerPrefs.GetString("HiScore"));

        }
        else
        {
            _hiscore = 0;
        }

        Lives = maxPlayerLives;
    }
}
