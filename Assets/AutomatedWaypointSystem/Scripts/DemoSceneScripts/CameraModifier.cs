using UnityEngine; 
using System.Collections;

public class CameraModifier : MonoBehaviour
{
    GameObject Player;
    Transform Target;
    float Sparky;
    float inc = 0.03f;

    void Start()
	{
        Player = GameObject.Find("Enemy");
        Target = Player.transform;
	}

	void Update()
	{
        
        Sparky -= inc;
        if (Player != null)
        {
            Vector3 Movement = new Vector3(Sparky, transform.position.y, transform.position.z);
            transform.LookAt(Target);
            transform.position = Movement;
        }
	}

}