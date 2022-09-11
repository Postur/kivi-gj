using System.Collections;
using System.Collections.Generic;

using UnityEngine;  

public class RagDollOnOff : MonoBehaviour
{
    public BoxCollider boxColl;
    public Rigidbody mainRB;
    public GameObject theRig;
    public Animator animator;
    public float flyBitch;
    private Vector3 oldPos;
    private Vector3 newPos;
    public AudioClip[] smack;
    public AudioSource aS;
    private bool hasDied;
    public float knockDownVelocity;
    // Start is called before the first frame update
    void Start()
    {
        oldPos = newPos = gameObject.transform.position;
        getRagDoll();
        hasDied = false;
        RagDollOff();
    }

    // Update is called once per frame
    void Update()
    {
        newPos = gameObject.transform.position;
        float vel = ((newPos-oldPos)*Time.deltaTime).magnitude;
        // Debug.Log(vel);
        // Debug.Log(mainRB.velocity);
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
            rigid.AddForce(mainRB.velocity*flyBitch);
            rigid.useGravity = true;
            rigid.isKinematic = false;
        }
        boxColl.enabled = false;
        int rand = Random.Range(0,smack.Length-1);
        if(!aS.isPlaying && !hasDied){
            aS.clip = smack[rand];
    
            aS.Play();
            hasDied = true;
        }

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
