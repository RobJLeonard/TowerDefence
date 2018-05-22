using UnityEngine;

public class Bullet : MonoBehaviour {

    public float bulletSpeed = 15f;
    public float explosionRadius = 0f;
    private Transform target;

    public GameObject hitEffect;

    public void Seek(Transform _target)
    {
        target = _target;
    }

	// Update is called once per frame
	void Update ()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = bulletSpeed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
		
	}

    void HitTarget()
    {

        GameObject effInstance = (GameObject) Instantiate(hitEffect, transform.position, transform.rotation);
        Destroy(effInstance, 2f);

        if(explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

       
        Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if(collider.tag == "Enemy")
                Damage(collider.transform);
        }
    }

    void Damage(Transform enemy)
    {
        Destroy(enemy.gameObject);
        PlayerStats.Money += 25;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
