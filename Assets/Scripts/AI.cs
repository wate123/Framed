using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

    private GameObject self;
    private RaycastHit2D hit;
    private GameObject player;
    public float MoveSpeed;
	// Use this for initialization
	void Start () {
        self = this.gameObject;
        player = GameObject.FindWithTag("Player");
	}
	
    bool isPlayerInRange(RaycastHit2D hit2D){
        if(hit2D.collider == player){
            return true;
        }
        return false;
    }

    void WalkAround(){
        
    }
    void Chase(){
        transform.LookAt(player.transform.position);
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;

    }

	// Update is called once per frame
	void Update () {
        hit = Physics2D.Raycast(transform.position, -transform.right);
        Debug.Log(hit.transform);
        if(isPlayerInRange(hit)){
            Debug.Log("chase");
            Chase();
        }else{
            Debug.Log("walk");
            WalkAround();
        }
	}
}
