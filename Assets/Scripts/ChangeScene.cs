using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class ChangeScene : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ResetARSession()
    {
        GameObject[] arSessionList = GameObject.FindGameObjectsWithTag("ARSession");
        foreach (GameObject arSession in arSessionList)
        if (arSession != null)
        {
            arSession.GetComponent<ARSession>().Reset();
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
