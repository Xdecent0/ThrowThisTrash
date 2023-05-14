using UnityEngine;

public class TrashSorting : MonoBehaviour
{
   [SerializeField] private ObjectSpawner objectSpawner;
   [SerializeField] private PauseManager pauseManager;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
        if (collision.gameObject.tag == gameObject.tag)
        {
            objectSpawner.ReturnObjectToPool(collision.gameObject);
        }
        else
        {
            pauseManager.Death();
            Destroy(collision.gameObject);
        }
    }
}
