using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonEnd : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("beindul");
        GameObject[] obj = GameObject.FindGameObjectsWithTag("selector");
        if (obj != null)
        {
            Debug.Log(obj.Length);
            ObjectSelector selector = obj[0].GetComponent<ObjectSelector>();
            if (selector != null)
            {
                Debug.Log(selector.level);
                animator.SetInteger("level", selector.level);
                selector.level++;
            }
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
