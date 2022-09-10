using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public int maxMood = 10;
    public int currentMood;

    public Moodbar moodBar;

    // Start is called before the first frame update
    void Start()
    {
        currentMood = maxMood;
        moodBar.SetMaxMood(maxMood);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            TakeDamage(10);
        }
    }

    void TakeDamage(int damage) 
    {
        currentMood -= damage;

        moodBar.SetMood(currentMood);
    }
}

