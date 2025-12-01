using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeToMenu : MonoBehaviour
{
    [SerializeField] private string menuSceneName = "Follow Path";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(menuSceneName);
        }
    }
}


