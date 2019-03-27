using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTextAtLine : MonoBehaviour
{
    public TextAsset theText;
    public int startLine;
    public int endLine;
    public TextBoxManager theTextBox;
    public bool destroyWhenActivated;
    public bool requireButtonPress;
    private bool waitForPress;

    private GameObject key;


    // Start is called before the first frame update
    void Start()
    {
        key = GameObject.Find("key");
        key.GetComponent<SpriteRenderer>().enabled = false;
        key.GetComponent<BoxCollider2D>().enabled = false;

        theTextBox = FindObjectOfType<TextBoxManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(waitForPress && Input.GetKeyDown(KeyCode.F))
        {
            theTextBox.ReloadScript(theText);
            theTextBox.currentLine = startLine;
            theTextBox.endAtLine = endLine;
            theTextBox.EnableTextBox();
        }
        if (destroyWhenActivated)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.name == "Tora")
        {

            if (requireButtonPress)
            {
                waitForPress = true;
                return;
            }

            theTextBox.ReloadScript(theText);
            theTextBox.currentLine = startLine;
            theTextBox.endAtLine = endLine;
            theTextBox.EnableTextBox();

            if (transform.tag == "KeyKeeper")
            {
                key.GetComponent<SpriteRenderer>().enabled = true;
                key.GetComponent<BoxCollider2D>().enabled = true;
            }

        }
        if (destroyWhenActivated)
        {
            Destroy(gameObject);
        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.name == "Tora")
        {
            waitForPress = false; 
        }
    }
}
