using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Avanade.HoloLens.Workshop1
{
    public class AudioClickHandler : MonoBehaviour, IInputClickHandler
    {
        public void OnInputClicked(InputClickedEventData eventData)
        {
            GameStateMachine.Instance.PlayAudioForSelectedBuilding();
        }
    }
}