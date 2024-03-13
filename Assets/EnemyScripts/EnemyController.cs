using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public GameObject playerToFollow;
    public float speed;
    public static bool isDead = false;

    void Start()
    {
        playerToFollow = GameObject.Find("Player");
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
            StartCoroutine(WaitAndLoadMenu());
        }
    }

    IEnumerator WaitAndLoadMenu()
    {
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene("MainMenu");
    }
}
