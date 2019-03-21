using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

    private RaycastHit2D hit;
    private GameObject player;
    public float MoveSpeed;
    private bool movingRight;
    private GameObject[] routePoint;
    private bool isOneCycle;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        routePoint = GameObject.FindGameObjectsWithTag("Route");
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
	void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.collider != null){
            
        }
	}

	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.right * MoveSpeed * Time.deltaTime);
        hit = Physics2D.Raycast(transform.position, transform.right);

        if(isPlayerInRange(hit)){
            Debug.Log("chase");
            Chase();
        }else if(isOneCycle){
            foreach (GameObject p in routePoint)
            {
                //Debug.Log(p);
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
