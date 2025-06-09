using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    Collider c;
    SceneManager manager;
    void Start()
    {
        c = GetComponent<Collider>();
        manager = new SceneManager();
    }

    void OnCollisionEnter(Collision c)
    {
        CollideAction(c.collider);
        SceneManager.LoadScene(0);
    }

    private void CollideAction(Collider c)
    {
        if (c != null)
        {
            Debug.Log("This is object tag: " + c.tag);
        }
        else
        {
            Debug.LogWarning("Collider is null!");
        }
    }


}
