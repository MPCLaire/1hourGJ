using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputActionReference moveActionReference, hitActionReference;
    private InputAction MoveAction => moveActionReference.action;
    private InputAction HitAction => hitActionReference.action;


    private float _currentPos = -2;
    [SerializeField, Range(0, 1)] private float moveDuration = .1f;

    private void Awake()
    {
        MoveAction.Enable();
        HitAction.Enable();
        MoveAction.started += MoveActionOnstarted;
        HitAction.started += HitActionOnstarted;
    }

    private void Start()
    {
        transform.DOMoveX(_currentPos, moveDuration);
    }

    private void HitActionOnstarted(InputAction.CallbackContext obj)
    {
        throw new NotImplementedException();
    }

    private void MoveActionOnstarted(InputAction.CallbackContext obj)
    {
        _currentPos *= -1;
        transform.DOMoveX(_currentPos, moveDuration, true);
    }
}
