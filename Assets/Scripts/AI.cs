using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AI : MonoBehaviour {

    private RaycastHit2D hit;
    private GameObject player;
    public float MoveSpeed;
    private GameObject[] routePoint;
    public GameObject StartPoint;
    private int currPoint;
    private Vector2 heading;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        routePoint = GameObject.FindGameObjectsWithTag("Route");
        currPoint = System.Array.IndexOf(routePoint, StartPoint);
        Debug.Log(currPoint);
        //transform.position = Physics2D.Raycast(transform.position, Vector2.down).point ;
        transform.position = new Vector3(StartPoint.transform.position.x, transform.position.y, transform.position.z);
    }
	
    bool isPlayerInRange(RaycastHit2D hit2D){
        if(hit2D.transform.tag == "Player"){
            return true;
        }
        return false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "ladder")
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
        }
        if (collision.transform.tag == "Player")
        {
            SceneManager.LoadScene(2);
        }

    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "ladder")
        {
            GetComponent<Rigidbody2D>().gravityScale = 10;
        }
    }


    // Update is called once per frame
    void FixedUpdate () {
        //Debug.Log(Vector2.Distance(transform.position, routePoint[currPoint].transform.position));
        if(currPoint == routePoint.Length - 1)
        {
            currPoint = 0;
        }
        heading = (routePoint[currPoint].transform.position - transform.position);
        hit = Physics2D.Raycast(transform.position, heading.normalized);
        //Debug.Log(hit.transform.tag);
        if (isPlayerInRange(hit))
        {

            Debug.Log(hit.transform.tag);
            heading = (player.transform.position - transform.position);
            if (heading.x < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            transform.Translate(heading * MoveSpeed * 1.3f * Time.deltaTime);
        }
        else
        {
            if (Vector2.Distance(transform.position, routePoint[currPoint].transform.position) < 30)
            {
                currPoint++;
            }
            else
            {
                heading = (routePoint[currPoint].transform.position - transform.position);
                if (heading.x < 0)
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                }
                else
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                }

                transform.Translate(heading * MoveSpeed * Time.deltaTime );

            }
        }

        //transform.position = Vector2.MoveTowards(transform.position, )
        //transform.Translate(Vector2.right * MoveSpeed * Time.deltaTime);

    }
}
