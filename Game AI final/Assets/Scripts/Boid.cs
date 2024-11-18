using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Boid : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 velocity;
    Vector2 acceleration;
    BoidRule[] rules;
    List<Boid> neighbors;

    void Start()
    {
        World.boids.Append(this);
    }

    void ComputeNeighborhood()
    {
        neighbors.Clear();
        foreach (Boid b in World.boids)
        {
            if (World.GetBoidsAreNeighbors(this, b))
            {
                neighbors.Add(b);
            }
        }
    }

    void ApplyForce(Vector2 force)
    {
        acceleration += force;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ComputeNeighborhood();
        foreach (BoidRule b in rules)
        {
            ApplyForce(b.ComputeForce(neighbors,this));
        }

        if (acceleration.magnitude > World.maxAcceleration)
        {
            acceleration = acceleration.normalized * World.maxAcceleration;
        }

        velocity += acceleration;
        acceleration = Vector2.zero;
        Vector3 result = new Vector3(velocity.x*Time.deltaTime,velocity.y*Time.deltaTime,0);
        transform.position += result;
    }
}
