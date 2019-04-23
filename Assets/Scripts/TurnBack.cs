using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]
public class TurnBack : MonoBehaviour {

	[Space(10)]
	[Header("Toggle for the gui on off")]
	public bool GuiOn;


	[Space(10)]
	[Header("The text to Display on Trigger")]
	[Tooltip("To edit the look of the text Go to Assets > Create > GUIskin. Add the new Guiskin to the Custom Skin proptery. If you select the GUIskin in your project tab you can now adjust the Label section to change this text")]
	public string Text = "Turn Back";

	[Tooltip("This is the window Box's size. It will be mid screen. Add or reduce the X and Y to move the box in Pixels. ")]
	public Rect BoxSize = new Rect( 0, 0, 200, 100);


	[Space(10)]
	[Tooltip("To edit the look of the text Go to Assets > Create > GUIskin. Add the new Guiskin to the Custom Skin proptery. If you select the GUIskin in your project tab you can now adjust the font, colour, size etc of the text")]
	public GUISkin customSkin;

    private GameObject key;

    private void Start()
    {
        key = GameObject.Find("key");
        key.GetComponent<SpriteRenderer>().enabled = false;
        key.GetComponent<BoxCollider2D>().enabled = false;
    }

    // if this script is on an object with a collider display the Gui
    void OnTriggerEnter2D(Collider2D collision) 
	{

        if (collision.tag == "Player")
        {
            GuiOn = true;
            if(transform.tag == "KeyKeeper")
            {
                key.GetComponent<SpriteRenderer>().enabled = true;
                key.GetComponent<BoxCollider2D>().enabled = true;
            }

        }

    }


	void OnTriggerExit2D(Collider2D collision) 
	{
        if (collision.tag == "Player")
        {
            GuiOn = false;
        }


    }

	void OnGUI()
	{

		if (customSkin != null)
		{
			GUI.skin = customSkin;
		}

		if (GuiOn == true)
		{
			// Make a group on the center of the screen
			GUI.BeginGroup (new Rect ((Screen.width ) / 2, (Screen.height) / 2, BoxSize.width, BoxSize.height));

			// All rectangles are now adjusted to the group. (0,0) is the topleft corner of the group.

			GUI.Label(BoxSize, Text);

			// End the group we started above. This is very important to remember!
			GUI.EndGroup ();

		}


	}

}
