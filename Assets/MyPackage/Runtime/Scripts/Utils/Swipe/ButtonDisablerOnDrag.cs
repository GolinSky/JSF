using UnityEngine.UI;

namespace UnityEngine.MyPackage.Runtime.Scripts.Utils.Swipe
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
            swipeComponent.DragHandler.AddListener(HandleDrag);
        }

        private void HandleDrag(bool isDrag)
        {
            button.enabled = !isDrag;
        }
    }
}
