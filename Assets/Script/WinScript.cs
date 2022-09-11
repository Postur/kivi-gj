using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    public GameObject winScreen;
    public bool win;
    private RagDollOnOff[] smorgens;
    // Start is called before the first frame update
    void Start()
    {
        win = false;
        smorgens = gameObject.GetComponentsInChildren<RagDollOnOff>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (RagDollOnOff smorgen in smorgens)
        {
            if (!smorgen.hasDied){
                
                break;
            }
            win = true;
        }
        if (win)
        {
            winScreen.SetActive(true);
        }
    }
}
