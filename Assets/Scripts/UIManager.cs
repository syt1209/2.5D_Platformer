using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _coinTxt, _liveTxt;

    public void UpdateCoinText(int coins) 
    {
        _coinTxt.text = "Coins: " + coins.ToString();
    }

    public void UpdateLiveText(int lives)
    {
        _liveTxt.text = "Lives: " + lives.ToString();
    }
}
