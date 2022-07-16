using System.Collections;
using UnityEngine;

public class Trash_Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] trash;
    [SerializeField] float spawnDelay = 1f;

    private void Start()
    {
        StartCoroutine(TestCoroutine());
    }
    IEnumerator TestCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);
            Instantiate(trash[Random.Range(0, trash.Length)]);
        }
    }
}