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
    private Inventory _inventory;
    private GameObject _player;

    private GameObject key;


    // Start is called before the first frame update
    void Start()
    {
        key = GameObject.Find("key");
        key.GetComponent<SpriteRenderer>().enabled = false;
        key.GetComponent<BoxCollider2D>().enabled = false;

        theTextBox = FindObjectOfType<TextBoxManager>();
        _player = GameObject.FindGameObjectWithTag("Player");
        if (_player != null)
            _inventory = _player.GetComponent<PlayerInventory>().inventory.GetComponent<Inventory>();
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
    bool CheckHaveAllCombination()
    {
        for (int i = 1; i<5; i++)
        {
            bool check = _inventory.checkIfItemAllreadyExist(i, 1);
            //Debug.Log(_inventory.ItemsInInventory[i].itemID);
            //Debug.Log(_inventory.ItemsInInventory[i].itemID);
            if (!check)
            {
                return false;
            }
        }
        return true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            if (gameObject.name == "Keypad Objective Zone")
            {
                if (CheckHaveAllCombination())
                {
                    Debug.Log("in");
                    gameObject.GetComponent<Collider2D>().enabled = false;
                }

            }
            theTextBox.ReloadScript(theText);
            theTextBox.currentLine = startLine;
            theTextBox.endAtLine = endLine;
            theTextBox.EnableTextBox();

        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player" )
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
