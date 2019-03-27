using UnityEngine;
using UnityEngine.SceneManagement;

using System.Collections; 

public class QuitOnClick : MonoBehaviour
{
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; 
#else
        Application.Quit(); 
#endif
    }
    public void BackMain()
    {
        SceneManager.LoadScene(0);
    }
}
