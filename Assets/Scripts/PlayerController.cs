using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : PhysicsObject
{

    public float maxSpeed = 4;
    public float jumpTakeOffSpeed = 7;
    private float cdTime = 2.0f;
    private float nextDash;
    private bool allowVertical;
    public bool canMove;

    private SpriteRenderer spriteRenderer;
    //private Animator animator;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //animator = GetComponent<Animator>();
        allowVertical = false;

    }
    void OnTriggerEnter2D(Collider2D col2D) {


        if (col2D.name == "key")
        {
            Destroy(col2D.gameObject);
        }
        if (col2D.name == "door")
        {
            if (GameObject.Find("key") == null)
            {
                SceneManager.LoadScene(2);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "ladder")
        {
            allowVertical = true;
            GetComponent<Rigidbody2D>().gravityScale = 0;
            gravityModifier = 0;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "ladder")
        {
            allowVertical = false;
            gravityModifier = 10;
            GetComponent<Rigidbody2D>().gravityScale = 10;
        }
	}

	protected override void ComputeVelocity()
    {
        if (!canMove)
        {
            return;
        }

        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        //Toggle clue book
        if (Input.GetKeyDown(KeyCode.C))
        {
            
        }
        //Toggle inventory
        if (Input.GetKeyDown(KeyCode.I))
        {

        }

        //Toggle dash with cd time;
        if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time > nextDash)
        {
            
            nextDash = Time.time + cdTime;

            //Dash logic
        }
        //Toogle pick up 
        if (Input.GetKeyDown(KeyCode.E))
        {
            
        }


        //if (Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    move.y = Input.GetAxis("Vertical") * maxSpeed;
        //}


        //flip the direction
        if (move.x < 0 )
        {
            spriteRenderer.flipX = true;
        }
        else if(move.x > 0)
        {
            spriteRenderer.flipX = false;
        }

        //animator.SetBool("grounded", grounded);
        //animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);
        if (allowVertical && (Input.GetAxis("Vertical") > 0 | Input.GetAxis("Vertical") < 0))
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
            //Debug.Log(new Vector2(0, Input.GetAxis("Vertical")));
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, Input.GetAxis("Vertical") * (maxSpeed/3));

        }
        else
        {
            targetVelocity = move * maxSpeed;
        }

        //GetComponent<Rigidbody2D>().isKinematic = true;


    }
}