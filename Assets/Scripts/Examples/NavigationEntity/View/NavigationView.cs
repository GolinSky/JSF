namespace UnityEngine.Examples.NavigationEntity.View
{
    public class NavigationView : MyPackage.Runtime.Scripts.Patterns.MVC.View.View
    {
        [SerializeField] private RectTransform buttonParentRect;

        public RectTransform ButtonParentRect => buttonParentRect;
    }
}
