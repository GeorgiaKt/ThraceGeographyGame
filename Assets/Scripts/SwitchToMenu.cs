using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SwitchToMenu : MonoBehaviour
{
    public string targetSceneName;

    private void OnTriggerEnter()
    {
        SceneManager.LoadScene(targetSceneName);
    }
}
