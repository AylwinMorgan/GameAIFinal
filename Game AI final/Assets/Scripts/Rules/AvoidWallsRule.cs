using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidWallsRule : BoidRule
{
    public override Vector2 ComputeForce(List<Boid> neighbors, Boid boid)
    {
        Vector2 totalForce = Vector2.zero;
        foreach (GameObject w in GameObject.FindGameObjectsWithTag("Walls"))
        {
            BoxCollider box = w.GetComponent<BoxCollider>();
            float width =  box.bounds.size.x;
            float height = box.bounds.size.y;
            float wallLeft = w.transform.position.x - width / 2;
            float wallRight = w.transform.position.x + width / 2;
            float wallTop = w.transform.position.y + height / 2;
            float wallBottom = w.transform.position.y - height / 2;
            float distance = -1f;

            if (boid.transform.position.x < wallLeft || boid.transform.position.x > wallRight)
            {
                if (boid.transform.position.y < wallTop && boid.transform.position.y > wallBottom)
                {
                    if (boid.transform.position.x < wallLeft)
                    {
                        distance = boid.transform.position.x - wallLeft;
                    }
                    else
                    {
                        distance = boid.transform.position.x - wallRight;
                    }
                    if (Mathf.Abs(distance) < World.neighborhoodDistance)
                    {
                        totalForce += new Vector2(10/distance, 0);
                    }
                }
            }
            else if (boid.transform.position.y > wallTop || boid.transform.position.y < wallBottom)
            {
                if (boid.transform.position.x > wallLeft && boid.transform.position.x < wallRight)
                {
                    if (boid.transform.position.y < wallBottom)
                    {
                        distance = boid.transform.position.y - wallBottom;
                    }
                    else
                    {
                        distance = boid.transform.position.y - wallTop;
                    }
                    if (Mathf.Abs(distance) < World.neighborhoodDistance)
                    {
                        totalForce += new Vector2(0, 10/distance);
                    }
                }
            }
        }
        return totalForce;
    }
}
