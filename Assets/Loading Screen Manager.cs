using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class LoadingManager : MonoBehaviour
{
    public static string TargetScene;

    public Typer typer;
    public TextMeshProUGUI text;
    private float typingSpeed = 0.1f;

    void Start()
    {
        if (!string.IsNullOrEmpty(TargetScene))
        {
            StartCoroutine(LoadSceneAsync(TargetScene));
            TargetScene = null;
        }
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation loadOp = SceneManager.LoadSceneAsync(sceneName);

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
    }
}
