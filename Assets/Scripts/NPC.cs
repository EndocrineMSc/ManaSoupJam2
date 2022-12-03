using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] ParticleSystem cleanDreamParticles;
    [SerializeField] ParticleSystem badDreamParticles;

    protected const float ConversionTime = 5; // seconds

    private bool _isCleaned = false;
    private bool _isCleaning = false;
    private float _conversionCounter = 0;

    void Update()
    {
        if(_conversionCounter > 0)
        {
            _conversionCounter -= Time.deltaTime;
        } 
        else if (!_isCleaned)
        {
            _isCleaned = true;
            badDreamParticles.Stop();
            TurnOnGoodEmission();
            Debug.Log("NPC Converted");
        }
    }

    public void startConversion()
    {
        if(!_isCleaning && !_isCleaned)
        {
            TurnOnBadEmission();
        }
    }

    public void stopConversion()
    {
        if(!_isCleaned)
        {
            _isCleaning = false;
            _conversionCounter = ConversionTime;
            badDreamParticles.Stop();
        }
        
    }

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

    public void Awake()
    {
        _conversionCounter = ConversionTime;
    }
}
