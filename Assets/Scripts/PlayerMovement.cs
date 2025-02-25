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
    private float deccelerationDamping = 5;
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
        Vector2 moveAxis = moveAction.ReadValue<Vector2>();
        float forwardInputAxis = moveAxis.y;

        if (forwardInputAxis > 0.0f && rb.linearVelocity.magnitude < maxSpeed)
        {
            rb.linearDamping =  normalDamping;
            rb.AddRelativeForce(acceleration * forwardInputAxis * Vector3.forward, ForceMode.Acceleration);
        }
        else
        {
            rb.linearDamping =  deccelerationDamping;
        }

        _velocity = rb.linearVelocity;
    }
}