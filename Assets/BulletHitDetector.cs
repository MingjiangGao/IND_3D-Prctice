using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int TargetValue = 1;
    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the squad prefab
        if (collision.gameObject.CompareTag("Target"))
        {
            // Destroy the squad prefab
            Destroy(collision.gameObject);
            
            // Destroy the bullet
            Destroy(gameObject);

            // Add the score
            if (GameManager.Instance != null){
                GameManager.Instance.BulletHitTarget(TargetValue);
            }

        }
    }
}
