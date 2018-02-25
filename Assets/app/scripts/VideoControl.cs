using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace Avanade.HoloLens.Workshop1
{
    public class VideoControl : Singleton<VideoControl>
    {
        [Tooltip("Screen that shall be used to display the video")]
        public GameObject Screen;

        [Tooltip("Texture to be used for Video Player")]
        public Texture VideoTexture;

        private readonly string EiffelTowerVideoPath = "videos/EiffelTower";
        private readonly string StatueOfLibertyVideoPath = "videos/StatueOfLiberty";

        private VideoPlayer videoPlayer;
        private AudioSource audioSource;
        private VideoClip eiffelTowerVideoClip;
        private VideoClip statueOfLibertyVideoClip;

        void Start()
        {
            videoPlayer = Screen.GetComponent<VideoPlayer>();
            audioSource = Screen.GetComponent<AudioSource>();
        }

        public void LoadEiffelTowerVideo()
        {
            if (eiffelTowerVideoClip == null)
                eiffelTowerVideoClip = Resources.Load<VideoClip>(EiffelTowerVideoPath);
        }

        public void LoadStatueOfLibertyVideo()
        {
            if (statueOfLibertyVideoClip == null)
                statueOfLibertyVideoClip = Resources.Load<VideoClip>(StatueOfLibertyVideoPath);
        }

        public void PlayEiffelTowerClip() => PlayVideo(eiffelTowerVideoClip);
        public void PlayStatueOfLibertyClip() => PlayVideo(statueOfLibertyVideoClip);


        private void PlayVideo(VideoClip clip)
        {
            Screen.GetComponent<Renderer>().material.mainTexture = VideoTexture;
            videoPlayer.clip = clip;
            videoPlayer.skipOnDrop = true;
            videoPlayer.EnableAudioTrack(0, true);
            videoPlayer.SetTargetAudioSource(0, audioSource);
            videoPlayer.Play();
        }

    }

}