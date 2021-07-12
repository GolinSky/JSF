using System.Collections.Generic;

namespace UnityEngine.Package.Runtime.Scripts.Utils.Array
{
    public class DtoSwapper<T> 
    {
        private T[] dtos;
        private int currentIndex = 0;
        private int LastIndex => dtos.Length - 1;

        public DtoSwapper(T[] dtos, int currentIndex = 0)
        {
            this.dtos = dtos;
            this.currentIndex = currentIndex;
        }
        
        public DtoSwapper(List<T> dtoList, int currentIndex = 0)
        {
            this.dtos = dtoList.ToArray();
            this.currentIndex = currentIndex;
        }
        public T GetNext()
        {
            if (currentIndex >= LastIndex)
            {
                currentIndex = 0;
            }
            else
            {
                currentIndex++;
            }

            return Current;
        }
        
        public T GetPrevious()
        {
            if (currentIndex <= 0)
            {
                currentIndex = LastIndex;
            }
            else
            {
                currentIndex--;
            }

            return Current;
        }

        public bool OnLast()
        {
            if (currentIndex < LastIndex-1)
            {
                return true;
            }

            return false;
        }

        public bool OnFirst()
        {
            if (currentIndex == 1)
            {
                return true;
            }

            return false;
        }
        public T Current
        {
            get
            {
                currentIndex = Mathf.Clamp(currentIndex, 0, LastIndex);
                return dtos[currentIndex];
            }
        }


        public void SetCurrentIndex(int index) => currentIndex = index;


    }
}
