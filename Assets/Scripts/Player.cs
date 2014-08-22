using System;
using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public float speed = 5;
    public float maxSpeed = 5;
    private int moving = 0;
    private float mouseX;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (Input.GetMouseButton(0))
	    {
	        mouseX = - 90 * ((Input.mousePosition.x - Screen.width / 2) / (Screen.width / 2));
	    }
	    else
	    {
	        mouseX = 0;
	    }
	    if (Input.GetKey("right") || mouseX < 0)
	    {
	        moving = 1;
        }
        else if (Input.GetKey("left") || mouseX > 0)
        {
            moving = -1;
        }
        else
        {
            moving = 0;
        }
	    if (moving != 0)
	    {
	        var velocityX = Math.Abs(rigidbody2D.velocity.x);
	        //if (velocityX < .5)
	        {
	            rigidbody2D.AddForce(new Vector2(moving, 0) * speed);
	            if (transform.localScale.x != moving)
	            {
	                transform.localScale = new Vector3(moving, 1, 1);
	            }
	        }
            if (velocityX > maxSpeed)
            {
                rigidbody2D.velocity = new Vector2(maxSpeed * moving, 0);
            }
	    }
	}
}
