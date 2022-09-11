using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Animations.Rigging;
public class RightArmControll : MonoBehaviour
{
    public InputActionMap controlArmR;
    public TwoBoneIKConstraint handIK;
    public GameObject handTarget;
    public Vector3 initialPos;
    public Quaternion initialRot;
    public Transform upperArm;
    public float sensitivity;
    private bool controlling;
    // Start is called before the first frame update
    private void OnEnable(){
        controlArmR.Enable();
    }
    private void OnDisable(){
        controlArmR.Enable();
    }
    void Start()
    {
        initialPos = handTarget.transform.localPosition;
        initialRot = upperArm.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(controlArmR["ControlArmR"].IsPressed()){
            if(!controlling){
                // handTarget.transform.localPosition = initialPos;
                upperArm.rotation = initialRot;
            }
            controlling = true;
            // handIK.weight = 1;
            Vector2 newpos = controlArmR["MousePos"].ReadValue<Vector2>()*sensitivity;
            //handTarget.transform.Translate(new Vector3(newpos.x,0,newpos.y)/100/sensitivity);
            upperArm.Rotate(newpos.x,0,newpos.y) ;
        }
        else
        {
            handIK.weight = 0;
            controlling = false;
        }
    }

}
