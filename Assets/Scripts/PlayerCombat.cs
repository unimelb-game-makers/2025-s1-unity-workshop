using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private Transform leftTurret;
    [SerializeField]
    private Transform rightTurret;

    private Transform bulletSpawn;

    private InputAction attackAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Assert(leftTurret != null);
        Debug.Assert(rightTurret != null);

        bulletSpawn = leftTurret;
        attackAction = InputSystem.actions.FindAction("Attack");
    }

    // Update is called once per frame
    void Update()
    {
        bool attackButtonPressed = attackAction.IsPressed();

        if (attackButtonPressed)
        {
            Instantiate(bullet,bulletSpawn);
            bulletSpawn = (bulletSpawn == leftTurret) ? rightTurret : leftTurret;
        }
    }
}
