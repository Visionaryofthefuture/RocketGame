using UnityEngine;
using UnityEngine.SceneManagement;


using System;
using UnityEngine.InputSystem;

public class Spawn_new_scene : MonoBehaviour
{
    ParticleSystem particles;
    void Start()
    {
        particles = GameObject.Find("ParticleDispenser")?.GetComponent<ParticleSystem>();
        try{
            var emission = particles.emission;
            emission.enabled = false;
        }
        catch (Exception E){
            Debug.Log(E);
        }
 }


private void OnCollisionEnter(Collision other)
{
    if (other.gameObject.CompareTag("Player"))
    {
        var emission = particles.emission;
        emission.enabled = true;   
         Movements movements = other.gameObject.GetComponent<Movements>();
        movements.DisableInput();
        Invoke("LoadNewScene", 5.0f);
    }
}

private void LoadNewScene()
{
    int index = GameManager.instance.getcurrinstance;
    index++;
    Debug.Log("Trigger next scene : " + index);

    SceneManager.LoadScene(index % SceneManager.sceneCountInBuildSettings);
}

}
