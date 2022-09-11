using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Grabbable : MonoBehaviour
{
    private Collider coll;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
         
        coll = gameObject.GetComponent<Collider>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision){
        rb.isKinematic = false;
    }
}
