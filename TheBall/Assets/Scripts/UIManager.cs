using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject StartMenuPanel;
    [SerializeField] GameObject LosePanelPanel;

    GameObject startPanel;
    List<Transform> lives;
    Text scorePoints;

    int currentScore=0;

    private void Awake()
    {
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
            Debug.Log("destroy");
        }
        Debug.Log("Yeap");
    }

    public void LoseGame()
    {
        Instantiate(LosePanelPanel, transform.position, transform.rotation);
    }

    public void Damage()
    {
        int currentLives = lives.Count;
        lives[currentLives].gameObject.SetActive(false);
    }

    public void Score()
    {
        currentScore += 1;
        scorePoints.text = currentScore.ToString();
    }
}
