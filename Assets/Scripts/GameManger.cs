using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public static GameManger Instance;
    [SerializeField] private GameObject shipPrefab;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        StartNewGame();
    }

    public void StartNewGame()
    {
        AsteroidManger.Insatnce.CleanAsteroids();
        PlayerData.Instance.ResetPlayerScore();
        PlayerData.Instance.ResetLives();;
       var ship= Instantiate(shipPrefab);
       ship.transform.position=Vector3.zero;
      AsteroidManger.Insatnce.SpawnAsteroids();

    }

    IEnumerator  StartNewRound()
    {
        if (PlayerData.Instance.Lives > 0)
        {
            AsteroidManger.Insatnce.CleanAsteroids();
            PlayerData.Instance.Lives--;
            yield return new WaitForSecondsRealtime(0.5f);

            var ship = Instantiate(shipPrefab);
            transform.position = Vector3.zero;
            yield return new WaitForEndOfFrame();
            
            AsteroidManger.Insatnce.SpawnAsteroids();
        }
        else
        {
            GameUIController.Instance.ShowGameOverCanvas(true);
        }
    }

    public void StartNewRoundA()
    {
        StartCoroutine(StartNewRound());
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
