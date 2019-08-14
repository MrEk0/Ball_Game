using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<float> multiplier;
    UIManager uIManager;
    Obstacle obstacle;

    private void Awake()
    {
        //uIManager = FindObjectOfType<UIManager>();
        obstacle = FindObjectOfType<Obstacle>();
    }

    private void Start()
    {
        uIManager = FindObjectOfType<UIManager>();
        Debug.Log(uIManager);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //if (uIManager != null)
        //    uIManager.ClosePanel();
        //else
        //    Debug.Log(uIManager);
    }

    public void IncreaseSpeed(int index)
    {
        float multi= multiplier[index];
        obstacle.MultiplySpeed(multi);
        //Debug.Log(multi);
    }

    public void ShowGameOverPanel()
    {

    }

    //public void Play()
    //{
    //    //close start panel
    //    if (uIManager != null)
    //        uIManager.ClosePanel();
    //    else
    //        Debug.Log(uIManager);
    //}
}
