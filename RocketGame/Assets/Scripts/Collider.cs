using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private Collider thisCollider;
    private Collider otherCollider; // Cache for the collided object

    void Start()
    {
        thisCollider = GetComponent<Collider>();
    }

    void OnCollisionEnter(Collision collision)
    {
        otherCollider = collision.collider; 
        Invoke("CollideAction", 20f);       
        SceneManager.LoadScene(0);        
    }

    private void CollideAction()
    {
        if (otherCollider != null)
        {
            Debug.Log("This is object tag: " + otherCollider.tag);
        }
        else
        {
            Debug.LogWarning("Collider is null!");
        }
    }
}
