using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{

    [SerializeField]
    private GameObject bullet;

    private InputAction attackAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attackAction = InputSystem.actions.FindAction("Attack");
    }

    // Update is called once per frame
    void Update()
    {
        bool attackButtonPressed = attackAction.IsPressed();

        if (attackButtonPressed)
        {
        }
    }
}
