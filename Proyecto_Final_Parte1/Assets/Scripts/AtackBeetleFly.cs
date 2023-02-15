using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackBeetleFly : MonoBehaviour
{
    
    public float speed;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        MovementAtack();
        

    }


    public void MovementAtack()
    {

        Vector3 follow = player.position - transform.position;
        var distance = follow.magnitude;

            
            transform.position += follow.normalized * (speed * Time.deltaTime);


    }

    
    public void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
    
}
