using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BeetleFlyController : MonoBehaviour
{

    private enum w_points{
        w_point1, w_point2
    }

    [SerializeField] private Transform characterPosition;
    private float speed = 10f;
    private float speedRotation = 1f;
    [SerializeField] GameObject atack;
    [SerializeField] Transform shootPoint;
    [SerializeField] private float intervalAtack;
    private float countDown;

    [SerializeField] private Transform t1, t2;
    [SerializeField] private w_points CurrentWayPoints;

    [SerializeField] private Dictionary<w_points, Transform> wpDiccionary =
        new Dictionary<w_points, Transform>();

    private Transform InitialWayPoint;

    private void populateDiccionary()
    {
        wpDiccionary.Add(w_points.w_point1, t1);
        wpDiccionary.Add(w_points.w_point2, t2);
    }

    void Awake()
    {
        populateDiccionary();

        if (wpDiccionary.TryGetValue(CurrentWayPoints, out var firtsWayPoint))
        {
            InitialWayPoint = firtsWayPoint;
        }


    }

    void Start()
    {
        ResetTime();
    }


    void Update()
    {
        ExecFollow();
        ExecLook();
        TimerAtack();
    }


    public void ExecFollow()
    {
        Vector3 follow = characterPosition.position - transform.position;
        var distance = follow.magnitude;

        if (distance > 12 && distance < 35)
        {
            transform.position += follow.normalized * (speed * Time.deltaTime);
        }
        else
        {
            Move();
        }
    }

    public void ExecLook()
    {
        Vector3 follow = characterPosition.position - transform.position;
        var distance = follow.magnitude;

        if (distance  < 35)
        {
            var bugRotation = characterPosition.position - transform.position;
            var newRotation = Quaternion.LookRotation(bugRotation);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, speedRotation * Time.deltaTime);
        }
        else
        {
            Move();
        }
    }



    public void ResetTime()
    {
        countDown = intervalAtack;
    }


    public void TimerAtack()
    {
        countDown -= Time.deltaTime;
        Vector3 follow = characterPosition.position - transform.position;
        var distance = follow.magnitude;

        if (countDown <= 0)
       
        {
            InicializeAtack();
            ResetTime();

        }

    }


    public void InicializeAtack()
    {
        

            Instantiate(atack, shootPoint.position, shootPoint.rotation);
        
    }




    private void Move()
    {

        transform.LookAt(InitialWayPoint.position);
        var currntDifference = InitialWayPoint.position - transform.position;
        var direction = currntDifference.normalized;
        float currntDistance = currntDifference.magnitude;
        if (currntDistance >= 2f)
        {

            transform.position += (speed * direction * Time.deltaTime);
        }
    }


    


}
