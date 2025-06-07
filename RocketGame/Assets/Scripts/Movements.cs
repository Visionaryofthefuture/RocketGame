using UnityEngine;
using UnityEngine.InputSystem;

public class Movements : MonoBehaviour
{
    // Start is called once before the first execution of Update after the
    [SerializeField] InputAction thrust;
    // Update is called once per frame
    [SerializeField] Rigidbody player;
//    [SerializeField] int y;
    private void Start()
    {
        player = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        thrust.Enable(); // enables the the Input Action (it could be a space on keyboard or left stick on console)
    }
    void FixedUpdate()
    {
        if (thrust.IsPressed())
        {
            player.AddRelativeForce(Vector3.up *100* Time.fixedDeltaTime);          
        }
    }
}
