using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawn_new_scene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionEnter(Collision other)
    {
        int index = GameManager.instance.getcurrinstance;
        index++;
        Debug.Log("Trigger next scene : " + index);

        
        SceneManager.LoadScene(index% SceneManager.sceneCountInBuildSettings);

    }

    
    // Update is called once per frame
}
