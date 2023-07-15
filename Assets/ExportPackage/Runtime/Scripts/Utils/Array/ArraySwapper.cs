using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CodeFramework.Runtime.Controllers.Utils.Array
{
    public class ArraySwapper<T> 
    {
        private T[] dtos;
        private int currentIndex = 0;
        private int LastIndex => dtos.Length - 1;

        public ArraySwapper(T[] dtos, int currentIndex = 0)
        {
            this.dtos = dtos;
            this.currentIndex = currentIndex;
        }
        
        public ArraySwapper(List<T> dtoList, int currentIndex = 0)
        {
            this.dtos = dtoList.ToArray();
            this.currentIndex = currentIndex;
        }
        public T GetNext(bool isLoop = true)
        {
            if (currentIndex >= LastIndex)
            {
                if (isLoop)
                {
                    currentIndex = 0;
                }
            }
            else
            {
                currentIndex++;
            }

            return Current;
        }
        
        public T GetPrevious(bool isLoop = true)
        {
            if (currentIndex <= 0)
            {
                if (isLoop)
                {
                    currentIndex = LastIndex;
                }
            }
            else
            {
                currentIndex--;
            }

            return Current;
        }

        public bool OnCurrentIndex(int index)
        {
            return index == currentIndex;
        }

        public bool OnPreLast()
        {
            return OnCurrentIndex(LastIndex - 1);
        }
        public bool OnLast()
        {
            return OnCurrentIndex(LastIndex);
        }

        public bool OnFirst()
        {
            return OnCurrentIndex(0);
        }
        public T Current
        {
            get
            {
                currentIndex = CurrentIndex;
                return dtos[currentIndex];
            }
        }
        public int CurrentIndex => Mathf.Clamp(currentIndex, 0, LastIndex);


        public void SetCurrentIndex(int index) => currentIndex = index;
        public void SetCurrentIndexByValue(T value)
        {
            if (dtos.IsNullOrEmpty()) return;
            if (dtos.Contains(value))
            {
                for (var i = 0; i < dtos.Length; i++)
                {
                    if (Equals(dtos[i], value))
                    {
                        currentIndex = i;
                        break;
                    }
                }
            }
            
        }

        public void Reset() => currentIndex = 0;

    }
}
