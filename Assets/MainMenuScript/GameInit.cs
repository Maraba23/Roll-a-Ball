using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    public AudioSource audioSource;

    void Start()
    {
        audioSource.Play();
    }
    public void StartGame()
    {
        audioSource.Stop();
        SceneManager.LoadScene("Minigame");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
