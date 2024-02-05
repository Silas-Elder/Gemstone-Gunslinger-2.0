using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemForce : MonoBehaviour
{
    private Rigidbody rb;
    public float force;
    public int time;
    //public float rotTime;
    bool up = false;
   // bool rotating = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if(up == false)
        {
            StartCoroutine(GoUp());
        }

        /*if(rotating == false)
        {
            StartCoroutine(RandomRotate());
        } */
        

    }

    IEnumerator GoUp()
    {
        
        rb.AddForce(Vector3.up * force);
        up = true;
        yield return new WaitForSeconds(time);
        

        up = false;
    }
    /*
    IEnumerator RandomRotate()
    {
        transform.rotation = Random.rotation;
        rotating = true;
        yield return new WaitForSeconds(rotTime);
        rotating = false;
    } */
}
