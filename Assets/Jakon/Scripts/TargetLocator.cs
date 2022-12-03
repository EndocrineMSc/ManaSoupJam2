using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] ParticleSystem cleanDreamParticles;
    [SerializeField] float playerRange = 1f;
    // Transform target;
    // private NPC _npc;

    void Update()
    {
        NPC closestNPC = FindClosestTarget();
        ToggleEmission(closestNPC);
    }

    private NPC FindClosestTarget()
    {
        NPC[] npcs = FindObjectsOfType<NPC>();
        Player player = FindObjectOfType<Player>();
        // Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        NPC closestNPC = null;

        foreach(NPC npc in npcs)
        {
            float targetDistance = Vector2.Distance(player.transform.position, npc.transform.position);

            if (targetDistance < maxDistance)
            {
                // closestTarget = npc.transform;
                maxDistance = targetDistance;
                // _npc = npc;
                closestNPC = npc;
            }
        }
        // target = closestTarget;

        return closestNPC;
     }

    void ToggleEmission(NPC npcToToggle)
    {
        Player player = FindObjectOfType<Player>();
        float targetDistance = Vector2.Distance(player.transform.position, npcToToggle.transform.position);
        if (targetDistance < playerRange)
        {
            Activate(npcToToggle, true);
        }
        else
        {
            Activate(npcToToggle, false);
        }
    }

    void Activate(NPC npcToActivate, bool isActive)
    {
        
        if (isActive && !cleanDreamParticles.isPlaying)
        {
            Debug.Log("Now it should start.");
            cleanDreamParticles.Play();
            npcToActivate.TurnOnBadEmission();
        }
        else if (!isActive)
        {
            cleanDreamParticles.Stop();
        }
           
    }

}
