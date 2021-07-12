using System;
using UnityEngine.EventSystems;

namespace UnityEngine.Package.Runtime.Scripts.Utils.Ui
{
    public class DragButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerExitHandler
    { 
        private Action actionUp;
        private Action actionDown;
    
        public void OnPointerUp(PointerEventData eventData)
        {
            actionUp.Invoke();
        }
        public void OnPointerExit(PointerEventData eventData)
        {
            actionUp.Invoke();
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            actionDown.Invoke();
        }
        public void AddListener(Action actionUp, Action actionDown)
        {
            this.actionUp = actionUp;
            this.actionDown = actionDown;
        }

        public void RemoveListener()
        {
            actionDown = null;
            actionUp = null;
        }
    }
}
