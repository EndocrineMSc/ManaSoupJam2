using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] ParticleSystem cleanDreamParticles;
    [SerializeField] float playerRange = 5f;
    Transform target;

   



    void Update()
    {
        FindClosestTarget();
        ToggleEmission();
    }

    void FindClosestTarget()
    {
        NPC[] npcs = FindObjectsOfType<NPC>();
        Player player = FindObjectOfType<Player>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach(NPC npc in npcs)
        {
            float targetDistance = Vector2.Distance(player.transform.position, npc.transform.position);

            if (targetDistance < maxDistance)
            {
                closestTarget = npc.transform;
                maxDistance = targetDistance;
            }
        }
        target = closestTarget;
     }

    void ToggleEmission()
    {
        Player player = FindObjectOfType<Player>();
        float targetDistance = Vector2.Distance(player.transform.position, target.position);
        if (targetDistance < playerRange)
        {
            Activate(true);
        }
        else
        {
            Activate(false);
        }
    }

    void Activate(bool isActive)
    {
        
        if (isActive && !cleanDreamParticles.isPlaying)
        {
            Debug.Log("Now it should start.");
            cleanDreamParticles.Play();
        }
        else if (!isActive)
        {
            cleanDreamParticles.Stop();
        }
           
    }

}
