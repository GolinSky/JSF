using System;
using UnityEngine;

namespace Runtime.Scripts.Utils.Animator.View
{
    [Obsolete]
    public class EndStateVIew : StateMachineBehaviour
    {
        public  override  void OnStateEnter(UnityEngine.Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            var animatorEndEvent = animator.gameObject.GetComponentInParent<IAnimatorOnStateEnter>();
            animatorEndEvent?.OnStateEnter();
        }


        public override void OnStateExit(UnityEngine.Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            var animatorEndEvent = animator.gameObject.GetComponentInParent<IAnimatorOnStateExit>();
            animatorEndEvent?.OnStateExit();
        }
  
    }

    public interface IAnimatorOnStateExit
    {
        void OnStateExit();
    }
    
    public interface IAnimatorOnStateEnter
    {
        void OnStateEnter();
    }
}
