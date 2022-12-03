using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] ParticleSystem cleanDreamParticles;
    [SerializeField] ParticleSystem badDreamParticles;
    public void TurnOnBadEmission()
    {
        if (!badDreamParticles.isPlaying)
        {
            badDreamParticles.Play();
        }
        
        
    }

    public void TurnOnGoodEmission()
    {
        if (!cleanDreamParticles.isPlaying)
        {
            cleanDreamParticles.Play();
        }
    }
}
