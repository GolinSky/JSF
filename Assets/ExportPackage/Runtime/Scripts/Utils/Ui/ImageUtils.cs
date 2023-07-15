using UnityEngine;
using UnityEngine.UI;

namespace CodeFramework.Runtime.Controllers.Utils.Ui
{
    public static class ImageUtils 
    {
        public static void SetSprite(this Image image, Sprite sprite, bool useSpriteMesh = true)
        {
            if(sprite == null) return;
            if(image == null) return;
            image.sprite = sprite;
            image.useSpriteMesh = useSpriteMesh;
        }
        
        
    }
}
