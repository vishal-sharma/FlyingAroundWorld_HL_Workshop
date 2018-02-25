using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Avanade.HoloLens.Workshop1
{
    public class ClickableBuilding : MonoBehaviour, IInputClickHandler
    {
        public void OnInputClicked(InputClickedEventData eventData)
        {
            GameStateMachine.Instance.OnBuildingSelected(this.gameObject);
        }
    }
}
