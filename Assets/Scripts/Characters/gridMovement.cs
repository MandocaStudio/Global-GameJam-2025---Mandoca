using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;


public class gridMovement : MonoBehaviour
{



    [SerializeField] private float speed;

    [SerializeField] private UnityEngine.Vector3 movePoint;

    [SerializeField] private UnityEngine.Vector3 targetPosition;


    [SerializeField] private UnityEngine.Vector3 input;

    [SerializeField] private bool canMove;

    [SerializeField] private UnityEngine.Vector3 cubeRadius;

    void Start()
    {
        //targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        input.z = Input.GetAxisRaw("Vertical");
        input.x = Input.GetAxisRaw("Horizontal");


        if (canMove)
        {
            transform.position = UnityEngine.Vector3.MoveTowards(transform.position, movePoint, speed * Time.deltaTime);

            if (UnityEngine.Vector3.Distance(transform.position, movePoint) == 0)
            {
                canMove = false;

                Debug.Log("");
            }
        }



        if ((input.x == 1 ^ input.y == 1 ^ input.x == -1 ^ input.y == -1) && !canMove)
        {
            canMove = true;
            movePoint += input;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(movePoint + targetPosition, cubeRadius);
    }
}
