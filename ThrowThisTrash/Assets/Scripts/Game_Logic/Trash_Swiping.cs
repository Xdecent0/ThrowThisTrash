using UnityEngine;
using GG.Infrastructure.Utils.Swipe;
public class Trash_Swiping : MonoBehaviour
{
    [SerializeField] SwipeListener swipeListener;
    [SerializeField] Trash_Movement trash_Movement;

    private void OnEnable()
    {
        swipeListener.OnSwipe.AddListener(OnSwipe);
    }
    private void OnSwipe(string swipe)
    {
        switch (swipe)
        {
            case "Left":
                trash_Movement.MoveLeft();
                break;
            case "Right":
                trash_Movement.MoveRight();
                break;
        }
    }
    private void OnDisable()
    {
        swipeListener.OnSwipe.RemoveListener(OnSwipe);
    }

    public void GetTrash(GameObject trash)
    {
        trash_Movement = trash.GetComponent<Trash_Movement>();
    }
}

