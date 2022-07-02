using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Screens")]

    public GameObject startScreen;

    public GameObject AR;

    public VimeoController videos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void playIntroVideo()
    {
        videos.playVideo(VimeoController.video.INTRO, playTutorialVideo);
    }

    void playTutorialVideo()
    {
        videos.playVideo(VimeoController.video.TUTORIAL, closeVideo);
    }

    public void closeVideo()
    {
        videos.gameObject.SetActive(false);
    }

    void startAR()
    {
        AR.SetActive(true);
    }

    public void startNewGame()
    {
        Debug.Log("Start Game");

        startScreen.SetActive(false);

        startAR();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
