using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallElavator : MonoBehaviour
{
    private GameObject elavator;
    private GameObject player;
    private bool isMove;
    private RaycastHit2D rh2d;
    //private ElevatorBehaviourScript eleBehav;

    // Start is called before the first frame update
    void Start()
    {
        elavator = GameObject.Find("elevator1");
        //eleBehav = GetComponent<ElevatorBehaviourScript>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            //GameObject currentObject = eleBehav.q.Dequeue();
            rh2d = Physics2D.Raycast(player.transform.position, Vector2.down);
            //float yOffsetPlayer = player.GetComponent<SpriteRenderer>().bounds.extents.y;
            float yOffsetElavator = elavator.GetComponent<SpriteRenderer>().bounds.extents.y;
            float yDistance =  (rh2d.point.y - (elavator.GetComponent<SpriteRenderer>().bounds.center.y + yOffsetElavator));
            elavator.transform.Translate(new Vector3(0, yDistance * Time.deltaTime, 0));
            if (yDistance < 3)
            {
                this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                isMove = false;
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (!eleBehav.q.Contains(collision.gameObject))
        //{
        //    eleBehav.q.Enqueue(collision.gameObject);
        //}

        isMove = true;

    }
}
