using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public string MainMenuScene;
    public GameObject PauseMenu;
    public bool isPaused; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame(); 
            }
            else
            {
                isPaused = true;
                PauseMenu.SetActive(true);
                Time.timeScale = 0f; //freezes the game when paused 
            }
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        PauseMenu.SetActive(false);
        Time.timeScale = 1f; //unfreezes the game when unpaused
    }

    public void ReturnToMain()
    {
        Time.timeScale = 1f; //sets the game back to being unfrozen when player resumes game in the main menu. 
        SceneManager.LoadScene(MainMenuScene);
    }
}
