using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static bool dead;
    public static GameManager instance;
    public int getcurrinstance { get; private set; }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        getcurrinstance = scene.buildIndex;
        Debug.Log("Scene Changed: " + getcurrinstance);
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded-= OnSceneLoaded;
    }
}
