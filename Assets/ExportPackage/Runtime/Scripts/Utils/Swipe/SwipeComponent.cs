using System;
using EventHandlerUtils;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UnityEngine.MyPackage.Runtime.Scripts.Utils.Swipe
{
    /// <summary>
    /// Behave like usual unity component 
    /// </summary>
    [RequireComponent(typeof(Image))] // must have some graphic to handle drag event
    [Serializable]
    public class SwipeComponent :MonoBehaviour,  IDragHandler , IEndDragHandler ,  IBeginDragHandler, IPointerExitHandler
    {
        [SerializeField] public bool allowDrag = true; 
        private bool exitPoint = true;
        private Vector2 dragStart;
        public Handler<Direction> SwapHandler { get; } = new Handler<Direction>();
        public Handler<bool> DragHandler { get; } = new Handler<bool>();
        //
        /// <summary>
        /// Here you detect direction of swap
        /// </summary>
        /// <param name="eventData"></param>
        public void OnEndDrag(PointerEventData eventData)
        {
            if (!exitPoint)////
            {
                exitPoint = true;
                if (!allowDrag) return;
                DragHandler?.Invoke(false);
                if (dragStart.y > eventData.position.y)
                {
                    SwapHandler?.Invoke(Direction.Down);
                }
                else if (dragStart.y < eventData.position.y)
                {
                    SwapHandler?.Invoke(Direction.Up);
                }

                if (dragStart.x > eventData.position.x)
                {
                    SwapHandler?.Invoke(Direction.Right);
                }
                else if (dragStart.x < eventData.position.x)
                {
                    SwapHandler?.Invoke(Direction.Left);
                }
            }
        }

        /// <summary>
        /// Don't touch
        /// </summary>
        /// <param name="eventData"></param>
        public void OnBeginDrag(PointerEventData eventData)
        {
            exitPoint = false;
            if (!allowDrag) return;
            DragHandler?.Invoke(true);
            dragStart = eventData.position;
        }

        public void OnDrag(PointerEventData eventData) {}

        public void RemoveAllListeners()
        {
            SwapHandler.Reset();
        }

        public void OnPointerExit(PointerEventData data)
        {
            if (!exitPoint)
            {
                exitPoint = true;
                if (!allowDrag) return;
                DragHandler?.Invoke(false);
                if (dragStart.y > data.position.y)
                {
                    SwapHandler?.Invoke(Direction.Down);
                }
                else if (dragStart.y < data.position.y)
                {
                    SwapHandler?.Invoke(Direction.Up);
                }

                if (dragStart.x > data.position.x)
                {
                    SwapHandler?.Invoke(Direction.Right);
                }
                else if (dragStart.x < data.position.x)
                {
                    SwapHandler?.Invoke(Direction.Left);
                }
            }
        }

    }

    public enum Direction
    {
        Up = 0,
        Down = 1,
        Right = 2,
        Left = 3,
    }
}
