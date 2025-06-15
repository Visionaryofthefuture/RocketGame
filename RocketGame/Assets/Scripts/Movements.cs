using UnityEngine;
using UnityEngine.InputSystem;

public class Movements : MonoBehaviour
{
    // Start is called once before the first execution of Update after the
    public AudioSource Thrust_sound;
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotate;
    [SerializeField] Transform player1;
    // Update is called once per frame
    [SerializeField] Rigidbody player;
    [SerializeField] float RotationStrength;
    //    [SerializeField] int y;
    private void Start()
    {
        player = GetComponent<Rigidbody>();
        player1 = GetComponent<Transform>();
        Thrust_sound = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        thrust.Enable(); // enables the the Input Action (it could be a space on keyboard or left stick on console)
        rotate.Enable(); // enable the rotate Input Action
    }

    public void DisableInput()
    {
        thrust.Disable();
        rotate.Disable();
        player.isKinematic = false;
    
        player.freezeRotation = false;
        player.useGravity = true;
    }
    void FixedUpdate()
    {
        if (thrust.IsPressed())
        {
            player.AddRelativeForce(1000 * Vector3.up * Time.fixedDeltaTime);

            if (!Thrust_sound.isPlaying)
            {
                Thrust_sound.Play();
            }
        }
        else
        {
            Thrust_sound.Stop();
        }
        if (rotate.IsPressed())
        {
            player.freezeRotation = true;

            float Angle = rotate.ReadValue<float>();
            if (Angle < 0)
            {
                player1.Rotate(RotationStrength * Vector3.forward * Time.fixedDeltaTime);
            }
            else
            {
                player1.Rotate(-1 * RotationStrength * Vector3.forward * Time.fixedDeltaTime);
            }
        }
        else if(!rotate.IsPressed())
        {
            player.freezeRotation = false; 
        }
    }
}
