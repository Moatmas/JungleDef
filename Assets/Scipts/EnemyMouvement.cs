using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMouvement : MonoBehaviour
{
   
    private Transform target;
    private int wavepointIndex = 0;
    
    private Enemy enemy;
    

    private void Start()
    {
        enemy = GetComponent<Enemy>();  
        target = Waypoints.points[0];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }

        enemy.speed = enemy.startSpeed;

    }
 
    void GetNextWaypoint()
    {
        if(wavepointIndex >= Waypoints.points.Length - 1)
        {
            PlayerStats.Lives--;
            Destroy(gameObject);
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }
}
