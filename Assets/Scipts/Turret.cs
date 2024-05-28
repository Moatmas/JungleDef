using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Turret : MonoBehaviour
{

    private Transform target;
    private Enemy targetEnemy;


    [Header("General")]

    public float range = 15f;

    [Header("Use Bullets")]

    public GameObject bulletAsset;
    public float fireRate = 1f;
    private float fireCountDown = 0f;

    [Header("Use Laser")]

    public bool useLaser = false;

    public int damageOverTime = 30;
    public float slowPct = .5f;

    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;


    [Header("Setup Fields")]

    public string enemyTag = "Enemy";

    public Transform touretToRotate;
    public float turnSpeed = 10f;
    
    public Transform firePoint;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.3f);
        
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if ( distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
            
        }

        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>(); 
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if (target == null)
        {
            if(useLaser)
            {
                if(lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    impactEffect.Stop();
                }
            }
            return;
        }
            
        LockOnTarget();

        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountDown <= 0f)
            {
                Shoot();
                fireCountDown = 1f / fireRate;
            }
            fireCountDown -= Time.deltaTime;
        }
    }

    void Laser()
    {
        targetEnemy.Slow(slowPct);


        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
        }
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;

        impactEffect.transform.position = target.position + dir.normalized;
        impactEffect.transform.rotation = Quaternion.LookRotation(dir);

        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
    }

    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(touretToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        touretToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Shoot()
    {
        if (target != null)
        {
            GameObject bulletGO = (GameObject)Instantiate(bulletAsset, firePoint.position, firePoint.rotation);
            Bullet bullet = bulletGO.GetComponent<Bullet>();

            if (bullet != null)
                bullet.SetTarget(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);   
    }
}
