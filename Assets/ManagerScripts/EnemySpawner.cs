using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] spawners;

    public GameObject EnemySpawnable;

    public int toSpawn;

    void GetChilds()
    {
        spawners = GameObject.FindGameObjectsWithTag("EnemySpawner");
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
        if (toSpawn > spawners.Length)
        {
            toSpawn = spawners.Length;
        }

        for (int i = 0; i < toSpawn; i++)
        {
            int randomIndex = Random.Range(0, spawners.Length);
            GameObject spawner = spawners[randomIndex];
            Instantiate(EnemySpawnable, spawner.transform.position, spawner.transform.rotation);
            RemoveSpawner(randomIndex);
        }
    }
}
