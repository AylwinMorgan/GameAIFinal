using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CohesionRule : BoidRule
{
    public new Vector2 ComputeForce(List<Boid> neighbors, Boid boid)
    {
        Vector2 cohesionForce = Vector2.zero;
        Vector2 centerOfMass = Vector2.zero;
        float forceScalar = 4.0f;

        float distance;
        if (neighbors.Count != 0)
        {
            foreach (Boid b in neighbors)
            {
                centerOfMass += new Vector2(b.transform.position.x,b.transform.position.y);
            }
            centerOfMass /= neighbors.Count;
            cohesionForce = centerOfMass - new Vector2(boid.transform.position.x, boid.transform.position.y);
            distance = cohesionForce.magnitude;
            cohesionForce = cohesionForce.normalized * (distance / World.neighborhoodDistance);
        }

        return cohesionForce * forceScalar;
    }
}
