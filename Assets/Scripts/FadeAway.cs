using UnityEngine;
using System.Collections;

public class FadeAway : MonoBehaviour
{
    public float delay = 2.0f;
	// Use this for initialization
	void Start ()
	{
	    StartCoroutine(FadeTo(0.0f, 1.0f));
	}

    private IEnumerator FadeTo(float value, float time)
    {
        yield return new WaitForSeconds(delay);

        float alpha = transform.renderer.material.color.a;
        for (float t = 0.0f; t <= 1.0f; t += Time.deltaTime / time)
        {
            var newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, value, t));
            transform.renderer.material.color = newColor;

            if (newColor.a <= .05)
            {
                Destroy(gameObject);
            }
            yield return null;
        }
    }

    // Update is called once per frame
	void Update () {
	
	}
}
