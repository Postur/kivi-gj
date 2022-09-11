using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using StarterAssets;
public class RightArmControll : MonoBehaviour
{
    public InputActionMap controlArmR;
    // public TwoBoneIKConstraint handIK;
    // public GameObject handTarget;
    public Transform upperArmIK;
    public Vector3 initialPos;
    public Quaternion initialRot;
    public Transform upperArm;
    public ThirdPersonController tpc;
    public GameObject hand;
    public Collider handCol;

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
        // initialPos = handTarget.transform.localPosition;
        initialRot = upperArmIK.rotation;
        grabableItems = GameObject.FindGameObjectsWithTag("Grabbable");

        Debug.Log(grabableItems);
    }

private GameObject heldItem;
private Rigidbody heldItemRb;
private Collider heldItemCol;
public Rigidbody handRb;
private GameObject[] grabableItems;
    // Update is called once per frame
    void Update()
    {   
        if(controlArmR["reset"].IsInProgress()){
            SceneManager.LoadScene("DinnerRoom");
        }
        if(controlArmR["ControlArmR"].IsPressed()){
            if(!controlling){
                // handTarget.transform.localPosition = initialPos;
                upperArmIK.rotation = initialRot;
                tpc.LockCameraPosition = true;
            }
            controlling = true;
            // handIK.weight = 1;
            Vector2 newpos = controlArmR["MousePos"].ReadValue<Vector2>()*sensitivity;
            //handTarget.transform.Translate(new Vector3(newpos.x,0,newpos.y)/100/sensitivity);
            // Debug.Log(newpos.y);
            upperArmIK.Rotate(newpos.y,newpos.x,0,Space.World);
            // upperArmIK.rotation = new Quaternion(newpos.y,newpos.x,newpos.y,0);
            if (controlArmR["Grab"].IsPressed()){
                if(!heldItem){

                    
                    foreach (var item in grabableItems)
                    {
                        if (heldItem == null)
                        {
                            heldItem = item;
                        }
                        // Debug.Log(item.name);
                        if (Vector3.Distance(hand.transform.position,item.transform.position)<Vector3.Distance(hand.transform.position,heldItem.transform.position)){
                            heldItem = item;
                            heldItemRb = heldItem.GetComponent<Rigidbody>();
                            heldItemCol = heldItem.GetComponent<Collider>();
                        }
                    }
                }
                else{
                heldItemCol.enabled = false;
                handCol.enabled = false;
                heldItem.transform.position = hand.transform.position;
                }
            }
            else
            {   
                if(heldItemRb){
                    // heldItemRb.velocity = new Vector3(0,0,0);
                    heldItemRb.AddForce(handRb.velocity*2);
                    // Debug.Log(handRb.velocity);
                    
                }
                
                heldItem = null;
                handCol.enabled = true;
                heldItemCol.enabled = true;
            }
        }
        else
        {
            // handIK.weight = 0;
            controlling = false;
            tpc.LockCameraPosition = false;
            heldItem = null;
        }

    }

}
