using UnityEngine;

public class PlayerGoal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // 1. Verify the Puck Tag
        if (other.CompareTag("Puck"))
        {
            // 2. Call the Opponent Scoring method
            GameManagerHockey.instance.OpponentScored();
            
            // 3. Destroy the puck
            Destroy(other.gameObject);
        }
    }
}