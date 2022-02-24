﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // BUGZ TO SOLVE

    public static GameManager Instance { get { return _instance; } }
    private static GameManager _instance;

    public GameObject Player { get { return _player; } }
    private GameObject _player;

    public static UIController UIController;
    public static CoinManager CoinManager;

    private static GameObject MainCamera;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            Debug.Log("GameManager DESTROYED");
        }
        _instance = this;
        DontDestroyOnLoad(_instance);
    }

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player");

        UIController = GameObject.Find("Canvas").GetComponent<UIController>();
        CoinManager = gameObject.GetComponent<CoinManager>();


        MainCamera = GameObject.FindWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (_player == null)
        {
            _player = GameObject.FindWithTag("Player");
        }
    }

    public void ResetStage()
    {
        ResetPlayerPosition();
        ResetTimer();
    }

    public void ResetPlayerPosition()
    {
        Player.GetComponent<Player>().ResetPosition();
    }

    public void GameOver()
    {
        UIController.GameOver();
        StartCoroutine(WaitForGameOverScreen());
    }

    private void ResetGame()
    {
        GoToStartMenu();
    }

    private IEnumerator WaitForGameOverScreen()
    {
        yield return new WaitForSeconds(UIController.GameOverScreenTime);
        ResetGame();
    }

    private void GoToStartMenu()
    {
        SceneManager.LoadScene("RogueLikeStartMenu");
    }

    public void GoToInGameScene()
    {
        SceneManager.LoadScene("RogueLikeInGame");
    }

    public bool SuccessfulRol(float DropChance)
    {
        if (UnityEngine.Random.Range(0, 100) <= DropChance)
        {
            return true;
        }
        else return false;
    }
}