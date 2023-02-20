using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilBugController : MonoBehaviour
{
    [SerializeField] private Transform characterPosition;
    [SerializeField] private List<Transform> list_waypoints;

    private float speed = 5f;
    private float speedRotation = 1.5f;
    private int currentWaypoint;

    private void Awake()
    {
        currentWaypoint = UnityEngine.Random.Range(0, list_waypoints.Count);
        transform.LookAt(list_waypoints[currentWaypoint].position);
    }

    void Start()
    {


    }

    void Update()
    {
        ExecFollow();
        ExecLook();


    }

    private void ExecFollow()
    {
        Vector3 follow = characterPosition.position - transform.position;
        var distance = follow.magnitude;

        if (distance > 5 && distance < 25)
        {
            transform.position += (follow.normalized * speed * Time.deltaTime);
        }
        else
        {
            PatrolBeetle();
        }

    }

    private void ExecLook()
    {
        Vector3 follow = characterPosition.position - transform.position;
        var distance = follow.magnitude;

        if (distance < 25)
        {
            var bugRotation = characterPosition.position - transform.position;
            var newRotation = Quaternion.LookRotation(bugRotation);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, speedRotation * Time.deltaTime);
        }
        else
        {
            PatrolBeetle();
        }
    }

    private void Move(Vector3 direction)
    {
        transform.position += (speed * direction * Time.deltaTime);
    }



    private void PatrolBeetle()
    {
        transform.LookAt(list_waypoints[currentWaypoint].position);
        var currntWaypoint = list_waypoints[currentWaypoint];
        var currntDifference = (currntWaypoint.position - transform.position);
        var direction = currntDifference.normalized;
        Move(direction);
        float currntDistance = currntDifference.magnitude;
        if (currntDistance <= 2f)
        {
            NextWaypoint();
        }


    }

    private void NextWaypoint()
    {
        currentWaypoint++;

        if (currentWaypoint >= list_waypoints.Count)
        {
            currentWaypoint = 0;
        }
        transform.LookAt(list_waypoints[currentWaypoint].position);

    }

}
