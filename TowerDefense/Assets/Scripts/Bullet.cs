using UnityEngine;

public class Bullet : MonoBehaviour {

    public float bulletSpeed = 70f;
    public GameObject impactEffect;

    private Transform target;

    public void Seek (Transform _target)
    {
        target = _target;
    }
	
	// Update is called once per frame
	void Update () {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = bulletSpeed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
	}

    private void HitTarget()
    {
        GameObject effectInstance = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInstance, 3f);
        Destroy(gameObject);
        Destroy(target.gameObject);
        return;
    }
}
