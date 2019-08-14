using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    [SerializeField] float leftBoundary = -4.2f;
    [SerializeField] float rightBoundary = 4.2f;
    UIManager uIManager;

    Vector3 move;
    Vector3 target;

    private void Awake()
    {
        uIManager = FindObjectOfType<UIManager>();
    }

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Movement();
            //transform.Translate(move * speed * Time.deltaTime);
            //if (transform.position.x < leftBoundary && move == Vector3.left)
            //{
            //    Debug.Log(transform.position.x);
            //    transform.Translate(Vector3.zero * speed * Time.deltaTime);

            //}
            //else if (transform.position.x > rightBoundary && move == Vector3.left)
            //{
            //    //Movement();
            //    Debug.Log(transform.position.x);
            //    transform.Translate(move * speed * Time.deltaTime);

            //}
            //else
            //    //transform.Translate(move * speed * Time.deltaTime);
            //if(transform.position.x<rightBoundary && transform.position.x>leftBoundary)
            transform.position = Vector3.MoveTowards(transform.position, move, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.gameObject.name);
        if (collider.gameObject.CompareTag("Death"))
        {
            Debug.Log("Collide");
            Destroy(collider.gameObject);
            uIManager.Damage();
        }
        else if (collider.gameObject.CompareTag("Life"))
        {
            Debug.Log("Collide");
            Destroy(collider.gameObject);
            uIManager.Score();
        }
    }

    private void Movement()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            //float positionX= Mathf.Clamp(hit.point.x, leftBoundary, rightBoundary);
            //Debug.Log(positionX);
            move = new Vector3(hit.point.x, transform.position.y, transform.position.z);
            move.x = Mathf.Clamp(move.x, leftBoundary, rightBoundary);
            Debug.Log(move);
        }
        //Vector3 mousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        //target = new Vector3(mousePosition.x, transform.position.y, transform.position.z);
        //Debug.Log(target);
        //if (mousePosition.x < transform.position.x/5)
        //    move = Vector3.left;
        //else
        //    move = Vector3.right;
        ////Debug.Log(move);
        //Vector3 newTransform = Camera.main.ScreenToViewportPoint(transform.position);
        //Debug.Log(transform.position.x / 5);
    }

    private void TakeDamage()
    {

    }
}
