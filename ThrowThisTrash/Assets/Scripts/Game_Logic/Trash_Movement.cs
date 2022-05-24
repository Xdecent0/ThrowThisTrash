using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash_Movement : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;

    private void FixedUpdate()
    {
        transform.Translate(0, 0, -1 * speed,Space.World);
    }
}
