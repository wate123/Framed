using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WarningIndicator : MonoBehaviour
{
    private bool isTalkable;
    private bool isClue;
    public Texture Talkable_Texture;
    public Texture Clue_Texture;
    public Rect BoxSize = new Rect(0, 0, 200, 100);
    public string Text = "Turn Back";
    private Vector2 screenPos;
    // Start is called before the first frame update
    void Start()
    {
        isTalkable = false;
        isClue = false;
        screenPos = Camera.main.WorldToScreenPoint(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Talkable"))
            {
                isTalkable = true;
            }
            if (gameObject.CompareTag("Clue"))
            {
                isClue = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Talkable"))
            {
                isTalkable = false;
            }
            if (gameObject.CompareTag("Clue"))
            {
                isClue = false;
            }
        }
    }


    private void OnGUI()
    {
        if (isTalkable || isClue)
        {
            // Make a group on the center of the screen
            GUI.BeginGroup(new Rect((Screen.width - BoxSize.width) / 2, (Screen.height - BoxSize.height) / 2, BoxSize.width, BoxSize.height));

            // All rectangles are now adjusted to the group. (0,0) is the topleft corner of the group.

            //GUI.Label(BoxSize, Text);
            GUI.DrawTexture(BoxSize, Talkable_Texture);
            //GUI.Label(new Rect(Screen.width - (screenPos.x + 20), Screen.height - (screenPos.y + 50), 100, 50), "cokolwiek");
        // End the group we started above. This is very important to remember!
        GUI.EndGroup();

        }
    }
}
