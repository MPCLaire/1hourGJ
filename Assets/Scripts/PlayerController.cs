using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputActionReference moveActionReference, hitActionReference;
    private InputAction MoveAction => moveActionReference.action;
    private InputAction HitAction => hitActionReference.action;


    private void Awake()
    {
        MoveAction.Enable();
        HitAction.Enable();
        MoveAction.started += MoveActionOnstarted;
        HitAction.started += HitActionOnstarted;
    }

    private void HitActionOnstarted(InputAction.CallbackContext obj)
    {
        throw new NotImplementedException();
    }

    private void MoveActionOnstarted(InputAction.CallbackContext obj)
    {
        throw new NotImplementedException();
    }
}
