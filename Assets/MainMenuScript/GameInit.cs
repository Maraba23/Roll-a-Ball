using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        // Carrega a cena do jogo, substitua "GameScene" pelo nome da sua cena de jogo
        SceneManager.LoadScene("Minigame");
    }

    public void QuitGame()
    {
        // Sai do jogo. Note que isso só funciona em um build, não no editor do Unity.
        Application.Quit();
    }
}
