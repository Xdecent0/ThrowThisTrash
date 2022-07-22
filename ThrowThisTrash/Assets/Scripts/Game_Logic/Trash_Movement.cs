using System.Collections;
using UnityEngine;

public class Trash_Movement : MonoBehaviour
{
    [SerializeField] float movementPerSecond;
    [SerializeField] float speed = 0.1f;
    [SerializeField] float dead_Z_Position = -14f;
    [SerializeField] float alive_Z_Position = 14f;
    [SerializeField] float alive_Y_Position = 0.3f;
    [SerializeField] float dead_Left_Position = -0.77f;
    [SerializeField] float dead_Right_Position = 3.47f;
    [SerializeField] Trash_Swiping swiping;
    [SerializeField] Trash_Spawner spawner;

    [SerializeField] public bool isSwipping = false;

    float firstRoad_pos = -3f;
    float secondRoad_pos = 0f;
    float thirdRoad_pos = 3f;
    float fourthRoad_pos = 6f;
   private void Awake()
    {
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Trash_Spawner>();
        swiping = GameObject.FindGameObjectWithTag("Swipe_Detector").GetComponent<Trash_Swiping>();
    }
    private void Start()
    {
        gameObject.transform.position = new Vector3(0, alive_Y_Position, alive_Z_Position);
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
    public void MoveRight()
    {
        if (transform.position.x < dead_Right_Position)
        {
        // transform.position = new Vector3(transform.position.x + 3f, transform.position.y, transform.position.z);
        StartCoroutine(ToRight());
        }
    }
    public void MoveLeft()
    {
        if (transform.position.x > dead_Left_Position)
        {
            // transform.position = new Vector3(transform.position.x - 3f, transform.position.y, transform.position.z);
            StartCoroutine(ToLeft());
        }
    }
    private void FixedUpdate()
    {
        movementPerSecond = spawner.gameSpeed;
        transform.Translate(0, 0, movementPerSecond * speed,Space.World);
    }
    // Delete this after adding trash cans

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == this.gameObject.tag)
        {
            Destroy(gameObject);
            spawner.score++;
        }
        else
        {
            Debug.Log("Dura");
        }
     
    }

    // Coroutines for direction swipe

    IEnumerator ToRight()
    {
        if (isSwipping == false)
        {
            isSwipping = true;
            for (float ft = 3f; ft >= 0; ft -= 0.101f)
            {
                transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
                isSwipping = true;
                yield return null;
            }
        }
        isSwipping = false;
    }

    IEnumerator ToLeft()
    {
        if (isSwipping == false)
        {
            isSwipping = true;
            for (float ft = -3f; ft <= 0; ft += 0.101f)
            {
                transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z);
                isSwipping = true;
                yield return null;
            }
        }
        isSwipping = false;
    }
    private void OnMouseDown()
    {
       swiping.GetTrash(this.gameObject);
    }
}
