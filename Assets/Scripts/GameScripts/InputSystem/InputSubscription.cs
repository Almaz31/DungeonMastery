using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSubscription : MonoBehaviour
{
    public Vector2 MoveInput {  get; private set; }= Vector2.zero;
    public bool AttackInput { get; private set; } = false;
    public bool AbilityInput {  get; private set; } = false;
    public bool MenuInput { get; private set; } = false;
    InputMap _Input=null;

    private void OnEnable()
    {
        _Input = new InputMap();
        _Input.PlayerInputMain.Enable();

        _Input.PlayerInputMain.Movement.performed += SetMovement;
        _Input.PlayerInputMain.Movement.canceled += SetMovement;

        _Input.PlayerInputMain.AttackInput.started += SetAttack;
        _Input.PlayerInputMain.AttackInput.canceled += SetAttack;

        _Input.PlayerInputMain.AbilityInput.started += SetAbility;
        _Input.PlayerInputMain.AbilityInput.canceled += SetAbility;


    }
    private void OnDisable()
    {

        _Input.PlayerInputMain.Movement.performed -= SetMovement;
        _Input.PlayerInputMain.Movement.canceled -= SetMovement;

        _Input.PlayerInputMain.AttackInput.started -= SetAttack;
        _Input.PlayerInputMain.AttackInput.canceled -= SetAttack;

        _Input.PlayerInputMain.AbilityInput.started -= SetAbility;
        _Input.PlayerInputMain.AbilityInput.canceled -= SetAbility;


        _Input.PlayerInputMain.Disable();
    }
    private void Update()
    {
        MenuInput = _Input.PlayerInputMain.MenuInput.WasPerformedThisFrame();
    }
    void SetMovement(InputAction.CallbackContext context)
    {
        MoveInput =context.ReadValue<Vector2>();
    }
    void SetAttack(InputAction.CallbackContext context)
    {
        AttackInput =context.started;
    }
    void SetAbility(InputAction.CallbackContext context) 
    {
        AbilityInput =context.started;
    }

}
