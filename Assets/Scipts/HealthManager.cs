using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public float startHealth = 100f;
    public float health;
    public Image healthbar;

    private void Start()
    {
        health = startHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
      
        healthbar.fillAmount = health / startHealth;

        if (health == 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
