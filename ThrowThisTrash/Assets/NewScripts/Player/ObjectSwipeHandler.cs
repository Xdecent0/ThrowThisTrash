using GG.Infrastructure.Utils.Swipe;
using UnityEngine;

public class ObjectSwipeHandler : MonoBehaviour
{
    private ObjectClickHandler selectedObject;
    [SerializeField] private SwipeListener swipeListener;
    private void Awake()
    {
        Renderer renderer = GetComponent<Renderer>();
    }

    public void SetSelectedObject(ObjectClickHandler obj)
    {
        selectedObject = obj;
    }

    private void OnEnable()
    {
        swipeListener.OnSwipe.AddListener(OnSwipe);
    }
    private void OnSwipe(string swipe)
    {
        if (selectedObject != null)
        {
            switch (swipe)
            {
                case "Left":
                    if (selectedObject != null)
                    {
                        selectedObject.SwipeLeft();
                    }
                    break;
                case "Right":
                    if (selectedObject != null)
                    {
                        selectedObject.SwipeRight();
                    }
                    break;
            }
        }
    }
}
