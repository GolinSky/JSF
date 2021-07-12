using UnityEngine;
using UnityEngine.UI;

namespace FrameworkCore.Utils.Ui
{
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(Image))]
    public class ButtonMask : MonoBehaviour, ICanvasRaycastFilter
    {
        private Image imageButton;
        private Sprite spriteButton;
        private Vector2 localPositionPivotRelative;
        private Rect rect;

        void Start()
        {
            imageButton = GetComponent<Image>();
        }

        public bool IsRaycastLocationValid(Vector2 placeImage, Camera eventCamera)
        {
            if (imageButton == null) return false;

            if (imageButton.GetComponent<ButtonMask>() == null)
            {
                Debug.Log($"On {name} object not found ButtonMask component");
                return false;
            }
            spriteButton = imageButton.sprite;
            var transformRect = transform;
            var rectTransform = (RectTransform) transformRect;

            RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform) transformRect, placeImage,
                eventCamera,
                out localPositionPivotRelative);
            var localPosition = new Vector2(localPositionPivotRelative.x + rectTransform.pivot.x *
                                            rectTransform.rect.width,
                localPositionPivotRelative.y + rectTransform.pivot.y * (rect = rectTransform.rect).height);

            var spriteRect = spriteButton.textureRect;
            var maskRect = rect;
            var xCoordinates = 0;
            var yCoordinates = 0;
            switch (imageButton.type)
            {
                case Image.Type.Sliced:
                {
                    var border = spriteButton.border;
                    if (localPosition.x < border.x)
                    {
                        xCoordinates = Mathf.FloorToInt(spriteRect.x + localPosition.x);
                    }
                    else if (localPosition.x > maskRect.width - border.z)
                    {
                        xCoordinates =
                            Mathf.FloorToInt(spriteRect.x + spriteRect.width - (maskRect.width - localPosition.x));
                    }
                    else
                    {
                        xCoordinates = Mathf.FloorToInt(spriteRect.x + border.x +
                                                        ((localPosition.x - border.x) /
                                                         (maskRect.width - border.x - border.z)) *
                                                        (spriteRect.width - border.x - border.z));
                    }

                    if (localPosition.y < border.y)
                    {
                        yCoordinates = Mathf.FloorToInt(spriteRect.y + localPosition.y);
                    }
                    else if (localPosition.y > maskRect.height - border.w)
                    {
                        yCoordinates =
                            Mathf.FloorToInt(spriteRect.y + spriteRect.height - (maskRect.height - localPosition.y));
                    }
                    else
                    {
                        yCoordinates = Mathf.FloorToInt(spriteRect.y + border.y +
                                                        ((localPosition.y - border.y) /
                                                         (maskRect.height - border.y - border.w)) *
                                                        (spriteRect.height - border.y - border.w));
                    }
                }
                    break;
                default:
                {
                    xCoordinates = Mathf.FloorToInt(spriteRect.x + spriteRect.width * localPosition.x / maskRect.width);
                    yCoordinates =
                        Mathf.FloorToInt(spriteRect.y + spriteRect.height * localPosition.y / maskRect.height);
                }
                    break;
            }

            try
            {
                if (spriteButton.texture.isReadable)
                {
                    return spriteButton.texture.GetPixel(xCoordinates, yCoordinates).a > 0;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                    Debug.LogError(
                    "Mask texture not readable, set your sprite to Texture Type 'Advanced' and check 'Read/Write Enabled'");
                Destroy(this);
                return false;
            }
        }
    }
}