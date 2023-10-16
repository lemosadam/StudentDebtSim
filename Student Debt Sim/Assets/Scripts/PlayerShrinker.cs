using UnityEngine;

public class PlayerShrinker : MonoBehaviour
{
    public float shrinkAmount = 0.1f; 

    public void ShrinkPlayer(Transform playerTransform)
    {
        Vector3 currentScale = playerTransform.localScale;
        currentScale -= new Vector3(shrinkAmount, shrinkAmount, shrinkAmount);
        playerTransform.localScale = currentScale;
    }
}
