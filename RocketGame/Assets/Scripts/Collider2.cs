using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Collider2 : MonoBehaviour
{
    private GameObject otherObject; // More accurate name
    [SerializeField] AudioClip audio;
    private GameObject audio_player;

    void OnCollisionEnter(Collision collision)
    {
        GameObject collidedObject = collision.gameObject;

        if (collidedObject.CompareTag("Player"))
        {
            otherObject = collidedObject;

            // Safely get components
            Movements playerInput = otherObject.GetComponent<Movements>();
      
            if (playerInput != null)
                playerInput.DisableInput();
            else
                Debug.LogWarning("PlayerInput component not found on Player.");
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(audio);
            

            Invoke("CollideAction", 3f);
        }
    }

    private void CollideAction()
    {
        if (otherObject != null && otherObject.CompareTag("Player"))
        {
            int index = GameManager.instance.getcurrinstance;
            Debug.Log("Changing to index: " + index);
            SceneManager.LoadScene(index);
        }
        else
        {
            Debug.LogWarning("CollideAction called but Player reference is missing.");
        }
    }
}
