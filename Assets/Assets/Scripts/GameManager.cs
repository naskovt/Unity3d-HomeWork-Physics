using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Text slowMotionText;

    internal static int score = 0;
    internal static bool isSlowMotionEnabled = false;

    private float stopwatch;
    private float framesCount = 0;
    private Stopwatch globalStopwatch;
    private int slowMotionDelay = 100;
    private int slowMotionCounter = 0;

    // Use this for initialization
    void Start () {
        globalStopwatch = new Stopwatch();
    }
	
	// Update is called once per frame
	void Update () {

        //FrameCounter();

        if (isSlowMotionEnabled)
        {
            slowMotionText.text = "Slow Motion!";
            
            slowMotionCounter++;
            if (slowMotionCounter == slowMotionDelay)
            {
                slowMotionCounter = 0;
                SlowMotion(false);
                slowMotionText.text = "";
            }
        }


    }

    private void FrameCounter()
    {
        if (!globalStopwatch.IsRunning)
        {
            globalStopwatch.Start();
        }

        framesCount++;

        if (globalStopwatch.ElapsedMilliseconds > 990)
        {
            print("Fps:" + framesCount);
            globalStopwatch.Reset();
            framesCount = 0;
        }

        stopwatch += Time.deltaTime;
    }

    public static void PauseGame()
    {
        Time.timeScale = 0;
    }

    public static void ContinueGame()
    {
        Time.timeScale = 1;
    }

    public static void SlowMotion(bool phase)
    {
        if (phase == true)
        {
            isSlowMotionEnabled = !isSlowMotionEnabled;
            Time.timeScale = 0.5f;
        }
        else
        {
            isSlowMotionEnabled = !isSlowMotionEnabled;
            Time.timeScale = 1f;
        }
    }

    public static void addScore()
    {
        score += 10;
    }
}
