using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Could possibly use Properties, but this is a tutorial project after all.
    [SerializeField]
    private Vector3 initialVelocity = Vector3.forward;

    [DrawVector]
    private Vector3 _velocity;

    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Grab Components
        rb = GetComponent<Rigidbody>();
        // Debug.Assert(rb != null);

        //Push our player in velocity direction.
        rb.AddForce(initialVelocity,ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
        _velocity = rb.linearVelocity;
    }
}

