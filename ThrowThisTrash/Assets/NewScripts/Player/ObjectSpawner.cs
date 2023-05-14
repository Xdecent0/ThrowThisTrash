using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectSpawner : MonoBehaviour
{
    [System.Serializable]
    public class ObjectPrefab
    {
        public GameObject prefab;
        public float yPosition;
    }

    [Header("Object Prefabs")]
    [SerializeField] private ObjectPrefab[] objectPrefabs;

    [Header("Pool Settings")]
    [SerializeField, Range(1, 100)] private int poolSize = 10;

    [Header("Spawn Settings")]
    [SerializeField, Range(1f, 5f)] private float spawnInterval = 1f;
    [SerializeField, Range(-20f, 20f)] private float startXPosition = 4f;
    [SerializeField] private float[] zPositions = new float[] { -3f, -2f, -1f, 0f };

    [Header("Parent Object")]
    [SerializeField] private Transform parentObject;

    [Header("Game Speed")]
    [SerializeField, Range(0.1f, 5f)] private float gameSpeed = 1f;
    [SerializeField, Range(1f, 60f)] private float difficultInterval = 20f;
    [SerializeField, Range(0.1f, 5f)] private float difficult = 2f;

    private List<GameObject> objectPool;
    private List<GameObject> shuffledPool;
    private int currentIndex = 0;

    public float GameSpeed
    {
        get { return gameSpeed; }
        set { gameSpeed = value; }
    }

    private IEnumerator Start()
    {
        CreateObjectPool();
        ShuffleObjectPool();

        while (true)
        {
            SpawnObject();
            yield return new WaitForSeconds(spawnInterval);
            IncreaseGameSpeed();
        }
    }

    private void CreateObjectPool()
    {
        objectPool = new List<GameObject>();

        for (int i = 0; i < objectPrefabs.Length; i++)
        {
            ObjectPrefab prefabInfo = objectPrefabs[i];

            for (int j = 0; j < poolSize; j++)
            {
                GameObject obj = Instantiate(prefabInfo.prefab, new Vector3(transform.position.x, prefabInfo.yPosition, 0f), Quaternion.identity);
                obj.SetActive(false);
                obj.transform.SetParent(parentObject);
                objectPool.Add(obj);
            }
        }
    }

    private void ShuffleObjectPool()
    {
        shuffledPool = new List<GameObject>(objectPool);
        int n = shuffledPool.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            GameObject temp = shuffledPool[k];
            shuffledPool[k] = shuffledPool[n];
            shuffledPool[n] = temp;
        }
    }

    private void SpawnObject()
    {
        GameObject obj = shuffledPool[currentIndex % shuffledPool.Count];

        int randomZIndex = Random.Range(0, zPositions.Length);
        float randomZ = zPositions[randomZIndex];
        Vector3 spawnPosition = new Vector3(startXPosition, obj.transform.position.y, randomZ);
        obj.transform.position = spawnPosition;
        obj.SetActive(true);

        currentIndex++;
    }

    private void IncreaseGameSpeed()
    {
        if (Mathf.FloorToInt(Time.time) % difficultInterval == 0)
        {
            gameSpeed += difficult;
        }
    }

    public void ReturnObjectToPool(GameObject obj)
    {
        obj.SetActive(false);
        int randomZIndex = Random.Range(0, zPositions.Length);
        float randomZ = zPositions[randomZIndex];
        obj.transform.position = new Vector3(startXPosition, obj.transform.position.y, randomZ);
    }
}
