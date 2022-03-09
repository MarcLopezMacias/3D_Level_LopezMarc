using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text TimeText;

    public Text CoinsText;

    public Text GameOverText;
    public Text GameOverScoreText;
    private string GameOverString;
    public int GameOverScreenTime;

    private bool mainLoop;

    // BUGZ TO SOLVE

    void Start()
    {
        mainLoop = true;
        GameOverString = "G A M E  O V E R";
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        if (mainLoop)
        {
            UpdateCoins();
            UpdateTime();
            NoGameOver();
        }
        else
        {
            GameOverText.text = GameOverString;
            GameOverScoreText.text = "Final Score: " + GetCoins(); ;
        }
    }

    private int GetTimeLeft()
    {
        return GameManager.Instance.GetComponent<TimerManager>().GetTimeLeft();
    }

    private void UpdateCoins()
    {
        CoinsText.text = "Coins: " + GetCoins();
    }

    private int GetCoins()
    {
        return GameManager.Instance.GetComponent<CoinManager>().GetAmount();
    }

    private void UpdateTime()
    {
        TimeText.text = "Time Left: " + GetTimeLeft();
    }

    private void NoGameOver()
    {
        GameOverText.text = "";
        GameOverScoreText.text = "";
    }

    public void GameOver()
    {
        mainLoop = false;
        StartCoroutine(DisplayGameOverScreen());
    }

    private IEnumerator DisplayGameOverScreen()
    {
        mainLoop = false;
        yield return new WaitForSeconds(GameOverScreenTime);

    }
}
