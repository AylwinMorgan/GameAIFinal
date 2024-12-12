using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class World
{
    public static List<Boid> boids = new List<Boid>();
    public static float neighborhoodDistance = 0.1f;
    public static float maxVelocity = 3f;
    public static int boidAmount = 30;
    public static float maxX = 10f;
    public static float maxY = 10f;
    public static float minX = -10f;
    public static float minY = -10f;

    public static bool GetBoidsAreNeighbors(Boid b1, Boid b2)
    {
        if (b1 != b2)
        {
            float xDist = b1.transform.position.x - b2.transform.position.x;
            float yDist = b1.transform.position.y - b2.transform.position.y;
            float distanceSquare = (xDist*xDist) + (yDist*yDist);

            if (distanceSquare < neighborhoodDistance * neighborhoodDistance)
            {
                return true;
            }
        }
        return false;
    }   
}
