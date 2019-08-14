using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //UIManager uIManager = FindObjectOfType<UIManager>();
        //Debug.Log(uIManager);
        //uIManager.ClosePanel();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            UIManager uIManager = FindObjectOfType<UIManager>();
            Debug.Log(uIManager);
            uIManager.ClosePanel();
        }
    }
}
