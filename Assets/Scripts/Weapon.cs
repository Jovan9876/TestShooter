using UnityEngine;

public class Weapon : MonoBehaviour {

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    private float fireForce = 20f;
    private float fireRate = 0.1f;
    private float lastFireTime;

    public void Fire() {
        if (Time.time - lastFireTime >= fireRate) {
            lastFireTime = Time.time;

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(firePoint.forward * fireForce, ForceMode.Impulse);
        }
    }
}

