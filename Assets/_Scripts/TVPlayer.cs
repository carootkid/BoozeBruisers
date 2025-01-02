using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TVPlayer : MonoBehaviour
{  
    public VideoPlayer videoPlayer;
    public VideoClip[] videoClips;

    void Start()
    {
        videoPlayer.loopPointReached += WhenClipFinished;
    }

    void OnEnable()
    {
        if (videoClips.Length > 0)
        {
            int randomIndex = Random.Range(0, videoClips.Length);
            PlayClip(randomIndex);
        }
    }

    void PlayClip(int index)
    {
        if (index >= 0 && index < videoClips.Length)
        {
            videoPlayer.clip = videoClips[index];
            videoPlayer.Play();
        }
    }

    void WhenClipFinished(VideoPlayer source)
    {
        if (videoClips.Length > 0)
        {
            int randomIndex = Random.Range(0, videoClips.Length);
            PlayClip(randomIndex);
        }
    }
}
