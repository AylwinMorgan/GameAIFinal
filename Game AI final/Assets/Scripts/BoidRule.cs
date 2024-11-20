using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidRule
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public virtual Vector2 ComputeForce(List<Boid> neighbors, Boid boid)
    {
        return Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
