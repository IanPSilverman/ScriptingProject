using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinGetter : MonoBehaviour
{
    TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void ChangeCoins(string coins)
    {
        text.text = coins;
    }
}