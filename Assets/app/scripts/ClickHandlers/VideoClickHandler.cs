using HoloToolkit.Unity.InputModule;
using UnityEngine;

namespace Avanade.HoloLens.Workshop1
{
    public class VideoClickHandler : MonoBehaviour, IInputClickHandler
    {
        public void OnInputClicked(InputClickedEventData eventData)
        {
            GameStateMachine.Instance.PlayVideoForSelectedBuilding();
        }
    }
}
