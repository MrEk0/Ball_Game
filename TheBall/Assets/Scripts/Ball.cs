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
            transform.position = Vector3.MoveTowards(transform.position, move, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Death"))
        {
            Destroy(collider.gameObject);
            uIManager.Damage();
        }
        else if (collider.gameObject.CompareTag("Life"))
        {
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
            move = new Vector3(hit.point.x, transform.position.y, transform.position.z);
            move.x = Mathf.Clamp(move.x, leftBoundary, rightBoundary);
        }
    }
}
