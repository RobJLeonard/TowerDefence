using UnityEngine;

public class Bullet : MonoBehaviour {

    public float bulletSpeed = 15f;
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
		
	}

    void HitTarget()
    {

        GameObject effInstance = (GameObject) Instantiate(hitEffect, transform.position, transform.rotation);
        Destroy(effInstance, 2f);
        Destroy(target.gameObject);
        Destroy(gameObject);
    }
}
