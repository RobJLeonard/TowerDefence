using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    public static int Money;
    public int startMoney = 400;


    public Text playerMoney;
    
    //Init stats
    private void Start()
    {
        Money = startMoney;
        
    }


    //Update and display stats
    public void Update()
    {
        playerMoney.text = ("Cash Money: " + Money.ToString());
    }


}
