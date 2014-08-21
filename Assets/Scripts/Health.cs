using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    public int maxHealth = 10;
    public int health = 10;
    public GameObject deathInstance = null;
    public Vector2 deathInstanceOffset = new Vector2(0,0);
	// Use this for initialization
	void Start ()
	{
	    health = maxHealth;
	}

    public void TakeDamage(int value)
    {
        health -= value;

        if (health <= 0)
        {
            OnKill();
        }
    }

    private void OnKill()
    {
        if (deathInstance)
        {
            var pos = gameObject.transform.position;
            var clone = (GameObject) Instantiate(deathInstance, new Vector3(
                pos.x + deathInstanceOffset.x,
                pos.y + deathInstanceOffset.y,
                pos.z), Quaternion.identity);
        }
        Destroy(gameObject);
    }

    // Update is called once per frame
	void Update () {
	
	}
}
