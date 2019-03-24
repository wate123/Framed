using UnityEngine; 
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


public class WaypointController : MonoBehaviour
{
    //THIS SCRIPT MUST BE ATTACHED TO A GAMEOBJECT NAMED EXACTLY "WaypointCalculator" (Without Quotes)
    //THIS SCRIPT MUST BE ATTACHED TO A GAMEOBJECT NAMED EXACTLY "WaypointCalculator" (Without Quotes)
    //THIS SCRIPT MUST BE ATTACHED TO A GAMEOBJECT NAMED EXACTLY "WaypointCalculator" (Without Quotes)
    //Try not to change anything else, thanks! :)

    public static int TotalWaypoints;
    public static bool CompiledBouys = false;
    public List<GameObject> WaypointList = new List<GameObject>();

    void Start()
	{
        StartCoroutine(WaitForBouys());
        print("Compiling Waypoint List and Ordering, please wait.");
    }

    IEnumerator WaitForBouys()
    {
        //wait till all bouys are added.
        yield return new WaitForSeconds(1);
        //WaypointList = WaypointList.OrderBy(Objecto => Objecto.name).ToList();

        WaypointList = WaypointList.OrderBy(x => OrganiseNames(x.name)).ToList();

        TotalWaypoints = WaypointList.Count();
        CompiledBouys = true;
    }

	//void Update()
	//{
 //       //Debug info, comment out if you have no use for it, it's handy for when you're adding new waypoints to check!
        
 //       if (Input.GetKeyDown("space"))
 //       {
 //           foreach(GameObject wp in WaypointList)
 //               {
 //                   var Get = wp.GetComponentInChildren<SpriteRenderer>();
 //                   if (Get.enabled == false)
 //                   {
 //                       Get.enabled = true;
 //                   }
 //                   else
 //                   {
 //                       Get.enabled = false;
 //                   }
 //               };
 //       }

	//}
    public static string OrganiseNames(string input)
    {
        return Regex.Replace(input, "[0-9]+", match => match.Value.PadLeft(10, '0'));
    }

}