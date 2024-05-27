using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMouvement : MonoBehaviour
{
    public float speed = 15f;
    public float Starthealth =100f;
    public float health;
    private Transform target;
    private int wavepointIndex = 0;
    public Image healthbar;
    

    private void Start()
    {
        target = Waypoints.points[0];
        health = Starthealth;
    }

    public void TakeDamage(float amount){
        health -= amount;
        
        healthbar.fillAmount = health / Starthealth;
        if(health<=0){
            Die();
        }
    }

    private void Die(){
        Destroy(gameObject);
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }

    }
 


    void GetNextWaypoint()
    {
        if(wavepointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }
}
