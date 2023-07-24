using UnityEngine;
using UnityEngine.UI;

namespace CodeFramework.Runtime.Controllers.Utils.Swipe
{
    public class ButtonDisablerOnDrag : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private SwipeComponent swipeComponent;

        private void OnValidate()
        {
            button = GetComponent<Button>();
            swipeComponent = GetComponent<SwipeComponent>();
        }

        private void Start()
        {
            swipeComponent.DragHandler += HandleDrag;
        }

        private void OnDestroy()
        {
            swipeComponent.DragHandler -= HandleDrag;
        }

        private void HandleDrag(bool isDrag)
        {
            button.enabled = !isDrag;
        }
    }
}
