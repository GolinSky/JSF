﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine.U2D;

namespace UnityEngine.Package.Runtime.Scripts.Utils.Ui
{
    public static class SpriteUtils
    {
        public static List<Sprite> UnpackSpriteAtlass(this SpriteAtlas spriteAtlas)
        {
            var sprites = new Sprite[spriteAtlas.spriteCount];
            spriteAtlas.GetSprites(sprites);
            var dict = new Dictionary<string, Sprite>();

            var spritesList = sprites.ToList();
            
            foreach (var sprite in spritesList)
            {
                dict.Add(sprite.name, sprite);
            }

            spritesList = dict.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value).Values.ToList();
            return spritesList;
        }
    }
}
