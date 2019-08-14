using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float maxDistance;
    [SerializeField] float TimeToChange = 2f;

    bool multIsChanged = false;
    public float Multiplier { private get; set; } = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(multIsChanged)
        //{
        //    StartCoroutine(ChangeSpeed());
        //    Debug.Log("new"+speed);
        //    multIsChanged = false;
        //}
        transform.Translate(new Vector3(0, 0, -1)* speed/**Multiplier*/ * Time.deltaTime);
        speed += 0.01f;
        Debug.Log(speed);
        if (transform.position.z<=maxDistance)
        {
            Destroy(gameObject);
        }
        //Debug.Log(Multiplier);
    }

    IEnumerator ChangeSpeed()
    {
        while(speed!=speed*Multiplier)
        {
            speed += Time.deltaTime / TimeToChange;
            yield return null;
        }
    }

    public void MultiplySpeed(float index)
    {
        Multiplier = index;
        Debug.Log(Multiplier);
        multIsChanged = true;
        //StartCoroutine(ChangeSpeed());
        //Debug.Log("new" + speed);
        //Debug.Log(multIsChanged);
    }
}
