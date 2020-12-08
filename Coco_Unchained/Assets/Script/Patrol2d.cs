using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol2d : MonoBehaviour
{
    public float speed;

    public Transform[] moveSpots;
    public int destinationPoint = 0;

    public float minRemainingDistance = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lookAt();
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[destinationPoint].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, moveSpots[destinationPoint].position)< minRemainingDistance)
        {
            GoToNextPoint();
        }
    }

    void GoToNextPoint()
    {
        if (moveSpots.Length == 0)
        {
            return;

        }        
        destinationPoint = (destinationPoint + 1) % moveSpots.Length;
    }

    void lookAt() 
    {
        var dir = moveSpots[destinationPoint].position-transform.position;
        var angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    } 
}
