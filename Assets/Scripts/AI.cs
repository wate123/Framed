using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AI : MonoBehaviour {

    private RaycastHit2D hit;
    private GameObject player;
    public float MoveSpeed;
    public GameObject route;
    private Transform[] routePoints;
    public GameObject StartPoint;
    private int currPoint;
    private Vector2 heading;
    private Rigidbody2D rg2d;
    private float tempGravity;
    private int index = 1;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        routePoints = new Transform[route.transform.childCount];
        for(int i = 0; i<route.transform.childCount; i++)
        {
            routePoints[i] = route.transform.GetChild(i);
        }
        currPoint = System.Array.IndexOf(routePoints, StartPoint.transform);
        rg2d = gameObject.GetComponent<Rigidbody2D>();
        tempGravity = rg2d.gravityScale;
        //Physics2D.IgnoreCollision(, GetComponent<Collider2D>());
        //transform.position = Physics2D.Raycast(transform.position, Vector2.down).point ;
        transform.position = new Vector3(StartPoint.transform.position.x, transform.position.y, transform.position.z);
    }
	
    bool isPlayerInRange(RaycastHit2D hit2D){
        if (hit2D.transform.tag == "Player")
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.name == "ladder")
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
            rg2d.gravityScale = 0;
        }
        if (collision.collider.CompareTag("Enemy"))
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
        if (collision.transform.tag == "Player")
        {
            SceneManager.LoadScene(2);
        }

    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.name == "ladder")
        {
            rg2d.gravityScale = tempGravity;
        }
    }


    // Update is called once per frame
    void FixedUpdate () {
        //Debug.Log(Vector2.Distance(transform.position, routePoint[currPoint].transform.position));
        //if(currPoint == routePoints.Length -1 || currPoint == 0)
        //{
        //    index = -index;
        //
        //Debug.Log(currPoint);
        //if (gameObject.name == "Rex")
        //{
        //    Debug.Log(currPoint);
        //}
        heading = (routePoints[currPoint].position - transform.position);
        hit = Physics2D.Raycast(transform.position, heading.normalized);
        //Debug.Log(hit.transform.tag);
        if (isPlayerInRange(hit))
        {

            heading = (player.transform.position - transform.position);
            if (heading.x < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            //transform.Translate(heading * MoveSpeed * 1.5f * Time.deltaTime);
            //rg2d.MovePosition(heading.normalized * MoveSpeed * Time.deltaTime);
            rg2d.velocity = heading.normalized * MoveSpeed * 100f * Time.deltaTime;
        }
        else
        {
            if (Vector2.Distance(transform.position, routePoints[currPoint].position) < 30)
            {
                if (currPoint == routePoints.Length - 1)
                {
                    index = -1;
                }
                else if(currPoint == -1)
                {
                    index = 1;
                }
                currPoint += index;
            }
            else
            {
                heading = (routePoints[currPoint].position - transform.position);
                if (heading.x < 0)
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                }
                else
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                }

                //transform.Translate(heading * MoveSpeed * Time.deltaTime );
                rg2d.velocity = heading.normalized * MoveSpeed * 100f * Time.deltaTime;
                //rg2d.MovePosition(heading.normalized * MoveSpeed * Time.deltaTime);

            }
        }

        //transform.position = Vector2.MoveTowards(transform.position, )
        //transform.Translate(Vector2.right * MoveSpeed * Time.deltaTime);

    }
}
