using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GameObject hitObj = collision.gameObject;

        if (hitObj.CompareTag("Target"))
        {
            Debug.Log("Hit " + hitObj.name);

            // Stop animation
            Animator animator = hitObj.GetComponent<Animator>();
            if (animator != null)
                animator.enabled = false;

            // Enable physics reaction
            Rigidbody rb = hitObj.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
                rb.useGravity = true;
                rb.constraints = RigidbodyConstraints.None;
            }

            // Increment hit counter
            if (GameManager.Instance != null)
                GameManager.Instance.AddHit();

            // Destroy bullet
            Destroy(gameObject);
        }
    }
}