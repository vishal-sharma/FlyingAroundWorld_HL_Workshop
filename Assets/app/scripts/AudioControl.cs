using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Avanade.HoloLens.Workshop1
{
    public class AudioControl : Singleton<AudioControl>
    {

        [Tooltip("AudioSource that shall be used to play all audios")]
        public AudioSource AudioSource;

        private readonly string EiffelTowerAudioPath = "audios/EiffelTower";
        private readonly string StatueOfLibertyAudioPath = "audios/StatueOfLiberty";

        private AudioClip eiffelTowerAudioClip;
        private AudioClip statueOfLibertyAudioClip;

        public void LoadEiffelTowerAudio()
        {
            if (eiffelTowerAudioClip == null)
                eiffelTowerAudioClip = Resources.Load<AudioClip>(EiffelTowerAudioPath);
        }

        public void LoadStatueOfLibertyAudio()
        {
            if (statueOfLibertyAudioClip == null)
                statueOfLibertyAudioClip = Resources.Load<AudioClip>(StatueOfLibertyAudioPath);
        }

        public void PlayEiffelTowerClip()
        {
            PlayAudio(eiffelTowerAudioClip);
        }

        public void PlayStatueOfLibertyClip()
        {
            PlayAudio(statueOfLibertyAudioClip);
        }


        private float PlayAudio(AudioClip clip)
        {
            AudioSource.PlayOneShot(clip);
            return clip.length;
        }
    }
}

