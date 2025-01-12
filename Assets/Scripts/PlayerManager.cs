using UnityEngine;

public class PlayerManager : MonoBehaviour {

    [SerializeField] private InputManager inputManager;
    [SerializeField] private Weapon weapon;
    private Rigidbody rb;
    public float moveSpeed = 25f;
    public float jumpForce = 5f;


    private void Start() {
        rb = GetComponent<Rigidbody>();
    }



    private void FixedUpdate() {
        // Movement
        Vector3 movement = new Vector3(InputManager.Instance.HorizontalInput, 0, InputManager.Instance.VerticalInput);
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        if (InputManager.Instance.IsJumping && Mathf.Abs(rb.linearVelocity.y) < 0.01f) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (InputManager.Instance.IsFiring) {
            weapon.Fire();
        }

    }
}
