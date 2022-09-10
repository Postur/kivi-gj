using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKFootSolverV2 : MonoBehaviour
{

    public GameObject FootL;
    public GameObject FootR;
    public GameObject body;
    public float stepDistance;

    public Rigidbody rb;

    private Vector3 oldBodyPos;
    private Vector3 newBodyPos;
    private Vector3 currentVelocity;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        newBodyPos = body.transform.position;
        currentVelocity = (newBodyPos-oldBodyPos)/Time.deltaTime;
        // Debug.Log(currentVelocity);
        oldBodyPos = newBodyPos;


        
    }
}
