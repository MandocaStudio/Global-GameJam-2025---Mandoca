using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

using UnityEngine;

public class idleAnimation : StateMachineBehaviour
{

    [SerializeField] gridMovement playerScript;

    [SerializeField] animationEvents playerAnimationEvents;

    [SerializeField] float elapsedTime = 0f;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerScript = animator.GetComponentInParent<gridMovement>();
        playerAnimationEvents = animator.GetComponentInParent<animationEvents>();

        playerAnimationEvents.seRio = false;



        animator.SetFloat("X", 0);
        animator.SetFloat("Z", 0);

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= 5)
        {
            playerAnimationEvents.StartRisitaTimer();

            elapsedTime = 0;
        }

    }


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        elapsedTime = 0;

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
