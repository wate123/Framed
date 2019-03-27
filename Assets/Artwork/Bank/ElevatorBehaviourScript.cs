using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorBehaviourScript : MonoBehaviour
    
    
{
    public float speed = .1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 temp = transform.position;
        temp.y += speed * Time.deltaTime;
        transform.position = temp;
    }
}
