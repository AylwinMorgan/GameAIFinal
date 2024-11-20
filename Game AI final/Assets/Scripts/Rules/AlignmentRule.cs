using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignmentRule : BoidRule
{
    public override Vector2 ComputeForce(List<Boid> neighbors, Boid boid)
    {
        // Try to match the heading of neighbors = Average velocity
        Vector2 averageVelocity = Vector2.zero;
        float forceScalar = 3.0f;

        foreach (Boid b in neighbors)
        {
            averageVelocity += b.velocity;
        }
        if (neighbors.Count != 0)
        {
            averageVelocity /= neighbors.Count;
        }
        return averageVelocity.normalized * forceScalar;
    }
}
