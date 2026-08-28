using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject conOrNewGame;
    public GameObject settings;
    //public GameObject settings;

    void Start()
    {
        // Set initial visibility
        Debug.Log("Starting main menu controller");
        mainMenu.SetActive(true);
        //settings.SetActive(false);
        conOrNewGame.SetActive(false);
        settings.SetActive(false);
    }

    // Called by the Play button
    public void PlayGame()
    {
        if (FileManager.Exists("/savegame"))
        {
            mainMenu.SetActive(false);
            conOrNewGame.SetActive(true);
        }
        else
            GameLoader.NewGame();
    }

    public void NewGame()
    {
        GameLoader.NewGame();
    }

    public void LoadGame()
    {
        GameLoader.LoadGame();
    }

    // Called by the Settings button
    public void OpenSettings()
    {
        mainMenu.SetActive(false);
        settings.SetActive(true);
    }

    public void Back()
    {
        settings.SetActive(false);
        conOrNewGame.SetActive(false);
        mainMenu.SetActive(true);
    }

    // Called by the Quit button
    public void QuitGame()
    {
        Application.Quit();
    }
}
