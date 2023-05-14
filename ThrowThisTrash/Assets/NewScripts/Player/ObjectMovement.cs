using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    private ObjectSpawner objectSpawner;

    private void Awake()
    {
        objectSpawner = GameObject.FindWithTag("Spawner").GetComponent<ObjectSpawner>();
    }

    private void Update()
    {
        MoveObject();
    }

    private void MoveObject()
    {
        transform.Translate(Vector3.left * objectSpawner.GameSpeed * Time.deltaTime);
    }
}
