using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField]
    int CoinValue;
    [SerializeField]
    int ExtraTimeValue;

    void Start()
    {
        AddToTotal();
        MakeSureItsAtLeastOne();
    }

    private void MakeSureItsAtLeastOne()
    {
        if (CoinValue <= 0)
        {
            CoinValue = 1;
        }
        if (ExtraTimeValue <= 0)
        {
            ExtraTimeValue = 1;
        }
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            AddCoin();
            AddTime();
            DeleteCoin();
        }
    }

    private void AddCoin()
    {
        // Debug.Log("SHOULD ADD COIN");
        GameManager.Instance.GetComponent<CoinManager>().Add(CoinValue);
    }

    private void AddTime()
    {
        GameManager.Instance.GetComponent<TimerManager>().IncreaseTime(ExtraTimeValue);
    }

    private void DeleteCoin()
    {
        Destroy(this.gameObject);
    }

    private void AddToTotal()
    {
        GameManager.Instance.TotalCoins++;
    }


}
