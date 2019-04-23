using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameTimer : MonoBehaviour
{

    public float TotalTime;
    private float timeLeft;
    public Text timer;
    bool notComplete = true;
    private Health hp;

    public bool extrTime = false;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = TotalTime;
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

    public void MoreExtraTime()
    {
        extrTime = true;
    }

    void SetCountText()
    {
        timer.text = "Timer: " + timeLeft.ToString("0.0");
        if (System.Math.Abs(TotalTime - timeLeft) - 15f > 0.1)
        {
            Debug.Log("x");
            TotalTime -= 15;
            GameObject.FindWithTag("Player").GetComponent<Health>().health -= 1;
        }

        if (extrTime == true)
        {
            timeLeft = timeLeft + 10;
            extrTime = false;
        }

        if (timeLeft < 0)
        {
            timer.text = "Game Over!";
            SceneManager.LoadScene(2);
        }
    }
}
