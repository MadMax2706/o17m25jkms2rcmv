using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
///////////////////A CHIER//////////////////////

    public bool attacking;
    public float attackTime;
    private float attackTimeCounter;
    private Animator anim;

	void Start ()
    {
        anim = GetComponent<Animator>();
	}
	
	

	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Q))
        {
            attackTimeCounter = attackTime;
            attacking = true;

            anim.SetBool("MeleeAttack", true);
        }

        if (attackTime > 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }

        if (attackTimeCounter <= 0)
        {
            attacking = false;
            anim.SetBool("MeleeAttack", false);
        }

    }


}