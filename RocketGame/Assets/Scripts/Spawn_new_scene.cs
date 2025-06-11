using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawn_new_scene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Trigger next scene");

        SceneManager.LoadScene(1);

    }

    
    // Update is called once per frame
}
