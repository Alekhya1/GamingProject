using System.Linq;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float minDist = 0.75f;
    public float moveSpeed = 3;
    public float changeDirTime = 5;
    private float curChangeTime;
    private Vector2 curTarget;
    public int hp;

    void Start()
    {
        curChangeTime = changeDirTime;
        SetNewMoveTarget();
    }

    private void SetNewMoveTarget()
    {
        Vector2 cur = transform.position;
        float dist = 2 * moveSpeed * changeDirTime;
        curTarget = new Vector2(cur.x + Random.value * dist*2 - dist, cur.y + Random.value * dist * 2 - dist);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject closestPlayer = GetClosestPlayer();
        var dist = Vector2.Distance(transform.position, closestPlayer.transform.position);
        if (dist < minDist)
        {
            if (curChangeTime <= 0f || Vector2.Distance(transform.position, curTarget) <= 0)
            {
                SetNewMoveTarget();
                curChangeTime = changeDirTime;
            }
            transform.position = Vector2.MoveTowards(transform.position, curTarget, moveSpeed * Time.deltaTime);
            Debug.DrawLine(transform.position, curTarget, Color.blue);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, closestPlayer.transform.position, moveSpeed * Time.deltaTime);
            Debug.DrawLine(transform.position, closestPlayer.transform.position, Color.red);
        }
        curChangeTime -= Time.deltaTime;
        
    }

    private void FixedUpdate()
    {
        
    }

    private GameObject GetClosestPlayer()
    {
        return GameObject.FindGameObjectsWithTag("Player")
            .OrderBy(player => Vector2.Distance(transform.position, player.transform.position)).First();
    }
}
