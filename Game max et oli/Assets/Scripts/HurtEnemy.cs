﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{

	
	void Start ()
    {
		
	}
	


	void Update ()
    {
		
	}



    void OnTriggerEnter2D(Collider2D weapon)
    {
        if(weapon.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemie toucher");
        }

    }


}
