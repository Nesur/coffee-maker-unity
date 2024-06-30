using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


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
