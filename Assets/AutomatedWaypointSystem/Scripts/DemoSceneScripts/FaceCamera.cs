using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class FaceCamera : MonoBehaviour
{
	void LateUpdate()
	{
        transform.LookAt(Camera.main.transform.position, Vector3.up);
    }
}