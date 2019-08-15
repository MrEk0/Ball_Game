using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject StartMenuPanel;
    [SerializeField] GameObject LosePanel;
    [SerializeField] GameSettings gameSettings;

    GameObject startPanel;
    GameManager GM;
    List<Transform> lives;
    Text scorePoints;
    int scoresIndex = 0;
    int currentLives;
    int currentScore=0;

    public event Action onScoreAchieved;

    private void Awake()
    {
        GM = FindObjectOfType<GameManager>();
        lives = new List<Transform>();
        GetLivesCount();
        scorePoints = GetComponentInChildren<Text>();
    }

    private void GetLivesCount()
    {
        foreach (Transform child in transform)
        {
            if (child.name == "Life")
            {
                lives.Add(child);
            }
        }
    }

    private void Start()
    {
        startPanel=Instantiate(StartMenuPanel, transform);
        Time.timeScale = 0;
    }

    public void Damage()
    {
        currentLives = lives.Count;
        lives[currentLives-1].gameObject.SetActive(false);
        lives.RemoveAt(currentLives - 1);
        if (lives.Count <= 0)
        {
            Instantiate(LosePanel, transform);
            Time.timeScale = 0;
        }
    }

    public void Score()
    {
        currentScore += 5;
        if(currentScore>=gameSettings.GetScoreToBoost(scoresIndex))
        {
            onScoreAchieved();
            scoresIndex += 1;
        }
        scorePoints.text = currentScore.ToString();
    }

    public void StartGame()
    {
        Destroy(startPanel);
    }
}
