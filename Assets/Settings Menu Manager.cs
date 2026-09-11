using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Collections.Generic;
using System.Globalization;

public class SettingsMenu : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;
    public Toggle vSyncToggle;
    public Slider audioSlider;
    public Slider musicSlider;
    public Toggle fastAnimationSpeed;
    public Resolution[] resolutions;

    string path;

    void Awake()
    {
        path = Application.persistentDataPath + "/settings.ini";

        resolutions = Screen.resolutions;
        if (resolutions.Length == 0)
        {
            resolutions = new Resolution[] { new Resolution { width = Screen.width, height = Screen.height } };
        }

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentIndex;
        resolutionDropdown.RefreshShownValue();
        fullscreenToggle.SetIsOnWithoutNotify(Screen.fullScreen);
        vSyncToggle.isOn = false;
        fastAnimationSpeed.isOn = false;

        LoadSettings();
    }

    void LoadSettings()
    {
        if (System.IO.File.Exists(path))
        {
            string[] lines = System.IO.File.ReadAllLines(path);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line) || !line.Contains("=")) continue;

                string[] parts = line.Split('=');
                string key = parts[0];
                string value = parts[1];

                switch (key)
                {
                    case "fullscreen":
                        fullscreenToggle.isOn = value == "true";
                        Screen.fullScreen = fullscreenToggle.isOn;
                        break;

                    case "vsync":
                        vSyncToggle.isOn = value == "true";
                        QualitySettings.vSyncCount = vSyncToggle.isOn ? 1 : 0;
                        break;

                    case "audio":
                        audioSlider.value = float.Parse(value);
                        break;

                    case "music":
                        musicSlider.value = float.Parse(value);
                        break;

                    case "animspeed":
                        fastAnimationSpeed.isOn = value == "true";
                        break;

                    case "resolution":
                        for (int i = 0; i < resolutions.Length; i++)
                        {
                            string res = resolutions[i].width + "x" + resolutions[i].height;
                            if (res == value)
                            {
                                resolutionDropdown.value = i;
                                SetResolution(i);
                                break;
                            }
                        }
                        break;
                }
            }
        }
        else
        {
            string[] defaults = { "fullscreen=true", "vsync=false", "audio=1", "music=1", "animspeed=false", "resolution=1920x1080" };
            System.IO.File.WriteAllLines(path, defaults);
        }
        SetRuntimeSettings();
    }

    public void SaveSettings()
    {
        string[] lines = new string[6];
        lines[0] = fullscreenToggle.isOn ? "fullscreen=true" : "fullscreen=false";
        lines[1] = vSyncToggle.isOn ? "vsync=true" : "vsync=false";
        lines[2] = "audio=" + audioSlider.value.ToString(CultureInfo.InvariantCulture);
        lines[3] = "music=" + musicSlider.value.ToString(CultureInfo.InvariantCulture);
        lines[4] = fastAnimationSpeed.isOn ? "animspeed=true" : "animspeed=false";
        lines[5] = "resolution=" + Screen.width + "x" + Screen.height;

        SetRuntimeSettings();
        File.WriteAllLines(path, lines);
    }

    public void SetResolution(int index)
    {
        Resolution r = resolutions[index];
        Debug.Log("setting screen to: " + r.width + "x" + r.height);
        Screen.SetResolution(r.width, r.height, Screen.fullScreen);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Debug.Log("setting screen to: " + !Screen.fullScreen);
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void SetVSync(bool enabled)
    {
        QualitySettings.vSyncCount = enabled ? 1 : 0;
    }

    public void SetAudioVolume(float value)
    {
        SettingsData.AudioVolume = value;
    }

    public void SetMusicVolume(float value)
    {
        SettingsData.MusicVolume = value;
    }

    public void SetAnimationSpeed(bool fast)
    {
        SettingsData.AnimationSpeed = fast;
    }

    public void Close()
    {
        SaveSettings();
        PersistentUI.Instance.Close("settings");
    }

    void SetRuntimeSettings()
    {
        SetVSync(vSyncToggle.isOn);
        SetAudioVolume(audioSlider.value);
        SetMusicVolume(musicSlider.value);
        SetAnimationSpeed(fastAnimationSpeed.isOn);
    }
}