using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //Could possibly use Properties, but this is a tutorial project after all.
    [SerializeField]
    private float acceleration = 50.0f;
    [SerializeField]
    private float maxSpeed = 150.0f;

    [SerializeField, Range(0, 10)]
    private float brakingDamping = 3;
    [SerializeField, Range(0, 10)]
    private float normalDamping = 1;
    [SerializeField,Range(0,10)]
    private float angularDamping = 2;

    [SerializeField, Range(0, 1)]
    private float mouseSensitivity = 0.1f;
    [SerializeField]
    private float mouseClamp = 5;

    [DrawVector]
    private Vector3 _velocity;
    [DrawVector(0,0,1)]
    private Vector3 mouseDeltaAxis;

    private InputAction moveAction;
    private InputAction lookAction;

    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Grab InputActions
        moveAction = InputSystem.actions.FindAction("Move", true);
        lookAction = InputSystem.actions.FindAction("Look", true);

        //Grab Components
        rb = GetComponent<Rigidbody>();
        // Debug.Assert(rb != null);

        rb.linearDamping = normalDamping;
        rb.angularDamping = angularDamping;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {

        mouseDeltaAxis = lookAction.ReadValue<Vector2>() * mouseSensitivity;
        mouseDeltaAxis = new Vector2(
            Mathf.Clamp(mouseDeltaAxis.x,-mouseClamp,mouseClamp),
            Mathf.Clamp(mouseDeltaAxis.y,-mouseClamp,mouseClamp)
        );

        //Get forward movment input axis (WS keys or up-down arrowkeys)
        Vector2 moveAxis = moveAction.ReadValue<Vector2>();
        float forwardInputAxis = moveAxis.y;


        //Clamp movement speed
        if (forwardInputAxis > 0.0f && rb.linearVelocity.magnitude < maxSpeed)
        {
            rb.linearDamping = normalDamping;
            rb.AddRelativeForce(acceleration * forwardInputAxis * Vector3.forward, ForceMode.Acceleration);
        }

        //Brake
        if (forwardInputAxis < 0.0f)
        {
            rb.linearDamping = brakingDamping;
        }
        else
        {
            rb.linearDamping = normalDamping;
        }

        //Turn spaceship 
        rb.MoveRotation(rb.rotation * Quaternion.Euler(-mouseDeltaAxis.y, mouseDeltaAxis.x, 0));

        _velocity = rb.linearVelocity;
    }
}
