using UnityEngine; 
using System.Linq;


public class EnemyController : MonoBehaviour
{
    //Change the following two variables in the inspector for individual enemy prefabs after attaching the script.
    public float MoveSpeed;
    public float TurnSpeed;

    public GameObject CurrentWaypoint;
    GameObject ControllerObject;

    bool MovementRoutineGo = false;


    void Start()
    {
        //Default values for move and turn speed
        MoveSpeed = 0.1f;
        TurnSpeed = 3f;
        ControllerObject = GameObject.Find("WaypointCalculator");
    }

    void Update()
	{
        //Try not to change any of this code unless you know what you're doing, it'll break everything, thanks!
        //From here....
        //From here....
        if (WaypointController.CompiledBouys == true)
        {
            var WaypointListScript = ControllerObject.GetComponent<WaypointController>();
            CurrentWaypoint = WaypointListScript.WaypointList.FirstOrDefault();
            WaypointController.CompiledBouys = false;
            MovementRoutineGo = true;
        }

        if(MovementRoutineGo == true)
        {
            var cwptp = CurrentWaypoint.transform.position;
            MoveTowardsWaypoint(cwptp.x, cwptp.y, cwptp.z);

            if(transform.position == cwptp)
            {
                var WaypointListScript = ControllerObject.GetComponent<WaypointController>();
                var CurrentIndex = WaypointListScript.WaypointList.IndexOf(CurrentWaypoint);
                int RangeProtection = WaypointController.TotalWaypoints - 1;
                var LastWaypointLocation = WaypointListScript.WaypointList.Last();

                if (CurrentIndex < RangeProtection)
                {
                        var NextBouy = WaypointListScript.WaypointList[CurrentIndex + 1];
                        CurrentWaypoint = NextBouy;
                }
                else if(CurrentIndex == RangeProtection)
                {
                    var NextBouy = WaypointListScript.WaypointList.Last();
                    CurrentWaypoint = NextBouy;
                    
                }
        //To here....
        //To here....  
                if (transform.position == LastWaypointLocation.transform.position)
                {
                    //Do whatever you want when the enemy reaches the end of the waypoint system
                    //it currently...
                    Destroy(gameObject);
                    //Destroys itself.
                }
            }


        }
	}

    //Try not to change any of this, however if you don't want your enemies to rotate when moving, comment out the last line
    void MoveTowardsWaypoint(float X, float Y, float Z)
    {
        Vector3 location;
        location = new Vector3(X, Y, Z);
        transform.position = Vector3.MoveTowards(transform.position, location, MoveSpeed);
        Vector3 targetDir = location - transform.position;
        float step = TurnSpeed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);

        transform.rotation = Quaternion.LookRotation(newDir);
    }
}