using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Avanade.HoloLens.Workshop1
{
    public class InfoTextControl : Singleton<InfoTextControl>
    {

        [Tooltip("Screen that shall be used to display the info text")]
        public GameObject Screen;

        private readonly string EiffelTowerTexturePath = "textures/EiffelTower";
        private readonly string StatueOfLibertyTexturePath = "textures/StatueOfLiberty";

        private Texture2D eiffelTowerInfoText;
        private Texture2D statueOfLibertyInfoText;

        public void LoadEiffelTowerTexture()
        {
            if (eiffelTowerInfoText == null)
                eiffelTowerInfoText = Resources.Load<Texture2D>(EiffelTowerTexturePath);
        }

        public void LoadStatueOfLibertyTexture()
        {
            if (statueOfLibertyInfoText == null)
                statueOfLibertyInfoText = Resources.Load<Texture2D>(StatueOfLibertyTexturePath);
        }

        public void DisplayEiffelTowerInfoText()
        {
            Screen.GetComponent<Renderer>().material.mainTexture = eiffelTowerInfoText;
        }
        public void DisplayStatueOfLibertyInfoText()
        {
            Screen.GetComponent<Renderer>().material.mainTexture = statueOfLibertyInfoText;
        }

        public void Reset()
        {
            Screen.GetComponent<Renderer>().material.mainTexture = null;
        }

    }
}