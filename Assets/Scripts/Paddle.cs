using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float mouseSensitivity = 50f;
    public Rigidbody rb;

    // Boundaries (Adjust these based on your table size)
    public float xLimit = 4.5f;
    public float zMin = -7.5f;
    public float zMax = -0.5f; // Stops at the center line

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        
        // Ensure the paddle is Kinematic so it isn't pushed by the puck
        rb.isKinematic = true;
    }

    void FixedUpdate()
    {
        // 1. Get Mouse Input
        float moveX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.fixedDeltaTime;
        float moveZ = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.fixedDeltaTime;

        // 2. Calculate New Position
        Vector3 newPosition = rb.position + new Vector3(moveX, 0f, moveZ);

        // 3. Clamp Position (Keep paddle on your half)
        newPosition.x = Mathf.Clamp(newPosition.x, -xLimit, xLimit);
        newPosition.z = Mathf.Clamp(newPosition.z, zMin, zMax);
        
        // Keep Y constant so it doesn't sink into or float above the table
        newPosition.y = rb.position.y;

        // 4. Move Rigidbody
        rb.MovePosition(newPosition);
    }
}