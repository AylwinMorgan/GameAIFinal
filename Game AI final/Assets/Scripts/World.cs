using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class World : object
{
    public static Boid[] boids;
    public static float neighborhoodDistance = 1f;
    public static float maxAcceleration = 10f;
    public static int boidAmount = 30;
    public static float fieldWidth = 10f;
    public static float fieldHeight = 10f;

    public static bool GetBoidsAreNeighbors(Boid b1, Boid b2)
    {
        if (b1 != b2)
        {
            float xDist = b1.transform.position.x - b2.transform.position.x;
            float yDist = b1.transform.position.y - b2.transform.position.y;
            float distanceSquare = (xDist*xDist) - (yDist*yDist);

            if (distanceSquare < neighborhoodDistance * neighborhoodDistance)
            {
                return true;
            }
        }
        return false;
    }
}
