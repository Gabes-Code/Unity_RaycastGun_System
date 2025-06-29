using UnityEngine;

public class TargetDummy : MonoBehaviour, IDamageable
{
    public float health = 50f;

    public void TakeDamage(float amount)
    {
        health -= amount;
        Debug.Log($"{gameObject.name} took {amount} damage. Remaining: {health}");

        if (health <= 0)
        {
            Debug.Log($"{gameObject.name} died.");
            Destroy(gameObject);
        }
    }
}
