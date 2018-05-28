using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyView : MonoBehaviour
{

    [HideInInspector]
    public bool playerinField = false;
    [HideInInspector]
    public bool playerExit = false;


    void OnTriggerEnter2D(Collider2D enemyView)
    {
        if (enemyView.gameObject.tag == "Player")
        {
            playerinField = true;
            playerExit = false;
        }

    }



    void OnTriggerExit2D(Collider2D enemyView)
    {
        if (enemyView.gameObject.tag == "Player")
        {
            playerinField = false;
            playerExit = true;
        }

    }


}
