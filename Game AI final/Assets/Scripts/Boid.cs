using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Boid : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 velocity;
    Vector2 acceleration;
    List<BoidRule> rules;
    List<Boid> neighbors;
    List<GameObject> adjacentWalls;

    void Start()
    {
        velocity = new Vector2(Random.Range(-3f,3f),Random.Range(-3f,3f));
        rules = new List<BoidRule> ();
        neighbors = new List<Boid> ();
        rules.Add(new SeperationRule());
        rules.Add(new CohesionRule());
        rules.Add(new AlignmentRule());
        rules.Add(new AvoidWallsRule());
        World.boids.Add(this);
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
    void FixedUpdate()
    {
        ComputeNeighborhood();
        foreach (BoidRule b in rules)
        {
            ApplyForce(b.ComputeForce(neighbors,this));
        }

        velocity += acceleration;
        if (velocity.sqrMagnitude > World.maxVelocity * World.maxVelocity)
        {
            velocity = velocity.normalized * World.maxVelocity;
        }
        acceleration = Vector2.zero;
        Vector3 result = new Vector3(velocity.x*Time.deltaTime,velocity.y*Time.deltaTime,0);
        transform.position += result;

        transform.eulerAngles = new Vector3(0,0,-Mathf.Atan2(velocity.x, velocity.y) * Mathf.Rad2Deg);

        /*
        // loop boids around when they reach field borders
        if (transform.position.x > World.maxX)
        {
            transform.position = new Vector3(World.minX,transform.position.y,transform.position.z);
        }
        else if (transform.position.x < World.minX)
        {
            transform.position = new Vector3(World.maxX, transform.position.y, transform.position.z);
        }
        if (transform.position.y > World.maxY)
        {
            transform.position = new Vector3(transform.position.x, World.minY, transform.position.z);
        }
        else if (transform.position.y < World.minY)
        {
            transform.position = new Vector3(transform.position.x, World.maxY, transform.position.z);
        }
        */
    }
}
