using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //Could possibly use Properties, but this is a tutorial project after all.
    [SerializeField]
    private float acceleration = 50.0f;
    [SerializeField]
    private float maxSpeed = 150.0f;

    [SerializeField, Range(0,10)]
    private float brakingDamping = 3;
    [SerializeField, Range(0,10)]
    private float normalDamping = 1;

    [DrawVector]
    private Vector3 _velocity;

    private InputAction moveAction;

    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Grab InputActions
        moveAction = InputSystem.actions.FindAction("Move",true);

        //Grab Components
        rb = GetComponent<Rigidbody>();
        // Debug.Assert(rb != null);

        rb.linearDamping = normalDamping;

    }

    // Update is called once per frame
    void Update()
    {
        //Get forward movment input axis (WS keys or up-down arrowkeys)
        Vector2 moveAxis = moveAction.ReadValue<Vector2>();
        float forwardInputAxis = moveAxis.y;

        //Clamp movement speed
        if (forwardInputAxis > 0.0f && rb.linearVelocity.magnitude < maxSpeed)
        {
            rb.linearDamping =  normalDamping;
            rb.AddRelativeForce(acceleration * forwardInputAxis * Vector3.forward, ForceMode.Acceleration);
        }

        //Brake
        if (forwardInputAxis < 0.0f)
        {
            rb.linearDamping =  brakingDamping;
        }
        else
        {
            rb.linearDamping = normalDamping;
        }

        _velocity = rb.linearVelocity;
    }
}