using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transiton2 : StateMachineBehaviour
{
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        if(MovePlayer.instance.isAttacking)
        {
            
             MovePlayer.instance.attack3 = true;
            MovePlayer.instance.animator.Play("Attacking3");
            //MovePlayer.instance.attack3 = true; //where to put???????????//NOT WORKING
            //Debug.Log("Attacking3");
            //Enemy.instanceE.TakeDamage(10);
             MovePlayer.instance.DoDMG3();
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        MovePlayer.instance.isAttacking = false; 
        
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
