using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameTimer : MonoBehaviour
{

    private float timeLeft = 30.0f;
    public Text timer;
    bool notComplete = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (notComplete == true)
        {
            timeLeft -= Time.deltaTime;
            SetCountText();
        }
    }


    void SetCountText()
    {
        timer.text = "Timer: " + timeLeft.ToString("0.0");
        if (timeLeft < 0)
        {
            timer.text = "Game Over!";
        }
    }


}
