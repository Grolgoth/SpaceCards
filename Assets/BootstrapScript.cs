using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BootstrapScript : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return SceneManager.LoadSceneAsync("Persistent", LoadSceneMode.Additive);

        yield return SceneManager.LoadSceneAsync("Main Menu", LoadSceneMode.Additive);

        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Main Menu"));

        yield return SceneManager.UnloadSceneAsync("Bootstrapper");
    }
}