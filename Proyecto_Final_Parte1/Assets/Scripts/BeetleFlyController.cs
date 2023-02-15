using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BeetleFlyController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private float speed = 10f;
    private float speedRotation = 1f;
    [SerializeField] GameObject atack;
    [SerializeField] Transform shootPoint;
    [SerializeField] private float intervalAtack;
    private float countDown;


    void Start()
    {
        ResetTime();
    }

    // Update is called once per frame
    void Update()
    {
        ExecFollow();
        ExecLook();
        TimerAtack();


    }

    public void ExecFollow()
    {
        Vector3 follow = player.position - transform.position;
        var distance = follow.magnitude;

        if (distance > 12 && distance < 35)
        {
            transform.position += follow.normalized * (speed * Time.deltaTime);
        }

       

    }

    public void ExecLook()
    {
        Vector3 follow = player.position - transform.position;
        var distance = follow.magnitude;

        if (distance  < 35)
        {
            var bugRotation = player.position - transform.position;
            var newRotation = Quaternion.LookRotation(bugRotation);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, speedRotation * Time.deltaTime);
        }
    }



    public void ResetTime()
    {
        countDown = intervalAtack;
    }


    public void TimerAtack()
    {
        countDown -= Time.deltaTime;
        Vector3 follow = player.position - transform.position;
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









}
