using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections.Generic;

public class SettingsManager : MonoBehaviour
{
    public Dropdown ResolutionDropdown;
    public Slider VolumeSlider;
    public Slider SensitivitySlider;
    public AudioMixer audioMixer;
    public GameObject SettingsPanel;

    private Resolution[] resolutions;
    private List<Resolution> filteredResolutions = new List<Resolution>();

    void Start()
    {
        SetupResolutions();
        VolumeSlider.onValueChanged.AddListener(SetVolume);
        SensitivitySlider.onValueChanged.AddListener(SetSensitivity);
        VolumeSlider.minValue = 0.0001f;
        VolumeSlider.maxValue = 1f;
        VolumeSlider.value = 1f;

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SettingsPanel.SetActive(true);
        }
    }

    void SetupResolutions()
    {
        resolutions = Screen.resolutions;
        ResolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            if (!options.Contains(option))
            {
                options.Add(option);
                filteredResolutions.Add(resolutions[i]);
            }

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentIndex = options.Count - 1;
            }
        }

        ResolutionDropdown.AddOptions(options);
        ResolutionDropdown.value = currentIndex;
        ResolutionDropdown.RefreshShownValue();
        ResolutionDropdown.onValueChanged.AddListener(SetResolution);
    }

    public void SetVolume(float volume)
    {
        float dB = Mathf.Log10(volume) * 20;
        audioMixer.SetFloat("MasterVolume", dB);
    }


    public void SetSensitivity(float sens)
    {
        PlayerPrefs.SetFloat("MouseSensitivity", sens);
        // Sens deðerini karakter kontrolüne uygulaman gerekir
    }

    public void SetResolution(int index)
    {
        Resolution res = filteredResolutions[index];
        Screen.SetResolution(res.width, res.height, FullScreenMode.FullScreenWindow);
    }

     public void CloseSettingsPanel()
    {
        SettingsPanel.SetActive(false);
    }

}
