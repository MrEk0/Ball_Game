using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject StartMenuPanel;
    [SerializeField] GameObject LosePanelPanel;
    [SerializeField] List<int> scoresToBoost;

    GameObject startPanel;
    GameManager GM;
    List<Transform> lives;
    Text scorePoints;
    int scoresIndex = 0;

    int currentScore=0;

    private void Awake()
    {
        GM = FindObjectOfType<GameManager>();
        lives = new List<Transform>();
        GetLivesCount();
        scorePoints = GetComponentInChildren<Text>();
        Debug.Log("dfd" + lives.Count);
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
        //startPanel = Instantiate(StartMenuPanel, transform);
        //StartMenuPanel.SetActive(true);
    }

    //public List<Transform> GetLives()
    //{
    //    return lives;
    //}

    public void ClosePanel()
    {
        //StartMenuPanel.SetActive(false);
        if (startPanel != null)
        {
            Destroy(startPanel);
            //Debug.Log("destroy");
        }
        //Debug.Log("Yeap");
    }

    public void LoseGame()
    {
        Instantiate(LosePanelPanel, transform.position, transform.rotation);
    }

    public void Damage()
    {
        int currentLives = lives.Count;
        lives[currentLives-1].gameObject.SetActive(false);
        lives.RemoveAt(currentLives - 1);
        if (lives.Count <= 0)
        {
            LosePanelPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Score()
    {
        currentScore += 5;
        if(currentScore>=scoresToBoost[scoresIndex])
        {
            GM.IncreaseSpeed(scoresIndex);
            scoresIndex += 1;
        }
        scorePoints.text = currentScore.ToString();
    }
}
