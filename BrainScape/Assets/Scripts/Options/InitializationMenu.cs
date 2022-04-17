using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class InitializationMenu : MonoBehaviour
{
    [SerializeField] private OptionsSO optionManager;
    [SerializeField] private AudioMixer audioManager;
    
    public void Awake()
    {
        optionManager = Savemanager.Load(optionManager);
    }

    private void Start()
    {
        audioManager.SetFloat("musiqueVolume", Mathf.Log10(optionManager.volumeMusique) * 20);
        audioManager.SetFloat("effectVolume", Mathf.Log10(optionManager.volumeSonore) * 20);
    }
}
