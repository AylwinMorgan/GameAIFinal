using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BoidMouseController : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera camera;

    //public NavMeshAgent agent;

    void Update()
    {
        // when LMB is pressed, agent will move to point if a valid point is clicked on
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                foreach (Boid b in World.boids)
                {
                    b.GetComponent<NavMeshAgent>().SetDestination(hit.point);
                }
            }
        }
    }
}
