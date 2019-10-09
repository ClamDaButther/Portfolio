using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSlam : MonoBehaviour {

    [SerializeField]
    private Transform player;
    private Vector3 target;

    [SerializeField]
    private float MoveSpeed;

    [SerializeField]
    private bool isMoving = false;
    private bool isSmashing = false;
    private bool isGoingUp = false;

    private float slamTimer;
    [SerializeField]
    private float slamWaitTime;
    [SerializeField]
    private float upwardWaitTime;

    void Update()
    {
        if (isMoving == true)
        {
            Move();
        }
        if (isSmashing == true)
        {
            Smash();
        }
        if (isGoingUp == true)
        {
            GoUp();
        }
    }

    private void Move()
    {
        target = new Vector3(player.position.x, player.position.y + 3f, player.position.z);
        transform.position = Vector3.MoveTowards(transform.position, target, MoveSpeed * Time.deltaTime);
        if (transform.position == target)
        {
            isMoving = false;
            isSmashing = true;
            print("Above Player");
        }
    }

    private void Smash()
    {
        slamTimer += Time.deltaTime;
        if (slamTimer >= slamWaitTime)
        {
            target = new Vector3(target.x, 1f, target.z);
            transform.position = Vector3.MoveTowards(transform.position, target, MoveSpeed * Time.deltaTime);
            if (transform.position == target)
            {
                print("Smashed Player");
                if(slamTimer >= upwardWaitTime)
                {
                    isSmashing = false;
                    isGoingUp = true;
                }
            }
        }
    }

    private void GoUp()
    {
        slamTimer += Time.deltaTime;
        print("Going Up");
        Vector3 targetUp = new Vector3(transform.position.x, 4f, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetUp, MoveSpeed* Time.deltaTime);
            if (transform.position == targetUp)
            {
            isGoingUp = false;
                slamTimer = 0;
            }
    }
}
