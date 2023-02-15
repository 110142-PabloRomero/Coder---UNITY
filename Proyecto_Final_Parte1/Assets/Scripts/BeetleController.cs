using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BeetleController : MonoBehaviour
{
    [SerializeField] private Transform bug;
    private float speed = 10f;
    private float speedRotation = 0.5f;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ExecFollow();
        ExecLook();

    }

    public void ExecFollow()
    {
        Vector3 follow = bug.position - transform.position;
        var distance = follow.magnitude;

        if (distance > 3 && distance < 25)
        {
            transform.position += follow.normalized * (speed * Time.deltaTime);
        }

    }

    public void ExecLook()
    {
        Vector3 follow = bug.position - transform.position;
        var distance = follow.magnitude;

        if (distance < 25)
        {
            var bugRotation = bug.position - transform.position;
            var newRotation = Quaternion.LookRotation(bugRotation);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, speedRotation * Time.deltaTime);
        }
    }
}
