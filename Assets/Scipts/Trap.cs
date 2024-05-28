using UnityEngine;

public class Trap : MonoBehaviour
{
    public float damage = 50f;
    public HealthManager healthManager;

    private void Start()
    {
        healthManager = GetComponentInParent<HealthManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            healthManager.TakeDamage(10f);
        }
    }
}
