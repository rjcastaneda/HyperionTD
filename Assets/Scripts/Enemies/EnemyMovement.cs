using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public List<Transform> waypoints;
    public Transform theWaypoints;
    public Transform enemyT;

    public bool isMoving;
    public int wpIndex;
    public float distance;
    public float distanceThreshold;

    private Transform waypoint;
    private Vector3 nextPos;
    private Enemy _enemy;
    private float moveSpeed;

    private void Awake()
    {
       //Initializing objects.
       enemyT = this.gameObject.GetComponent<Transform>();
       theWaypoints = GameObject.Find("EnemyWaypoints").GetComponent<Transform>();
       _enemy = this.gameObject.GetComponent<Enemy>();
       foreach (Transform child in theWaypoints)
       {
           waypoints.Add(child);
       }

       //setting defaults
       wpIndex = 0;
       waypoint = waypoints[wpIndex];
       isMoving = true;
       distanceThreshold = .2f;
    }

    private void Update()
    {
        if(isMoving && wpIndex < waypoints.Count)
        {
            waypoint = waypoints[wpIndex];
            MoveToWaypoint(); 
        }

        if(!isMoving)
        {
            wpIndex++;
            isMoving = true;
        }
    }

    private void MoveToWaypoint()
    {
        nextPos = waypoint.position;
        moveSpeed = _enemy.moveSpeed;
        enemyT.position = Vector3.MoveTowards(enemyT.position,nextPos,Time.deltaTime * moveSpeed);
        distance = Vector3.Distance(enemyT.position, nextPos);
        if ( distance <= distanceThreshold)
        {
          isMoving = false;
        }
    }
}
