using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    public GameObject winScreen;
    public bool win;
    private RagDollOnOff[] smorgens;
    private List<bool> smorgensBool = new List<bool>{true};
    // Start is called before the first frame update
    void Start()
    {
        win = false;
        smorgens = gameObject.GetComponentsInChildren<RagDollOnOff>();

    }

    // Update is called once per frame
    void Update()
    {

        smorgensBool.Clear();
        foreach (RagDollOnOff smorgen in smorgens)
        {
            smorgensBool.Add(smorgen.hasDied);
        }
        
        if (!smorgensBool.Contains(false))
        {
            winScreen.SetActive(true);
        }
    }
}
