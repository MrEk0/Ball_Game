using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    UIManager uIManager;

    private void Awake()
    {
        uIManager = FindObjectOfType<UIManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            Debug.Log("Collide");
            Destroy(collision.gameObject);
            uIManager.Damage();
        }
        else if (collision.gameObject.CompareTag("Life"))
        {
            Debug.Log("Collide");
            Destroy(collision.gameObject);
            uIManager.Score();
        }
    }

    private void TakeDamage()
    {

    }
}
