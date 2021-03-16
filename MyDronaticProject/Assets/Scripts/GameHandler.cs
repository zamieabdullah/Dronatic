using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    Text score;
    
    
    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit;
        #endif
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("MainGameScene");
    }
}
