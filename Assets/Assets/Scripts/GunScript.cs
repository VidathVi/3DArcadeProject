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
        if (Input.GetKeyDown(KeyCode.Mouse0) && bulletsFired < maxBullets)
        {
            FireGun();
        }

        // Optional: Reload with R key
        if (Input.GetKeyDown(KeyCode.R))
        {
            bulletsFired = 0;
            Debug.Log("Reloaded!");
        }
    }

    private void FireGun()
    {
        GameObject newBullet = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        Rigidbody rb = newBullet.GetComponent<Rigidbody>();
        rb.linearVelocity = bulletSpawn.forward * bulletVelocity;
        Destroy(newBullet, bulletLifeTime);

        bulletsFired++;
        Debug.Log("Bullets fired: " + bulletsFired);
    }
}