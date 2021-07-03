using System.Linq;
using UnityEngine;

namespace FrameworkCore.Utils.Animator.View
{
    public class AnimatorStateView : StateMachineBehaviour
    {
        public  override  void OnStateEnter(UnityEngine.Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            var onStateEnterList = animator.gameObject.GetComponents<IAnimatorOnStateEnter>().ToList();
            onStateEnterList.ForEach(x=>x.OnStateEnter());
        }

        public override void OnStateExit(UnityEngine.Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            var onStateExitList = animator.gameObject.GetComponents<IAnimatorOnStateExit>().ToList();
            onStateExitList.ForEach(x=>x.OnStateExit());
        }
    }
}
