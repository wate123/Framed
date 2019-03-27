using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numberOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;


    public GameObject guard;
    public GameObject heartpickup;

    public GameObject heart1, heart2, heart3, heart4, gameOver;


    // Start is called before the first frame update
    void Start()
    {
        health = 4;
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
        heart4.gameObject.SetActive(true);
        //gameOver.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(health > numberOfHearts)
        {
            health = numberOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if(i < numberOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        if (health > 4)
        { 
            health = 4;
        }

            switch (health)
            {
                case 4:
                    heart1.gameObject.SetActive(true);
                    heart2.gameObject.SetActive(true);
                    heart3.gameObject.SetActive(true);
                    heart4.gameObject.SetActive(true);
                    break;
                case 3:
                    heart1.gameObject.SetActive(true);
                    heart2.gameObject.SetActive(true);
                    heart3.gameObject.SetActive(true);
                    heart4.gameObject.SetActive(false);
                    break;
                case 2:
                    heart1.gameObject.SetActive(true);
                    heart2.gameObject.SetActive(true);
                    heart3.gameObject.SetActive(false);
                    heart4.gameObject.SetActive(false);
                    break;
                case 1:
                    heart1.gameObject.SetActive(true);
                    heart2.gameObject.SetActive(false);
                    heart3.gameObject.SetActive(false);
                    heart4.gameObject.SetActive(false);
                    break;
                case 0:
                    heart1.gameObject.SetActive(false);
                    heart2.gameObject.SetActive(false);
                    heart3.gameObject.SetActive(false);
                    heart4.gameObject.SetActive(false);
                    gameOver.gameObject.SetActive(true);
                    Time.timeScale = 0;
                    break;
            }


    }

    //void OnTriggerEnter2D(Collider2D other)
    //{
    // ..and if the game object we intersect has the tag 'Pick Up' assigned to it..
    //if (other.gameObject.CompareTag("frog"))
    //{
    // Make the other game object (the pick up) inactive, to make it disappear
    //other.gameObject.GetComponent<Renderer>().enabled = false;

    //}

    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Enemy")
        {
            Debug.Log(collision.tag);
            collision.gameObject.SetActive(false);
            health -= 1;
            Debug.Log(health);
        }

        if(collision.tag == "PowerUp")
        {
            collision.gameObject.SetActive(false);
            health += 1;
            Debug.Log(health);
        }
    }
}
