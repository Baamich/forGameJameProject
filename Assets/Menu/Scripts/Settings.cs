using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class Settings : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown screenTypeDropdown;
    public TMP_Dropdown qualityDropdown;
    Resolution[] resolutions;
    public GameObject SettingsObject;
    void Start()
    {
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0; 

        for(int i = 0; i < resolutions.Length; i++) 
        {
            string option = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz";
            options.Add(option);
            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
               
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.RefreshShownValue();
        LoadSettings(currentResolutionIndex);  
    }

   public void SetFullScreen(int screenModeIndex)
{
    switch (screenModeIndex)
    {
        case 0: // Полноэкранный
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
            break;

        case 1: // В окне
            Screen.fullScreenMode = FullScreenMode.Windowed;
            break;

        case 2: // Полноэкранный в окне
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
            break;
    }
}

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];    
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreenMode);
    }


    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void Exit()
    {
        SettingsObject.SetActive(false);
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("QualitySettingPreference", qualityDropdown.value);
        PlayerPrefs.SetInt("ResolutionPrefernce", resolutionDropdown.value);
        PlayerPrefs.SetInt("ScreenModePreference", screenTypeDropdown.value);
    }
    
    public void LoadSettings(int currentResolutionIndex)
    {
        if(PlayerPrefs.HasKey("QualitySettingPreference")){
        qualityDropdown.value = PlayerPrefs.GetInt("QualitySettingPreference");
        }
        else{
            qualityDropdown.value = 2;
        }

        if(PlayerPrefs.HasKey("ResolutionPrefernce")){
            resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionPrefernce");
        }else{
            resolutionDropdown.value = currentResolutionIndex;
        }

        if (PlayerPrefs.HasKey("ScreenModePreference"))
        {
            int mode = PlayerPrefs.GetInt("ScreenModePreference");
            screenTypeDropdown.value = mode;
            SetFullScreen(mode);
        }
        else
        {
            screenTypeDropdown.value = 0;
            SetFullScreen(0);
        }
    }

    public void OnApplyButton()
    {
        SetResolution(resolutionDropdown.value);
        SetFullScreen(screenTypeDropdown.value);
        SetQuality(qualityDropdown.value);
        // Применяем громкость, если есть ChangeMusicVolume в сцене
        ChangeMusicVolume cmv = FindObjectOfType<ChangeMusicVolume>();
        if(cmv != null)
            cmv.OnMusicSlider(AudioListener.volume);

        SaveSettings();
    }
}
