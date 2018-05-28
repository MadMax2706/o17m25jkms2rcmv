using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyAI : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed;
    public float distanceChasing;
    public float enemyMovingArea;
    public float timeBeforeMoving;
    private float timerCountDownBeforeMoving;
    private Vector2 randomPosition;
    private bool canMove = true;
    private bool findRandomPosition = true;
    private bool chaseMode = false;


    void Start ()
    {
        timerCountDownBeforeMoving = timeBeforeMoving;
	}
	
	

	void Update ()
    {
        TimerBeforeMoving();
        Moving();
        Chase();
        Lost();
	}



    private void TimerBeforeMoving()
    {
        timerCountDownBeforeMoving -= Time.deltaTime;

        if(timerCountDownBeforeMoving < 0)
        {
            canMove = true;
            timerCountDownBeforeMoving = timeBeforeMoving;
        }

    }



    private void Moving()
    {
        if(canMove == true && chaseMode == false)
        {
            if(findRandomPosition == true)
            {
                randomPosition = Random.insideUnitCircle * enemyMovingArea;
                findRandomPosition = false;
            }

            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), randomPosition, moveSpeed * Time.deltaTime);

            if(transform.position.x == randomPosition.x && transform.position.y == randomPosition.y)
            {
                canMove = false;
                findRandomPosition = true;
            }
        }

    }



    private void Chase()
    {
        if(GetComponentInChildren<BasicEnemyView>().playerinField == true)
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), player.transform.position, moveSpeed * Time.deltaTime);
            chaseMode = true;
        }

        else if(GetComponentInChildren<BasicEnemyView>().playerExit == true && Vector2.Distance(transform.position, player.transform.position) < distanceChasing)
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), player.transform.position, moveSpeed * Time.deltaTime);
            chaseMode = true;
        }

    }

    private void Lost()
    {
        if (Vector2.Distance(transform.position, player.transform.position) > distanceChasing)
        {
            GetComponentInChildren<BasicEnemyView>().playerExit = false;
            chaseMode = false;
        }

    }
}
