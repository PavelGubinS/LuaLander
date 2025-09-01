using UnityEngine;
using UnityEngine.InputSystem;

public class Lander : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _landerRigidbody2D;
    private float _turnSpeed = 0.5f;
    private float _force = 10f;

    private void Awake()
    {
        _landerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Keyboard.current.upArrowKey.isPressed)
        {

            _landerRigidbody2D.AddForce(transform.up * _force);
        }
        if (Keyboard.current.leftArrowKey.isPressed)
        {

            _landerRigidbody2D.AddTorque(_turnSpeed);
        }
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            _landerRigidbody2D.AddTorque(-_turnSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        Debug.Log(collision2D.relativeVelocity.magnitude);
        float softLandingVelocityMagnitude = 4f;
        if (collision2D.relativeVelocity.magnitude > softLandingVelocityMagnitude)
        {
            //Landed too hard!
            Debug.Log("Landed too hard!");
            return;
        }
        Debug.Log("Successful landing!");

    }
}
