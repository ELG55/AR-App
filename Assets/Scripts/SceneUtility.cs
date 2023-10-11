using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class SceneUtility : MonoBehaviour
{
    private static SceneUtility sceneUtilityInstance;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (sceneUtilityInstance == null)
        {
            sceneUtilityInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    void OnSceneUnloaded(Scene current)
    {
        if (current == SceneManager.GetActiveScene())
        {
            LoaderUtility.Deinitialize();
            LoaderUtility.Initialize();
        }
    }

    void OnDisable()
    {
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }
}
