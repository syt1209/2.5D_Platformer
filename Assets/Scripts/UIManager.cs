using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private Text _coinTxt;

    private void Start()
    {
        _coinTxt = GameObject.Find("Coin_txt").GetComponent<Text>();

        if (_coinTxt is null) 
        {
            Debug.LogError("Coin text is NULL.");
        }
    }

    public void UpdateCoinText(int coins) 
    {
        _coinTxt.text = "Coins: " + coins.ToString();
    }
}
