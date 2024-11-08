using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputActionReference moveActionReference, hitActionReference;
    private InputAction MoveAction => moveActionReference.action;
    private InputAction HitAction => hitActionReference.action;
    private Rigidbody2D _rb;


    private float _currentPos = -2;
    [SerializeField, Range(0, 1)] private float moveDuration = .1f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Object")) {
            var obj = other.gameObject.GetComponent<IInteractable>();
            obj.Interact(this);
        }
    }

    public void Kill() {
        _rb.gravityScale = 0;
    }
}

public class Obstacle : MonoBehaviour, IInteractable
{
    public void Interact(PlayerController player) {
        player.Kill();
    }
}