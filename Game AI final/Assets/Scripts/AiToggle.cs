using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class AiToggle : MonoBehaviour
{
    bool aiIsTactical;
    Toggle toggle;
    int tacticalID;
    int basicID;
    // Start is called before the first frame update
    void Start()
    {
        toggle = GameObject.FindGameObjectWithTag("Toggle").GetComponent<Toggle>();
        tacticalID = (int)GetNavMeshAgentID("Tactical AI");
        basicID = (int)GetNavMeshAgentID("Basic AI");
    }

    // Update is called once per frame
    void Update()
    {
        aiIsTactical = toggle.isOn;
        int targetID;
        if (aiIsTactical)
        {
            targetID = tacticalID;
        }
        else
        {
            targetID = basicID;
        }
        if (World.boids.Count > 0)
        {
            foreach (Boid b in World.boids)
            {
                b.GetComponent<NavMeshAgent>().agentTypeID = targetID;
            }
        }
    }

    private int? GetNavMeshAgentID(string name)
    {
        for (int i = 0; i < NavMesh.GetSettingsCount(); i++)
        {
            NavMeshBuildSettings settings = NavMesh.GetSettingsByIndex(index: i);
            if (name == NavMesh.GetSettingsNameFromID(agentTypeID: settings.agentTypeID))
            {
                return settings.agentTypeID;
            }
        }
        return null;
    }
}
