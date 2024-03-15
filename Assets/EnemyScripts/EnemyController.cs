using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{
    public GameObject playerToFollow;
    public float speed;
    public static bool isDead = false;
    public AudioSource[] audioSources;

    // Variáveis para controlar a reprodução dos sons
    public float soundMinDelay = 20.0f;
    public float soundMaxDelay = 40.0f;

    void Start()
    {
        playerToFollow = GameObject.Find("Player");
        audioSources = GetComponents<AudioSource>();
        StartCoroutine(PlayRandomSounds());
    }

    void FollowPlayer()
    {
        if (!isDead)
        {
            transform.LookAt(playerToFollow.transform);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    void Update()
    {
        FollowPlayer();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == playerToFollow)
        {
            isDead = true;
            foreach (var source in audioSources)
            {
                source.Stop(); // Parar todos os sons quando o inimigo morrer
            }
            StartCoroutine(WaitAndLoadMenu());
        }
    }

    IEnumerator WaitAndLoadMenu()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator PlayRandomSounds()
    {
        // Este loop roda enquanto o inimigo não está morto
        while (!isDead)
        {
            float waitTime = 80.0f; //Random.Range(soundMinDelay, soundMaxDelay);
            yield return new WaitForSeconds(waitTime);
            
            // Escolhe um som aleatório para tocar se houver sons disponíveis
            if (audioSources.Length > 0)
            {
                int index = Random.Range(0, audioSources.Length);
                if (!audioSources[index].isPlaying)
                {
                    audioSources[index].Play();
                }
            }
        }
    }
}
