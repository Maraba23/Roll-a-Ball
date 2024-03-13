using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
