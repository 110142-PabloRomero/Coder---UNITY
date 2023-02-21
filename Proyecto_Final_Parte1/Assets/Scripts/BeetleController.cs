using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BeetleController : MonoBehaviour
{
    [SerializeField] private Transform characterPosition;
    [SerializeField] private Transform[] wayPoints;

    private float speed = 7f;
    private float speedRotation = 1f;
    private int currentWaypoint;

    private void Awake()
    {
        currentWaypoint = UnityEngine.Random.Range(0, wayPoints.Length);
        transform.LookAt(wayPoints[currentWaypoint].position);
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

        if (distance > 3 && distance < 25)
        {
            transform.position += follow.normalized * (speed * Time.deltaTime);
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
        transform.LookAt(wayPoints[currentWaypoint].position);
        var currntWaypoint= wayPoints[currentWaypoint];
        var currntDifference = (currntWaypoint.position - transform.position);
        var direction = currntDifference.normalized;
        Move(direction);
        float currntDistance= currntDifference.magnitude;
        if (currntDistance <= 2f)
        {
            NextWaypoint();
        }
       

    }

    private void NextWaypoint()
    {
        currentWaypoint++;
        
        if (currentWaypoint >= wayPoints.Length)
        {
            currentWaypoint = 0;
        }
        transform.LookAt(wayPoints[currentWaypoint].position);

    }


}
