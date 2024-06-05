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
    public int moneyOnKill = 10;
    public Image healthbar;

    private WaveSpawner waveSpawner;

    private void Start()
    {
        speed = startSpeed;
        health = Starthealth;
        waveSpawner = GameObject.FindObjectOfType<WaveSpawner>();
        if (waveSpawner != null)
        {
            waveSpawner.enemiesAlive++;
        }
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
        PlayerStats.Money += moneyOnKill;
        waveSpawner.enemiesAlive--;
        Destroy(gameObject);
    }

}
