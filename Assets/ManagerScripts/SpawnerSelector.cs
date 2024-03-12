using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class SpawnerSelector : MonoBehaviour
{
    public GameObject[] spawners;

    public GameObject itemSpawnable;

    public int qtdSpawners;
    public static int count;

    void GetChilds()
    {
        spawners = GameObject.FindGameObjectsWithTag("ItemSpawner");
    }

    void RemoveSpawner(int index)
    {
        GameObject[] temp = new GameObject[spawners.Length - 1];
        int j = 0;
        for (int i = 0; i < spawners.Length; i++)
        {
            if (i != index)
            {
                temp[j] = spawners[i];
                j++;
            }
        }
        spawners = temp;
    }

    void Start()
    {
        GetChilds();
        if (qtdSpawners > spawners.Length)
        {
            qtdSpawners = spawners.Length;
        }

        count = qtdSpawners;

        for (int i = 0; i < qtdSpawners; i++)
        {
            int randomIndex = Random.Range(0, spawners.Length);
            GameObject spawner = spawners[randomIndex];
            Instantiate(itemSpawnable, spawner.transform.position, spawner.transform.rotation);
            RemoveSpawner(randomIndex);
        }
    }
}
