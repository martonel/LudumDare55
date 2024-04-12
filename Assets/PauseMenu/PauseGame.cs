using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    // Start is called before the first frame update

    //public Text text;
    private bool TimerActive;
    public Animator anim;
    public GameManager gameManager;
    private bool isRestart = false;
    private bool isWin = false;
    public Button pauseButton;
    void Start()
    {

        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameManager");
        gameManager = objs[0].gameObject.GetComponent<GameManager>();

        TimerActive = true;
    }
    private void Update()
    {
        if (anim != null)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Tab))
            {
                PauseTheGame();
            }
        }
    }
    public void PauseTheGame()
    {
        //Debug.Log("elindul");
        TimerActive = !TimerActive;
        anim.enabled = true;
        if (isRestart)
        {
            pauseButton.interactable = false;
            anim.Play(TimerActive ? "EndAnimDown" : "EndAnim");

        }
        else if (isWin)
        {
            pauseButton.interactable = false;
            anim.Play(TimerActive ? "WinAnimDown" : "WinAnimUp");
        }
        else
        {
            anim.Play(TimerActive ? "PauseDown" : "PauseUp");
        }
        Time.timeScale = TimerActive ? 1 : 0;       
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Restart()
    {
        isRestart = true;
        PauseTheGame();
    }

    public void Win()
    {
        isWin = true;
        PauseTheGame();
    }

    public void SetTimeToActive()
    {
        Time.timeScale = 1;
    }

    //https://gamedevbeginner.com/the-right-way-to-pause-the-game-in-unity/
}
