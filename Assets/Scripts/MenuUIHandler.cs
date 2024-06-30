using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
     EditorApplication.ExitPlaymode();
#else
    Application.Quit();
#endif
    }
}
