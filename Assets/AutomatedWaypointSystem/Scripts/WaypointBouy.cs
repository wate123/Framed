using UnityEngine; 

public class WaypointBouy : MonoBehaviour
{
    //This script must be attached to each waypoint gameobject, an order is automatically generated based
    //on the gameobjects name, for example:
    //Waypoint1, Waypoint2, Waypoint3...etc will go in the the same order
    //Waypoint39, Waypoint77 and DogFace33 will go in the order of DogFace33, Waypoint39 and finally Waypoint77.

    void Start()
	{
        GameObject ControllerObject = GameObject.Find("WaypointCalculator");
        var WaypointListScript = ControllerObject.GetComponent<WaypointController>();
        WaypointListScript.WaypointList.Add(gameObject);
    }

}