using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneWalk : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] patrolPoints;
    public int patrolIndex;
    public float spd = 3;
    public float waitTime;
    private float currentTime;
    void Start()
    {
        transform.position = patrolPoints[patrolIndex].position;
        currentTime = waitTime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[patrolIndex].position,
            spd * Time.deltaTime);
        if (transform.position == patrolPoints[patrolIndex].position)
        {
            if (currentTime > 0)
            {
                patrolIndex++;

                if (patrolIndex >= patrolPoints.Length)
                {
                    patrolIndex = 0;
                }
                currentTime = waitTime;
            }

            else
            {
                currentTime -= Time.deltaTime;
            }
        }
    }
}
