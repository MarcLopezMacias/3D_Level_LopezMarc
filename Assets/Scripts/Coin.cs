using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField]
    int CoinValue;

    void Start()
    {
        MakeSureItsAtLeastOne();
    }

    private void MakeSureItsAtLeastOne()
    {
        if (CoinValue <= 0)
        {
            CoinValue = 1;
        }
    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            AddCoin();
        }
    }

    private void AddCoin()
    {
        Debug.Log("SHOULD ADD COIN");
        GameManager.Instance.GetComponent<CoinManager>().Add(CoinValue);
    }


}
