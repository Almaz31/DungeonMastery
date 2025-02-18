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
    public bool Slot1Input { get; private set; } = false;
    public bool Slot2Input { get; private set; } = false;
    public bool Slot3Input { get; private set; } = false;
    public bool Slot4Input { get; private set; } = false;
    public float ScrollMouseValue { get; private set; } = 0;

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

        _Input.PlayerInputMain.ScrollSlot.performed += SetScrollValue;
        _Input.PlayerInputMain.ScrollSlot.canceled += SetScrollValue;



    }
    private void OnDisable()
    {

        _Input.PlayerInputMain.Movement.performed -= SetMovement;
        _Input.PlayerInputMain.Movement.canceled -= SetMovement;

        _Input.PlayerInputMain.AttackInput.started -= SetAttack;
        _Input.PlayerInputMain.AttackInput.canceled -= SetAttack;

        _Input.PlayerInputMain.AbilityInput.started -= SetAbility;
        _Input.PlayerInputMain.AbilityInput.canceled -= SetAbility;

        _Input.PlayerInputMain.ScrollSlot.performed -= SetScrollValue;
        _Input.PlayerInputMain.ScrollSlot.canceled -= SetScrollValue;


        _Input.PlayerInputMain.Disable();
    }
    private void Update()
    {
        MenuInput = _Input.PlayerInputMain.MenuInput.WasPerformedThisFrame();
        Slot1Input = _Input.PlayerInputMain.FirstSlot.WasPerformedThisFrame();
        Slot2Input = _Input.PlayerInputMain.SecondSlot.WasPerformedThisFrame();
        Slot3Input = _Input.PlayerInputMain.ThirdSlot.WasPerformedThisFrame();
        Slot4Input = _Input.PlayerInputMain.FourthSlot.WasPerformedThisFrame();
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
    void SetScrollValue(InputAction.CallbackContext context)
    {
        ScrollMouseValue = context.ReadValue<float>();
    }

}
