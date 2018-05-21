using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 10f;

    private Transform target;
    private int waypointIndex = 0;

    private void Start()
    {
        target = Waypoints_Script.points[0];
    }

    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.5f)
        {
            getNextWaypoint();
        }
    }

    void getNextWaypoint()
    {
        if(waypointIndex >= Waypoints_Script.points.Length -1)
        {
            Destroy(gameObject);
            return;
        }

        waypointIndex++;
        target = Waypoints_Script.points[waypointIndex];
    }
}
