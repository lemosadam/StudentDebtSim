using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public string playerTag = "Player"; 
    public float shrinkAmount = 0.1f; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            PlayerShrinker playerShrinker = other.GetComponent<PlayerShrinker>();

            if (playerShrinker != null)
            {
                playerShrinker.ShrinkPlayer(other.transform);
            }

            
            Destroy(gameObject);
        }
    }
}

