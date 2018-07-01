using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsManager : MonoBehaviour
{
    List<Transform> waypoints = new List<Transform>();

    void Start ()
    {
        foreach (Transform child in transform)
        {
            waypoints.Add(child);
        }
    }

    public Transform GetRandomWaypoint()
    {
        if (waypoints.Count <= 0) return transform;
        return waypoints[Random.Range(0, waypoints.Count)];
    }
}
