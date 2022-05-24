using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash_Movement : MonoBehaviour
{
    [SerializeField] float movementPerSecond = -1;
    [SerializeField] float speed = 0.1f;
    [SerializeField] float deadZetPosition = -14f;

    float firstRoad_pos = -3f;
    float secondRoad_pos = 0f;
    float thirdRoad_pos = 3f;
    float fourthRoad_pos = 6f;
    private void Start()
    {
        int randomroad = Random.Range(1,5);
        switch (randomroad)
        {
            case 1:
                transform.position = new Vector3(-3f, transform.position.y, transform.position.z);
                break;
            case 2:
                transform.position = new Vector3(0f, transform.position.y, transform.position.z);
                break;
            case 3:
                transform.position = new Vector3(3f, transform.position.y, transform.position.z);
                break;
            case 4:
                transform.position = new Vector3(6f, transform.position.y, transform.position.z);
                break;
        }
    }
    private void FixedUpdate()
    {
        transform.Translate(0, 0, movementPerSecond * speed,Space.World);
    }
    // Delete this after adding trash cans
    private void Update()
    {
        if (gameObject.transform.position.z < deadZetPosition)
        {
            Destroy(gameObject);
        }
    }

}
