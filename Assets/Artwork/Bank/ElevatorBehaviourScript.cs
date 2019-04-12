using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorBehaviourScript : MonoBehaviour
    
    
{
    private float speed = 500f;
    private bool allowVertical;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter2D (Collision2D collision)
    {
        Debug.Log(collision.collider.name);
        if (collision.collider.tag == "Player")
        {
            allowVertical = true;

            //takes collided object and sets its tranform to your current object
            // when your current object moves, the other one follow along

            collision.gameObject.transform.parent = gameObject.transform;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (allowVertical)
        { 
            // move change the y direction of an elevator1.
            transform.Translate(0, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0);
        }

    }
}
