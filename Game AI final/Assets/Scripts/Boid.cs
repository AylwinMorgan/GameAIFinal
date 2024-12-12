using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
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
    bool boidWillDieInDangerousZone = false;
    List<GameObject> adjacentWalls;

    void Start()
    {
        //velocity = new Vector2(Random.Range(-3f,3f),Random.Range(-3f,3f));
        velocity = Vector2.zero;
        rules = new List<BoidRule> ();
        neighbors = new List<Boid> ();
        //rules.Add(new SeperationRule());
        //rules.Add(new CohesionRule());
        //rules.Add(new AlignmentRule());
        //rules.Add(new AvoidWallsRule());
        World.boids.Add(this);
        flipWillDie();
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
        NavMeshHit navMeshHit;
        GetComponent<NavMeshAgent>().SamplePathPosition(NavMesh.AllAreas, 0f, out navMeshHit);
        if (navMeshHit.mask != 1 && navMeshHit.mask != 32 && boidWillDieInDangerousZone)
        {
            Debug.Log(navMeshHit.mask);
            gameObject.SetActive(false);
        }
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
    }

    private void LateUpdate()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        float angle = Mathf.Atan(agent.velocity.y / agent.velocity.x) * Mathf.Rad2Deg;
        if (agent.velocity.y < 0 && agent.velocity.x < 0)
        {
            angle *= -1;
            angle += 360;
        }

        transform.eulerAngles = new Vector3(0f, 0f, 90f);
        /*
        if (angle >= 0 && angle < 180)
        {
            if (angle <= 90)
            {
                transform.eulerAngles = new Vector3(0f, 0f, angle + 270f);
            }
            else
            {
                transform.eulerAngles = new Vector3(0f, 0f, angle + 90f);
            }
        }
        else
        {
            if (angle >= 270)
            {
                transform.eulerAngles = new Vector3(0f, 0f, angle + 90f);
            }
            else {
                transform.eulerAngles = new Vector3(0f, 0f, angle + 270f);
            }
        }
        */
    }

    public void flipWillDie()
    {
        int rng = Random.Range(0, 99);
        if (rng < 50)
        {
            boidWillDieInDangerousZone = true;
        }
        else
        {
            boidWillDieInDangerousZone = false;
        }
    }
}
