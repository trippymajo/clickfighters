using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneButt : MonoBehaviour
{
    [SerializeField] private string mainSceneName = "MainScene"; // first scene

    public void ReturnToScene()
    {
        SceneManager.LoadScene(mainSceneName, LoadSceneMode.Single);
    }
}
