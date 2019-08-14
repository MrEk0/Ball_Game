using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    UIManager uIManager;

    private void Awake()
    {
        //uIManager = FindObjectOfType<UIManager>();
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
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (uIManager != null)
            uIManager.ClosePanel();
        else
            Debug.Log(uIManager);
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
