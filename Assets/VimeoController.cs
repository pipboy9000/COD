using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vimeo.Player;

public class VimeoController : MonoBehaviour
{
    // Start is called before the first frame update

    public VimeoPlayer intro;
    public VimeoPlayer tutorial;
    public VimeoPlayer ending;

    List<VimeoPlayer> videosList = new List<VimeoPlayer>();

    public enum video { INTRO, TUTORIAL, ENDING};

    VimeoPlayer currentVideo;

    public delegate void OnVideoEnd();

    OnVideoEnd onVideoEnd;

    float lastFrameProgress;

    bool restart = false;

    //controllers
    public GameObject pauseBtn;
    public GameObject playBtn;

    void Start()
    {
        videosList.Add(intro);
        videosList.Add(tutorial);
        videosList.Add(ending);
    }

    void removeAll()
    {
        foreach(VimeoPlayer player in videosList){
            player.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (currentVideo.gameObject.activeSelf && currentVideo.IsPlaying())
        {

        //Debug.Log("is playing:" + currentVideo.IsPlaying() + "   progress:" + currentVideo.GetProgress() + "    last frame progress:" + lastFrameProgress);

            float progress = currentVideo.GetProgress();

            if (progress < lastFrameProgress)
            {

                if (restart)
                {
                    restart = false;
                    lastFrameProgress = progress;
                    return;
                }

                //video ended
                Debug.Log("video ended");
                currentVideo.Pause();
                onVideoEnd();
            } else
            {
                lastFrameProgress = progress;
            }

        }
    }

    public void playVideo(video _video, OnVideoEnd _onVideoEnd)
    {
        if (!gameObject.activeSelf) gameObject.SetActive(true);

        removeAll();

        onVideoEnd = _onVideoEnd;

        lastFrameProgress = -99999;

        switch (_video) {
            case video.INTRO:
                intro.gameObject.SetActive(true);
                currentVideo = intro;
                break;

            case video.TUTORIAL:
                tutorial.gameObject.SetActive(true);
                currentVideo = tutorial;
                break;

            case video.ENDING:
                ending.gameObject.SetActive(true);
                currentVideo = ending;
                break;
        }

        //play video after vimeo player finished loading
        currentVideo.OnFrameReady += currentVideo.Play;

    }

    public void restartVideo()
    {
        restart = true;
        lastFrameProgress = currentVideo.startTime;
        currentVideo.SeekBySeconds(currentVideo.startTime);
        playVideo();
    }

    public void pauseVideo()
    {
        currentVideo.Pause();
        playBtn.SetActive(true);
        pauseBtn.SetActive(false);
    }

    public void playVideo()
    {
        currentVideo.Play();
        playBtn.SetActive(false);
        pauseBtn.SetActive(true);

    }

    public void skipVideo()
    {
        currentVideo.Pause();
        onVideoEnd();
    }

}
