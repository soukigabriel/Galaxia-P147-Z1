using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
//using UnityEngine.UI;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer mainAudioMixer;
    Resolution[] m_resolutions;
    //public Dropdown resolutionDropdown;
    public TMP_Dropdown resolutionDropdown;

    public void SetVolume(float newVolume)
    {
        mainAudioMixer.SetFloat("MasterVolume", newVolume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    void FindResolutions()
    {
        m_resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> resolutionDropdownOptions = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < m_resolutions.Length; i++)
        {
            string option = m_resolutions[i].width + " x " + m_resolutions[i].height;
            resolutionDropdownOptions.Add(option);

            if (m_resolutions[i].width == Screen.currentResolution.width && m_resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(resolutionDropdownOptions);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }    

    public void SetResolution(int resolutionIndex)
    {
        Resolution newResolution = m_resolutions[resolutionIndex];
        Screen.SetResolution(newResolution.width, newResolution.height, Screen.fullScreen);
    }

    // Start is called before the first frame update
    void Start()
    {
        SetQuality(3);
        FindResolutions();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
