using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public bool lookingRight;
    public float posOffset;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKey("right"))
        {
            lookingRight = true;
        }
        else if(Input.GetKeyDown(KeyCode.A) || Input.GetKey("left"))
        {
            lookingRight = false;
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            shoot();
        }
    }
    void shoot()
    {
        if (lookingRight)
        {
            //shoots right
            Vector3 projPosition = new Vector3(gameObject.transform.position.x + posOffset, gameObject.transform.position.y, gameObject.transform.position.z);
            Instantiate(bulletPrefab, projPosition, firePoint.rotation);
        }
        else
        {
            //shoots left
            Vector3 projPosition = new Vector3(gameObject.transform.position.x - posOffset, gameObject.transform.position.y, gameObject.transform.position.z);
            Instantiate(bulletPrefab, projPosition, Quaternion.Euler(Vector3.down * 180f));
        }
    }
}
