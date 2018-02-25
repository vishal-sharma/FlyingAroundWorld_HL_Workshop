using HoloToolkit.Unity.InputModule;
using UnityEngine;

namespace Avanade.HoloLens.Workshop1
{
    public class InfoTextClickHandler : MonoBehaviour, IInputClickHandler
    {
        public void OnInputClicked(InputClickedEventData eventData)
        {
            GameStateMachine.Instance.DisplayInfoTextForSelectedBuilding();
        }
    }
}
