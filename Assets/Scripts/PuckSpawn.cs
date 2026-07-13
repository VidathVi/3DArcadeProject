using UnityEngine;
using System.Collections;

public class PuckSpawner : MonoBehaviour
{
    public GameObject puckPrefab;
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 3f;
    public float firingForce = 15f;
    public float angleRange = 30f; // Degrees left or right

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            FirePuck();
        }
    }

    void FirePuck()
    {
        // 1. Instantiate the puck at the spawner's position
        GameObject newPuck = Instantiate(puckPrefab, transform.position, Quaternion.identity);
        Rigidbody rb = newPuck.GetComponent<Rigidbody>();

        // 2. Calculate a random angle towards the player
        // Assumes spawner is facing the player (along the -Z or +Z axis)
        float randomAngle = Random.Range(-angleRange, angleRange);
        Vector3 forceDirection = Quaternion.Euler(0, randomAngle, 0) * -transform.forward;

        // 3. Launch the puck
        rb.AddForce(forceDirection * firingForce, ForceMode.Impulse);
        
        // 4. Optional: Destroy puck after 10 seconds to keep the scene clean
        Destroy(newPuck, 5f);
    }
}