using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsObject
{

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    private float cdTime = 2.0f;
    private float nextDash;
    private bool allowVertical;

    private SpriteRenderer spriteRenderer;
    //private Animator animator;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //animator = GetComponent<Animator>();
        allowVertical = false;
    }
    void OnTriggerEnter2D(Collider2D col2D){
        if(col2D.name == "ladder"){
            allowVertical = true;
        }else {
            allowVertical = false;
        }
    }

    protected override void ComputeVelocity()
    {
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
        }else if(move.x > 0){
            spriteRenderer.flipX = false;
        }

        //animator.SetBool("grounded", grounded);
        //animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);
        if (allowVertical && Input.GetAxis("Vertical") != 0)
        {
            GetComponent<Rigidbody2D>().isKinematic = true;
            transform.Translate(0, Input.GetAxis("Vertical") * 100 * Time.deltaTime, 0);
        }else{
            GetComponent<Rigidbody2D>().isKinematic = false;
            targetVelocity = move * maxSpeed;
        }

    }
}