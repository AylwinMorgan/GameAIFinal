using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeperationRule : BoidRule
{
    public override Vector2 ComputeForce(List<Boid> neighbors, Boid boid)
    {
        // Try to avoid boids too close
        Vector2 separatingForce = Vector2.zero;
        float desiredDistance = 3f;

        float forceScalar = 0.4f;
        // todo: implement a force that if neighbor(s) enter the radius, moves the boid away from it/them
        if (neighbors.Count != 0)
        {
            Vector2 position = boid.transform.position;
            foreach (Boid b in neighbors)
            {
                Vector2 force = position - new Vector2(b.transform.position.x, b.transform.position.y);
                float distance = force.magnitude;
                if (distance < desiredDistance && distance > 0.01f)
                {
                    force = force.normalized / (distance / desiredDistance);
                    separatingForce += force;
                }
                else if (distance == 0)
                {
                    return Vector2.zero;
                }
            }
        }

        return separatingForce * forceScalar;
    }
}
