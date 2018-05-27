using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyAI : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed;
    public float distanceChasing;

	void Start ()
    {
        
	}
	
	

	void Update ()
    {
        Chase();
        Lost();
	}


  
    private void Chase()
    {
        if(GetComponentInChildren<BasicEnemyView>().playerinField == true)
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), player.transform.position, moveSpeed * Time.deltaTime);
        }

        else if(GetComponentInChildren<BasicEnemyView>().playerExit == true && Vector2.Distance(transform.position, player.transform.position) < distanceChasing)
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), player.transform.position, moveSpeed * Time.deltaTime);
        }

    }

    private void Lost()
    {
        if (Vector2.Distance(transform.position, player.transform.position) > distanceChasing)
        {
            GetComponentInChildren<BasicEnemyView>().playerExit = false;
        }

    }
}
