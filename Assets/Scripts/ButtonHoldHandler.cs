using UnityEngine;

public class ButtonHoldHandler : MonoBehaviour {
    [SerializeField] private Weapon weapon; // Reference to your Weapon script
    private bool isShooting = false;

    private void Update() {
        // If the button is held down, call the Fire method continuously
        if (isShooting) {
            weapon.Fire();
        }
    }

    // Called when the button is pressed
    public void StartShooting() {
        isShooting = true;
    }

    // Called when the button is released
    public void StopShooting() {
        isShooting = false;
    }
}
