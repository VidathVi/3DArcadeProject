using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawn;
    public float bulletVelocity = 30f;
    public float bulletLifeTime = 5f;

    public int maxBullets = 10;
    private int bulletsFired = 0;

    void Update()
    {
        // Stop firing if the game is over
        if (GameManager.Instance != null && GameManager.Instance.isGameOver) return;

        if (Input.GetKeyDown(KeyCode.Mouse0) && bulletsFired < maxBullets)
        {
            FireGun();
        }
    }

    private void FireGun()
    {
        GameObject newBullet = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        Rigidbody rb = newBullet.GetComponent<Rigidbody>();
        rb.linearVelocity = bulletSpawn.forward * bulletVelocity;
        Destroy(newBullet, bulletLifeTime);

        bulletsFired++;

        // Calculate remaining bullets and tell GameManager
        int remaining = maxBullets - bulletsFired;
        if (GameManager.Instance != null)
        {
            GameManager.Instance.CheckLossCondition(remaining);
        }
    }
}