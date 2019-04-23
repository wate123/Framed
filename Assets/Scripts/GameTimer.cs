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
    public float LoseInterval;
    private GameObject[] Enemys;
    private Vector2 velocity;

    public bool extrTime = false;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = TotalTime;
        Enemys = GameObject.FindGameObjectsWithTag("Enemy");

        velocity = Enemys[0].GetComponent<Rigidbody2D>().velocity;
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

    public void PauseGame() {
        notComplete = false;
        if (Enemys.Length > 0)
        {
            for (int i = 0; i < Enemys.Length; i++)
            {
                Enemys[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                //Enemys[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            }
        }
    }
    public void ResumeGame()
    {
        notComplete = true;
        for (int i = 0; i < Enemys.Length; i++)
        {
            Enemys[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            Enemys[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            //Enemys[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        }
    }


    void SetCountText()
    {
        timer.text = "Timer: " + timeLeft.ToString("0.0");
        if (System.Math.Abs(TotalTime - timeLeft) - LoseInterval > 0.1)
        {
            TotalTime -= LoseInterval;

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
