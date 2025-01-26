using UnityEngine;

public class enemyMovement : MonoBehaviour
{


    [SerializeField] private Transform playerTransform;

    [SerializeField] private float speed;

    [SerializeField] private Vector3 targetPosition;

    void Start()
    {

        playerTransform = GameObject.Find("sapito").GetComponent<Transform>();
    }


    private void OnEnable()
    {
        GameEvents.OnPlayerMove += MoveTowardsPlayer;
    }

    private void OnDisable()
    {
        GameEvents.OnPlayerMove -= MoveTowardsPlayer;
    }

    // Update is called once per frame
    private void MoveTowardsPlayer()
    {

        targetPosition = playerTransform.transform.position;

        int randomRange = Random.Range(0, 3);

        if (randomRange == 1)
        {

        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }


}
