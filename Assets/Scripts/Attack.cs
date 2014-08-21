using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour
{
    public int attackValue = 1;
    public float attackDelay = 1f;
    public string targetTag;
    private bool canAttack;

	// Use this for initialization
	void Start () {
	    if (attackValue <= 0)
	    {
	        canAttack = false;
	    }
	    else
	    {
	        StartCoroutine(OnAttack());
	    }
	}

    private IEnumerator OnAttack()
    {
        yield return new WaitForSeconds(attackDelay);
        canAttack = true;
        StartCoroutine(OnAttack());
    }

    private void OnCollisionStay2D(Collision2D c)
    {
        if (c.gameObject.tag == targetTag)
        {
            if (canAttack)
            {
                TestAttack(c.gameObject);
            }
        }
    }

    private void TestAttack(GameObject target)
    {
        if (transform.localScale.x == 1)
        {
            if (target.transform.position.x > transform.position.x)
            {
                AttackTarget(target);
            }
        }
        else
        {
            if (target.transform.position.x < transform.position.x)
            {
                AttackTarget(target);
            }
        }
        canAttack = false;
    }

    private void AttackTarget(GameObject target)
    {
        var healthComp = target.gameObject.GetComponent<Health>();
        if (healthComp)
        {
            healthComp.TakeDamage(attackValue);
        }
    }

    // Update is called once per frame
	void Update () {
	
	}
}
