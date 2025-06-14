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
        Invoke("CollideAction", 2f);       
    }

    private void CollideAction()
    {
        if (otherCollider != null && otherCollider.tag == "Player")
        {
            int index = GameManager.instance.getcurrinstance;
            Debug.Log("Changing to index : " +  index);
            SceneManager.LoadScene(index);
        }
    }
}
