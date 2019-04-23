using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextBoxManager : MonoBehaviour
{
    public TextAsset textFile;
    public string[] textLines;
    public GameObject textBox;
    public Text theText;
    public int currentLine;
    public int endAtLine;
    public PlayerController player;
    public bool isActive;
    public bool stopPlayerMovement;
    private bool isTyping = false;
    private bool cancelTyping = false;
    private GameTimer timer;
    //setting the value for textSpeed with higher numbers makes the text scroll slower
    public float textSpeed;
 

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        //unique = 
        if (!SceneManager.GetActiveScene().name.Contains("Pro"))
        {
            timer = GameObject.FindWithTag("Timer").GetComponent<GameTimer>();

        }

        if(textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }

        if(endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }
        if(isActive)
        {
            EnableTextBox();
        }
        else
        {
            DisableTextBox();
        }

    }

    void Update()
    {
        if (!isActive)
        {
            return;
        }

        //theText.text = textLines[currentLine];

        if (Input.GetKeyDown("space"))
        {
            if (!isTyping)
            {

                currentLine += 1;

                if (currentLine > endAtLine)
                {
                    DisableTextBox();
                }
                else
                {
                    StartCoroutine(TextScroll(textLines[currentLine]));
                }
            }
            else if(isTyping && !cancelTyping)
            {
                cancelTyping = true;
            }
        }
    }


    private IEnumerator TextScroll (string lineOfText)
    {
        int letter = 0;
        theText.text = "";
        isTyping = true;
        cancelTyping = false;

        //will print out the text one letter at a time
        while (isTyping && !cancelTyping && (letter < lineOfText.Length - 1))
        {
            theText.text += lineOfText[letter];
            letter += 1;
            yield return new WaitForSeconds(textSpeed);
        }
        theText.text = lineOfText;
        isTyping = false;
        cancelTyping = false;
    }

    public void EnableTextBox()
    {
        textBox.SetActive(true);
        isActive = true;

        if (stopPlayerMovement)
        {
            player.canMove = false;
        }
        if (timer != null)
        {
            //Debug.Log(timer);
            timer.PauseGame();
        }

        StartCoroutine(TextScroll(textLines[currentLine]));

    }

    public void DisableTextBox()
    {
        textBox.SetActive(false);
        isActive = false;
        player.canMove = true;
        //timer.ResumeGame();
        if (timer != null)
        {
            timer.ResumeGame();
        }
        else
        {
            if (SceneManager.GetActiveScene().name == "Prolouge")
            {
                SceneManager.LoadScene(2);
            }
            else if (SceneManager.GetActiveScene().name == "Prolouge Draco")
            {
                SceneManager.LoadScene(3);
            }else if (SceneManager.GetActiveScene().name == "Prolouge Jolene")
            {
                SceneManager.LoadScene(4);
            }else if (SceneManager.GetActiveScene().name == "Prolouge Phoe")
            {
                SceneManager.LoadScene(5);
            }else if (SceneManager.GetActiveScene().name == "Prolouge Rex")
            {
                SceneManager.LoadScene(6);
            }

        }
    }


    public void ReloadScript(TextAsset theText)
    {
        if(theText != null)
        {
            textLines = new string[1];
            textLines = (theText.text.Split('\n'));

        }
    }

}
