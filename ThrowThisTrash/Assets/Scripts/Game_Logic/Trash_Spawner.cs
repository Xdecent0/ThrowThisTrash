using System.Collections;
using UnityEngine;

public class Trash_Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] trash;
    [SerializeField] float spawnDelay = 1f;
    public float gameSpeed = -0.5f;

    private void Start()
    {
        StartCoroutine(SpawnObjects());
    }
    IEnumerator SpawnObjects()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);
            Instantiate(trash[Random.Range(0, trash.Length)]);
           // ??????????
           // gameSpeed -= 0.05f;
        }
    }
}