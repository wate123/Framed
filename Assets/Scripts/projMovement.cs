using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projMovement : MonoBehaviour
{

    public float hSpeed;
    public GameObject Rex;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += gameObject.transform.right * hSpeed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        //sets rex inactive when he is hit with the fireball 
        if (collision.tag == "Enemy")
        {
            //collision.SetActive(false);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}