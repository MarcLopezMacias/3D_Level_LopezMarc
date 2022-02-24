using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text LifesText;
    public Text HealthText;

    private Text CoinsText;

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
            LifesText.text = "Lifes: " + GameManager.Instance.Player.GetComponent<Player>().GetLifes();
            HealthText.text = "HP: " + GameManager.Instance.Player.GetComponent<Player>().GetHealth()
            //   + " / " + GameManager.Instance.Player.GetComponent<Player>().GetMaxHealth();
            ;

            CoinsText.text = "Coins: " + GetCoins();

            GameOverText.text = "";
            GameOverScoreText.text = "";
        }
        else
        {
            LifesText.text = "";
            HealthText.text = "";

            GameOverText.text = GameOverString;
            GameOverScoreText.text = "Final Score: " + GameManager.Instance.GetComponent<CoinManager>().GetAmount();

        }
    }

    private int GetCoins()
    {
        return GameManager.Instance.GetComponent<CoinManager>().Amount;
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
