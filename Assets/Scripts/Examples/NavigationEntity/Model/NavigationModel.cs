using System;
using UnityEngine.Examples.NavigationEntity.View;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.MVC.Model;
using UnityEngine.MyPackage.Runtime.Scripts.Utils.Array;

namespace UnityEngine.Examples.NavigationEntity.Model
{
    [CreateAssetMenu(fileName = "NavigationModel", menuName = "Model/NavigationModel")]
    public class NavigationModel:Model<NavigationType, NavigationButtonView, InternalNavigationModel>
    {

    }

    [Serializable]
    public class InternalNavigationModel:InternalData<NavigationType, NavigationButtonView> {}

    public enum NavigationType
    {
        USUAL_BUTTON = 0,
    }
}
