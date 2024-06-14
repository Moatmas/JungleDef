using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static WaveSpawner;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 15f;

    [HideInInspector]
    public float speed;

    public float Starthealth = 100f;
    public float health;
    public int moneyOnKill = 10;
    public int scoreOnKill = 15;
    public Image healthbar;

    private WaveSpawner waveSpawner;

    private void Start()
    {
        speed = startSpeed;
        health = Starthealth;
        waveSpawner = GameObject.FindObjectOfType<WaveSpawner>();
    }

    public void ApplyWaveCoef(float coef, int difficulty)
    {
        float difficultyCoefSpeed = 1f;
        float difficultyCoefHealth =1f;
        switch (difficulty)
        {
            case 0:
                difficultyCoefHealth = 0.75f;
                difficultyCoefSpeed = 0.9f;
                break;
            case 1:
                difficultyCoefHealth = 0.9f;
                difficultyCoefSpeed = 0.95f;
                break;

        }
        startSpeed *= (1 + (coef/3))* difficultyCoefSpeed;
        Starthealth *= (1 + (coef)) * difficultyCoefHealth;
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
        PlayerStats.Money += moneyOnKill;
        PlayerStats.Score += scoreOnKill;
        Destroy(gameObject);
    }

}
