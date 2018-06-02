using System;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 10f;
    private Transform target;
    private int wayPointIndex;

    private void Start()
    {
        target = Waypoints.ponits[0];
    }

    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.5f)
        {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        if (wayPointIndex >= Waypoints.ponits.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        wayPointIndex++;
        target = Waypoints.ponits[wayPointIndex];
    }
}
