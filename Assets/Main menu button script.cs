using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject conOrNewGame;

    void Start()
    {
        mainMenu.SetActive(true);
        conOrNewGame.SetActive(false);
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
        PersistentUI.Instance.Show("settings");
    }

    // Called by the Quit button
    public void QuitGame()
    {
        Application.Quit();
    }
}
