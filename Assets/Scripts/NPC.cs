using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumCollection;
using DreamCatcher.Audio;

public class NPC : MonoBehaviour
{
    [SerializeField] ParticleSystem cleanDreamParticles;
    [SerializeField] ParticleSystem badDreamParticles;
    [SerializeField] float ConversionTimeSeconds;

    private bool _isCleaned = false;
    private bool _isCleaning = false;
    private float _conversionCounter = 0;

    public bool IsCleaned
    {
        get { return _isCleaned; }
    }

    public bool IsCleaning
    {
        get { return _isCleaning; }
    }


    void Update()
    {
        if(_isCleaning)
        {
            if( _conversionCounter > 0)
            {
                _conversionCounter -= Time.deltaTime;
            } 
            else
            {
                _isCleaned = true;
                badDreamParticles.Stop();
                TurnOnGoodEmission();
            }
        }
        AudioManager.Instance.PlaySoundEffect(SFX.Schnarchen1);
    }

    public void startConversion()
    {
        if(!_isCleaning && !_isCleaned)
        {
            _isCleaning = true;
            TurnOnBadEmission();
        }
    }

    public void stopConversion()
    {
        if(!_isCleaned)
        {
            _isCleaning = false;
            _conversionCounter = ConversionTimeSeconds;
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
        _conversionCounter = ConversionTimeSeconds;
    }
}
