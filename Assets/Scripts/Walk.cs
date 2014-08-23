using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Walk : MonoBehaviour
{
    public float speed = .3f;
    public bool touching = false;

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (touching)
	    rigidbody2D.velocity = new Vector2(this.transform.localScale.x * -1, 0) * speed;
	}

    void OnCollisionStay2D(Collision2D c)
    {
        touching = true;
    }
}
