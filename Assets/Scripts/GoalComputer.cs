using UnityEngine;

public class OpponentGoal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Puck"))
        {
            GameManagerHockey.instance.PlayerScored();
            Destroy(other.gameObject);
        }
    }
}