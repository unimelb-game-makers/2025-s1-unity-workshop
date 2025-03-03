using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{

    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform projectileContainer;
    [SerializeField]
    private Transform leftTurret;
    [SerializeField]
    private Transform rightTurret;

    [SerializeField]
    private float bulletVelocity;
    [SerializeField]
    private float bulletLifetime;

    [SerializeField,Range(0,20)]
    private float shootCooldown = 1.2f;

    [SerializeField]
    private bool canFire;

    private Transform bulletSpawn;
    private float bulletTimer;


    private InputAction attackAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Assert(leftTurret != null);
        Debug.Assert(rightTurret != null);

        bulletSpawn = leftTurret;
        attackAction = InputSystem.actions.FindAction("Attack");

        bulletTimer = 0.0f;
        canFire = false;
    }

    // Update is called once per frame
    void Update()
    {
        bulletTimer += Time.deltaTime;
        if (bulletTimer >= shootCooldown)
        {
            canFire = true;       
            bulletTimer = 0.0f;
        }
        bool attackButtonPressed = attackAction.IsPressed();

        if (attackButtonPressed && canFire)
        {
            FireBullet();
        }
    }

    void FireBullet()
    {
            canFire = false;
            GameObject bulletInstance = Instantiate(bullet,bulletSpawn.position,bulletSpawn.rotation * Quaternion.Euler(90,0,0),projectileContainer);
            bulletInstance.GetComponent<Bullet>()._velocity = bulletVelocity;
            Destroy(bulletInstance,bulletLifetime);
            bulletSpawn = (bulletSpawn == leftTurret) ? rightTurret : leftTurret;
    }
}
