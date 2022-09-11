using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    public bool win;
    public RagDollOnOff[] smorgens;
    // Start is called before the first frame update
    void Start()
    {
        smorgens = gameObject.GetComponentsInChildren<RagDollOnOff>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (RagDollOnOff smorgen in smorgens)
        {
            if (!smorgen.hasDied){
                win = false;
            }
            else{
                win = true;
            }
        }
        if (win)
        {
            
        }
    }
}
