using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class LoadingManager : MonoBehaviour
{
    public static LoadingManager Instance;

    public Typer typer;
    public TextMeshProUGUI text;
    public GameObject LoadingScreen;
    private float typingSpeed = 0.1f;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        LoadingScreen.SetActive(false);
    }

    public void SwitchScene(string oldScene, string newScene)
    {
        Debug.Log("switchscene called : " + oldScene + " to " + newScene);
        if (oldScene == newScene)
            return;
        else if (oldScene.Length == 0 || newScene.Length == 0)
            return;

        Debug.Log("end reached");

        //Load the new Scene
        StartCoroutine(LoadSceneAsync(newScene, oldScene));
    }

    IEnumerator LoadSceneAsync(string sceneName, string currentScene)
    {
        Debug.Log("s ");
        //Activate the loading screen overlay
        LoadingScreen.SetActive(true);

        AsyncOperation loadOp = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        loadOp.allowSceneActivation = false;

        typer.TypeDynamic(text, "Loading...", () => typingSpeed);

        while (loadOp.progress < 0.9f)
        {
            float progress = loadOp.progress / 0.9f;

            typingSpeed = Mathf.Lerp(
                0.5f,
                0.01f,
                progress
            );

            yield return null;
        }
        typingSpeed = 0.02f;

        while (typer.IsTyping)
        {
            yield return null;
        }

        loadOp.allowSceneActivation = true;
        yield return null; //wait one frame

        // Make the new scene the active scene
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));

        //Unload the old scene
        if (!string.IsNullOrEmpty(currentScene))
        {
            yield return SceneManager.UnloadSceneAsync(currentScene);
        }

        //Remove the loading screen overlay
        LoadingScreen.SetActive(false);
    }
}
