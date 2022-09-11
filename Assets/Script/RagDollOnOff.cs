using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagDollOnOff : MonoBehaviour
{
    public BoxCollider boxColl;
    public Rigidbody mainRB;
    public GameObject theRig;
    public Animator animator;
    private Vector3 oldPos;
    private Vector3 newPos;
    public float knockDownVelocity;
    // Start is called before the first frame update
    void Start()
    {
        oldPos = newPos = gameObject.transform.position;
        getRagDoll();

        RagDollOff();
    }

    // Update is called once per frame
    void Update()
    {
        newPos = gameObject.transform.position;
        float vel = ((newPos-oldPos)*Time.deltaTime).magnitude;
        // Debug.Log(vel);
        Debug.Log(mainRB.velocity);
        if(mainRB.velocity.magnitude>knockDownVelocity || mainRB.angularVelocity.magnitude>knockDownVelocity){
            RagDollOn();
        }
        oldPos = newPos;
    }
    private void OnCollisionEnter(Collision collision){

    }
    Collider[] colliders;
    Rigidbody[] rigidbodies;
    void getRagDoll(){
        colliders = theRig.GetComponentsInChildren<Collider>();
        rigidbodies = theRig.GetComponentsInChildren<Rigidbody>();
    }
    void RagDollOn(){

        animator.enabled = false;
        foreach (Collider collider in colliders)
        {
            
            collider.enabled = true;
        }
        foreach (Rigidbody rigid in rigidbodies)
        {
            
            rigid.useGravity = true;
            rigid.isKinematic = false;
        }
        boxColl.enabled = false;

    }
    void RagDollOff(){
        foreach (Collider collider in colliders)
        {

            collider.enabled = false;
        }
        foreach (Rigidbody rigid in rigidbodies)
        {
            rigid.useGravity = false;
            rigid.isKinematic = true;

        }
        animator.enabled = true;
        boxColl.enabled = true;

    }
}