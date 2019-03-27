using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    public int index;
    public string levelName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //loading level using build index 
            SceneManager.LoadScene(index);

            //load level using scene name
            //SceneManager.LoadScene(levelName);

            //restarts a cene/level 
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
