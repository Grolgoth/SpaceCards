using System;
using UnityEngine;
using UnityEngine.UI;

public class PersistentUI : MonoBehaviour
{
    public static PersistentUI Instance;
    public GameObject settingsMenu;
    public GameObject Overlay;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        settingsMenu.SetActive(false);
        Overlay.SetActive(false);
    }

    public void Show(string menu)
    {
        //pausemanager.Pause();
        Overlay.SetActive(true);
        if (string.Equals(menu, "settings", StringComparison.OrdinalIgnoreCase))
            settingsMenu.SetActive(true);
        else
        {
            //pausemanager.UnPause();
            Overlay.SetActive(false);
        }
    }

    public void Close(string menu)
    {
        if (string.Equals(menu, "settings", StringComparison.OrdinalIgnoreCase))
            settingsMenu.SetActive(false);
        //pausemanager.UnPause();
        Overlay?.SetActive(false);
    }
}
