using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 15f;

    [HideInInspector]
    public float speed;

    public float Starthealth = 100f;
    public float health;
    public Image healthbar;

    private void Start()
    {
        speed = startSpeed;
        health = Starthealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthbar.fillAmount = health / Starthealth;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Slow(float pct)
    {
        speed = startSpeed * (1f-pct);
    }

    private void Die()
    {
        Destroy(gameObject);
    }

}
