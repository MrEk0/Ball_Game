using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    UIManager uIManager;

    Vector3 move;

    private void Awake()
    {
        uIManager = FindObjectOfType<UIManager>();
    }

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Debug.Log("Click");
            Movement();
            //Debug.Log(move);
            transform.Translate(move*speed*Time.deltaTime);
        }
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

    private void Movement()
    {
        Vector3 mousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        //Debug.Log(mousePosition);
        if (mousePosition.x < 0.5)
            move = Vector3.left;
        else
            move = Vector3.right;
        //Debug.Log(move);
    }

    private void TakeDamage()
    {

    }
}
