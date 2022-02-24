using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{

    int AmountOfCoins;
    
    void Start()
    {
        AmountOfCoins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Add(int amount)
    {
        AmountOfCoins += amount;
    }

    public int GetAmount()
    {
        return AmountOfCoins;
    }
}
