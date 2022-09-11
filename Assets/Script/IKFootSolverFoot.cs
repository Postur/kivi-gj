using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKFootSolverFoot : MonoBehaviour
{
    public GameObject body;
    public GameObject footNeutralPos;
    public float stepDistance;
    public IKFootSolverFoot otherFoot;
    public float speed;

    private Vector3 oldFootPos;
    private Vector3 currentBodyPos;
    private Vector3 distance;
    private Vector3 currentFootPos;
    float lerp;
    private Vector3 newFootPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        currentFootPos = gameObject.transform.position;
        lerp = 1;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = currentFootPos;
        if(Vector3.Distance(currentFootPos, footNeutralPos.transform.position)>stepDistance && !otherFoot.IsMoving( ) && lerp >= 1){
            lerp = 0;
            gameObject.transform.Translate((footNeutralPos.transform.position - currentFootPos ).normalized*stepDistance* 2f,Space.World);
            newFootPosition = gameObject.transform.position;
            // currentFootPos = gameObject.transform.position;
        }
        
        if (lerp<1)
        {
            Vector3 tempPos = Vector3.Lerp(oldFootPos, newFootPosition, lerp);

            currentFootPos = tempPos;
            lerp += Time.deltaTime * speed;
        }
        else
        {
            oldFootPos = newFootPosition;
            
        }
    }
    public bool IsMoving(){
        return lerp<1;
    }
}

