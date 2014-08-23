using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour
{
    public Color color = new Color(.985f, 0.022f, .022f, .2f);
    public List<Spawner> targets = new List<Spawner>();
    public Vector3 size = new Vector3(1, 1, 0);
    public float delay = 2.0f;
    
    private Vector2 direction = new Vector2(1, 1);
    private GameMaster _parentGameMaster;
    
    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawCube(transform.position, size);
        //targets = FindObjectsOfType<Spawner>().ToList();
        foreach (var t in targets)
        {
            Gizmos.DrawLine(transform.position, t.transform.position);
        }
    }

    public Spawner GetRandomTarget()
    {
        if (targets.Count == 0) return null;
        return targets[Random.Range(0, targets.Count)];
    }

    public Spawner GetTargetAt(int index)
    {
        return targets.Count == 0
            ? null
            : targets[index];
    }

    

    private void Start()
    {
        _parentGameMaster = gameObject.GetComponent<GameMaster>();
        targets = _parentGameMaster.targets;
        StartCoroutine(EnemyGenerator());
    }

    private IEnumerator EnemyGenerator()
    {
        if (active)
        {
            var newTransform = transform;
            yield return new WaitForSeconds(delay);

            if (targets.Count > 0)
            {
                var spawnTarget = _parentGameMaster.GetRandomTarget();
                newTransform = spawnTarget.transform;
                direction = spawnTarget.transform.localScale;

                var clone = (GameObject) Instantiate(
                    spawnTarget.enemyPool[Random.Range(0, spawnTarget.enemyPool.Length)], 
                    newTransform.position,
                    Quaternion.identity);
                clone.transform.localScale = direction;
                StartCoroutine(EnemyGenerator());
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }
}