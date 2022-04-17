using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Net;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class OptionsSliderChange : MonoBehaviour
{
    [SerializeField] private string connectedOptionName;
    [SerializeField] private OptionsSO optionManager;
    [SerializeField] private AudioMixer audioManager;
    public Slider mainSlider;
    public Slider musiqueSlider;
    public Slider effectSlider;

    [System.Serializable]
    public class OptionsValues
    {
        public float volumeMusique;
        public float volumeSonore;
    }

    public void Start()
    {
        switch (connectedOptionName)
        {
            case "volumeMusique" :
                musiqueSlider.value = optionManager.volumeMusique;
                audioManager.SetFloat("musiqueVolume", Mathf.Log10(musiqueSlider.value) * 20);
                transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().SetText(Mathf.Round(musiqueSlider.value * 100).ToString());
                break;
            case "volumeSonore" :
                effectSlider.value = optionManager.volumeSonore;
                audioManager.SetFloat("effectVolume", Mathf.Log10(effectSlider.value) * 20);
                transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().SetText(Mathf.Round(effectSlider.value * 100).ToString());
                break;
        }
        //Adds a listener to the main slider and invokes a method when the value changes.
        mainSlider.onValueChanged.AddListener (delegate {ValueChangeCheck ();});
    }

    // Invoked when the value of the slider changes.
    public void ValueChangeCheck()
    {
        OptionsValues options = new OptionsValues();

        options.volumeMusique = musiqueSlider.value;
        options.volumeSonore = effectSlider.value;

        switch (connectedOptionName)
        {
            case "volumeMusique" :
                options.volumeMusique = musiqueSlider.value;
                optionManager.volumeMusique = musiqueSlider.value;
                audioManager.SetFloat("musiqueVolume", Mathf.Log10(musiqueSlider.value) * 20);
                transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().SetText(Mathf.Round(musiqueSlider.value * 100).ToString());
                Savemanager.SaveOptions(optionManager);
                Debug.Log(Application.persistentDataPath);
                break;
            case "volumeSonore" :
                options.volumeSonore = effectSlider.value;
                optionManager.volumeSonore = effectSlider.value;
                audioManager.SetFloat("effectVolume", Mathf.Log10(effectSlider.value) * 20);
                transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().SetText(Mathf.Round(effectSlider.value * 100 ).ToString());
                Savemanager.SaveOptions(optionManager);
                break;
        }
    }
}
