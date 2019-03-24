using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

    private RaycastHit2D hit;
    private GameObject player;
    public float MoveSpeed;
    private bool movingRight;
    private GameObject[] routePoint;
    public Transform StartPoint;
    private int currPoint;
    private bool isLadder;
    private bool isOneCycle;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        routePoint = GameObject.FindGameObjectsWithTag("Route");
        currPoint = 1;
        transform.position = Physics2D.Raycast(transform.position, Vector2.down).point;
        //transform.position = new Vector3(StartPoint.position.x, transform.position.y, transform.position.z);
        isOneCycle = false;
    }
	
    bool isPlayerInRange(RaycastHit2D hit2D){
        if(hit2D.transform.tag == "Player"){
            return true;
        }
        return false;
    }

    void WalkAround(){
        transform.Translate(Vector2.right * MoveSpeed * Time.deltaTime);
        //hit = Physics2D.Raycast(transform.position, transform.right);
        //Debug.Log(hit.transform.name);
    }
    void Chase(){
        //transform.LookAt(player.transform.position);
        transform.right = player.transform.position - transform.position;
        transform.Translate(transform.right * 100 * Time.deltaTime);
        //transform.position += ;

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "ladder")
        {
            isLadder = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "ladder")
        {
            isLadder = false;
        }
    }


    // Update is called once per frame
    void Update () {
        //Debug.Log(Vector2.Distance(transform.position, routePoint[currPoint].transform.position));
        if(Vector2.Distance(transform.position, routePoint[currPoint].transform.position) < 30 )
        {

            currPoint++;
        }
        else
        {
            Vector2 heading = (routePoint[currPoint].transform.position - transform.position);
            transform.Translate(heading/(heading.magnitude) * MoveSpeed * Time.deltaTime);
            Debug.Log(currPoint);
        }
        //transform.position = Vector2.MoveTowards(transform.position, )
        //transform.Translate(Vector2.right * MoveSpeed * Time.deltaTime);
        hit = Physics2D.Raycast(transform.position, transform.right);

        if(isPlayerInRange(hit)){
            Debug.Log("chase");
            Chase();
        }else if(isOneCycle){
            foreach (GameObject p in routePoint)
            {
                Debug.Log(p);
            }

            //Debug.Log(hit.distance);
            //if (hit.transform.name == "wall" && hit.distance <= 50f){
            //    transform.eulerAngles = new Vector3(0, -180, 0);
            //    movingRight = false;
            //}
            //else
            //{
            //    transform.eulerAngles = new Vector3(0, 0, 0);
            //    movingRight = true; 
            //}
            //WalkAround();
        }
	}
}
