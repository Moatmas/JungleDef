using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 60f;
    public GameObject impactEffect;

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame )
        {
            HitTarget();
        }

        transform.Translate (dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate (impactEffect,transform.position,transform.rotation);
        Destroy(effectIns, 1.5f);


        Destroy(target.gameObject);
        Destroy (gameObject);
    }
}
