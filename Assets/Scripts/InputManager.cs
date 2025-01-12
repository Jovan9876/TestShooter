using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour {
    public static InputManager Instance { get; private set; }

    private InputActions inputActions;
    private Vector2 movementInput;

    public float HorizontalInput { get; private set; }
    public float VerticalInput { get; private set; }
    public bool IsJumping { get; private set; }
    public bool IsFiring { get; private set; }

    private void Awake() {
        // Singleton Pattern
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Initialize Input Actions
        inputActions = new InputActions();
    }

    private void OnEnable() {
        // Enable Action Maps
        inputActions.Player.Enable();

        // Bind Input Events
        inputActions.Player.Movement.performed += OnMovementPerformed;
        inputActions.Player.Movement.canceled += OnMovementCanceled;
        inputActions.Player.Jump.performed += OnJumpPerformed;
        inputActions.Player.Jump.canceled += OnJumpCanceled;
        inputActions.Player.Fire.performed += OnFirePerformed;
        inputActions.Player.Fire.canceled += OnFireCanceled;
    }

    private void OnDisable() {
        // Disable Action Maps
        inputActions.Player.Disable();

        // Unbind Input Events
        inputActions.Player.Movement.performed -= OnMovementPerformed;
        inputActions.Player.Movement.canceled -= OnMovementCanceled;
        inputActions.Player.Jump.performed -= OnJumpPerformed;
        inputActions.Player.Jump.canceled -= OnJumpCanceled; 
        inputActions.Player.Fire.performed -= OnFirePerformed;
        inputActions.Player.Fire.canceled -= OnFireCanceled;
    }

    private void Update() {
        // Update Input Values
        HorizontalInput = movementInput.x;
        VerticalInput = movementInput.y;
    }

    private void OnMovementPerformed(InputAction.CallbackContext context) {
        movementInput = context.ReadValue<Vector2>();
    }

    private void OnMovementCanceled(InputAction.CallbackContext context) {
        movementInput = Vector2.zero;
    }

    private void OnJumpPerformed(InputAction.CallbackContext context) {
        IsJumping = true;
    }

    private void OnJumpCanceled(InputAction.CallbackContext context) {
        IsJumping = false;
    }

    private void OnFirePerformed(InputAction.CallbackContext context) {
        IsFiring = true;
    }

    private void OnFireCanceled(InputAction.CallbackContext context) {
        IsFiring = false;
    }

}
