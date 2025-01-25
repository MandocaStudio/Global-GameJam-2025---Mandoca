using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Unity.Mathematics;
using UnityEngine;


public class gridMovement : MonoBehaviour
{



    [SerializeField] private float speed;

    [SerializeField] private Vector3 movePoint;

    [SerializeField] private Vector3 targetPosition;


    [SerializeField] private Vector3 input;

    [SerializeField] private bool canMove;

    [SerializeField] private Vector3 cubeRadius;


    [SerializeField] private Transform playerTransform;

    void Start()
    {
        movePoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        input.z = Input.GetAxisRaw("Vertical");
        input.x = Input.GetAxisRaw("Horizontal");


        if (canMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, movePoint, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, movePoint) == 0)
            {
                canMove = false;

            }
        }



        if ((input.x == 1 ^ input.z == 1 ^ input.x == -1 ^ input.z == -1) && !canMove)
        {


            rotatePlayer();
            canMove = true;
            movePoint += input;
        }

    }

    private void rotatePlayer()
    {
        if (input.x == 1)
        {
            playerTransform.transform.rotation = Quaternion.Euler(0, 90, 0);
            return;
        }
        else if (input.x == -1)
        {
            playerTransform.transform.rotation = Quaternion.Euler(0, 270, 0);
            return;

        }

        else if (input.z == -1)
        {
            playerTransform.transform.rotation = Quaternion.Euler(0, 180, 0);
            return;

        }
        else if (input.z == 1)
        {
            playerTransform.transform.rotation = Quaternion.Euler(0, 360, 0);
            return;

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(movePoint + targetPosition, cubeRadius);
    }


}
