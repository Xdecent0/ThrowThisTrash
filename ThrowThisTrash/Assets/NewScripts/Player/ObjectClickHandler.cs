using UnityEngine;

public class ObjectClickHandler : MonoBehaviour
{
    [Header("Materials")]
    [SerializeField] private Material newMaterial;
    [SerializeField] private Material originalMaterial;
    [SerializeField] private Renderer renderer;

    [Header("Swipe Handler")]
    [SerializeField] private ObjectSwipeHandler swipeHandler;

    [Header("Selection")]
    [SerializeField] private ObjectSpawner objectSpawner;
    [SerializeField] private static ObjectClickHandler selectedObject;
    [SerializeField] private bool isBomb = false;

    [Header("Swipe Parameters")]
    [SerializeField][Range(-10f, 10f)] private float deadLeftPosition = -0.9f;
    [SerializeField][Range(-10f, 10f)] private float deadRightPosition = -2.9f;
    [SerializeField][Range(0.1f, 5f)] private float moveStep = 1f;

    private void Awake()
    {
        objectSpawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<ObjectSpawner>();
        renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            originalMaterial = renderer.material;
        }

        GameObject swipeDetector = GameObject.FindGameObjectWithTag("SwipeDetector");
        if (swipeDetector != null)
        {
            swipeHandler = swipeDetector.GetComponent<ObjectSwipeHandler>();
        }
    }

    private void Update()
    {
        if (transform.position.z > deadLeftPosition || transform.position.z < deadRightPosition)
        {
            if (isBomb)
            {
                objectSpawner.ReturnObjectToPool(gameObject);
            }
        }
    }

    private void OnMouseDown()
    {
        if (selectedObject != null && selectedObject != this)
        {
            selectedObject.RestoreMaterial();
        }

        SetNewMaterial();
        selectedObject = this;
        swipeHandler.SetSelectedObject(this);
    }

    private void SetNewMaterial()
    {
        if (renderer != null)
        {
            renderer.material = newMaterial;
        }
    }

    public void RestoreMaterial()
    {
        if (renderer != null)
        {
            renderer.material = originalMaterial;
        }
    }

    public void SwipeLeft()
    {
        if (transform.position.z < deadLeftPosition)
        {
            transform.position += new Vector3(0f, 0f, moveStep);
        }
    }

    public void SwipeRight()
    {
        if (transform.position.z > deadRightPosition)
        {
            transform.position += new Vector3(0f, 0f, -moveStep);
        }
    }
}
