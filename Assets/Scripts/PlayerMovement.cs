using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Vector3 move;
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Assert(rb != null);

        rb.AddForce(move, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
