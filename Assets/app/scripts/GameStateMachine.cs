using HoloToolkit.Unity;
using System.Collections;
using UnityEngine;

namespace Avanade.HoloLens.Workshop1
{

    public class GameStateMachine : Singleton<GameStateMachine>
    {
        [Tooltip("Airplane gameobject to fly around buildings")]
        public GameObject AirPlane;        

        [Tooltip("A float value indicating speed for flying")]
        public float Speed;

        private Transform PlaneIntialTransform;

        private GameObject SelectedBuilding;

        void Start()
        {
            PlaneIntialTransform = AirPlane.transform;
        }
             

        public void OnBuildingSelected(GameObject selectedBuilding)
        {
            UpdateSelectedBuilding(selectedBuilding);        
            FlyPlane();
            LoadResources();
            ShowInfoPanel();
        }

        public void FlyPlane()
        {
            Vector3 flyTo = SelectedBuilding.transform.localPosition;
            StartCoroutine(Fly(flyTo));
        }

        public void Reset()
        {
            AirPlane.transform.localPosition = PlaneIntialTransform.localPosition;
            AirPlane.transform.localRotation = PlaneIntialTransform.localRotation;
            SelectedBuilding = null;
        }

        IEnumerator Fly(Vector3 endPos)
        {
            var i = 0.0f;
            var height = 2f;
            var startPos = AirPlane.transform.localPosition;
            var highStartPos = new Vector3(startPos.x, height, startPos.z);
            var highEndPos = new Vector3(endPos.x, height, endPos.z);
            AirPlane.transform.localPosition = Vector3.Lerp(highStartPos, highEndPos, 0);
            while (i < 1.0f)
            {
                i += Time.deltaTime * Speed;
                AirPlane.transform.localPosition = Vector3.Slerp(highStartPos, highEndPos, i);
                yield return null;
            }
            AirPlane.transform.localPosition = highEndPos;
        }

        public void LoadResources()
        {
            switch (SelectedBuilding.name)
            {
                case BuildingNames.EIFFEL_TOWER:
                    InfoTextControl.Instance.LoadEiffelTowerTexture();
                    AudioControl.Instance.LoadEiffelTowerAudio();
                    VideoControl.Instance.LoadEiffelTowerVideo();
                    break;
                case BuildingNames.STATUE_LIBERTY:
                    InfoTextControl.Instance.LoadStatueOfLibertyTexture();
                    AudioControl.Instance.LoadStatueOfLibertyAudio();
                    VideoControl.Instance.LoadStatueOfLibertyVideo();
                    break;
            }
        }

        public void PlayAudioForSelectedBuilding()
        {
            switch (SelectedBuilding.name)
            {
                case BuildingNames.EIFFEL_TOWER:
                    AudioControl.Instance.PlayEiffelTowerClip();
                    break;
                case BuildingNames.STATUE_LIBERTY:
                    AudioControl.Instance.PlayStatueOfLibertyClip();
                    break;
            }
        }

        public void PlayVideoForSelectedBuilding()
        {
            switch (SelectedBuilding.name)
            {
                case BuildingNames.EIFFEL_TOWER:
                    VideoControl.Instance.PlayEiffelTowerClip();
                    break;
                case BuildingNames.STATUE_LIBERTY:
                    VideoControl.Instance.PlayStatueOfLibertyClip();
                    break;
            }
        }

        public void DisplayInfoTextForSelectedBuilding()
        {
            switch (SelectedBuilding.name)
            {
                case BuildingNames.EIFFEL_TOWER:
                    InfoTextControl.Instance.DisplayEiffelTowerInfoText();
                    break;
                case BuildingNames.STATUE_LIBERTY:
                    InfoTextControl.Instance.DisplayStatueOfLibertyInfoText();
                    break;
            }
        }

        private void UpdateSelectedBuilding(GameObject newSelectedBuilding)
        {
            if (SelectedBuilding != null)
            {
                var moreInfoPanel = SelectedBuilding.transform.Find("MoreInfo").gameObject;
                moreInfoPanel.SetActive(false);
            }            

            SelectedBuilding = newSelectedBuilding;            
        }

        private void ShowInfoPanel()
        {
            var moreInfoPanel = SelectedBuilding.transform.Find("MoreInfo").gameObject;
            moreInfoPanel.SetActive(true);
        }

    }

    public class BuildingNames
    {
        public const string EIFFEL_TOWER = "EiffelTower";
        public const string STATUE_LIBERTY = "StatueOfLiberty";
    }
}
