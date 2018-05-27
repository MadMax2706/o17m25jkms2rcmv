using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 playerPosition;
    public float cameraMoveSpeed;
	
	void Start ()
    {
		
	}
	
	

	void Update ()
    {
        playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, -1);

        transform.position = Vector3.Lerp(transform.position, playerPosition, cameraMoveSpeed * Time.deltaTime);
    }

}