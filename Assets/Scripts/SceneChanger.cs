using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string targetSceneName; // The name of the scene you want to switch to

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeScene();
        }
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }
}
