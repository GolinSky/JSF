using UnityEngine;

namespace CodeFramework.Runtime.Controllers.View
{
    public class CustomMonoBehaviour: MonoBehaviour
    {
        public bool IsActive => gameObject != null && gameObject.activeInHierarchy;
        
        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    }
}