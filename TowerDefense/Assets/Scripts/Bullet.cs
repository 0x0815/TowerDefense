﻿using UnityEngine;

public class Bullet : MonoBehaviour {

    public float bulletSpeed = 70f;
    public GameObject impactEffect;
    public float explosionRadius = 0f;
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
        transform.LookAt(target);
	}

    private void HitTarget()
    {
        GameObject effectInstance = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInstance, 5f);

        if(explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject);
        return;
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy)
    {
        Destroy(enemy.gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
