using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float maxDistance;
    [SerializeField] float TimeToChange = 2f;

    public float Speed { private get; set; }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, -1)* Speed * Time.deltaTime);
        if (transform.position.z <= maxDistance)
        {
            Destroy(gameObject);
        }
    }

}
