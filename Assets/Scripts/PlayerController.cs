using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputActionReference moveActionReference, hitActionReference;
    private InputAction MoveAction => moveActionReference.action;
    private InputAction HitAction => hitActionReference.action;
    private Rigidbody2D _rb;
    
    private Animator _animator;
    
    private float _currentPos = -12;
    [SerializeField, Range(0, 1)] private float moveDuration = .1f;
    
    [SerializeField] private GameObject EndUI;
    
    private IInteractable _currentInteractable;
    public IInteractable CurrentInteractable {set => _currentInteractable = value;}

    private void Awake() {
        _animator = GetComponent<Animator>();
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
        if (_currentInteractable != null) {
            _currentInteractable.Interact(this);
        }
    }

    private void MoveActionOnstarted(InputAction.CallbackContext obj)
    {
        _currentPos *= -1;
        transform?.DOMoveX(_currentPos, moveDuration, true);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Object")) {
            var obj = other.gameObject.GetComponent<IInteractable>();
            obj.Hit(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Object")) {
            var obj = other.gameObject.GetComponent<IInteractable>();
            obj.Hit(this);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Object")) {
            CurrentInteractable = null;
        }
    }

    public void Kill() {
        _animator.SetTrigger("Land");
        UnityEngine.Camera.main.DOShakePosition(1,10,5);
        _rb.gravityScale = 0;
        _rb.velocity = new Vector2(0, 0);
        MoveAction.started -= MoveActionOnstarted;
        HitAction.started -= HitActionOnstarted;
        MoveAction.Disable();
        HitAction.Disable();
        EndUI.SetActive(true);
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}