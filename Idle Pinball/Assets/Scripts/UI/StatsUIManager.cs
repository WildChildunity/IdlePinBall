using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUIManager : MonoBehaviour
{
    public Text MoneyDisplay;
    public Text AmountOfBalls;
    public Text AmountOfBumpers;

    public Text AverageKills;
    public Text AveragePoints;
    public Text AverageDamage;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoneyDisplay.text = $"Money: {Player.Instance.Money.ToString("0.0")}";
        AmountOfBalls.text = $"Balls:{Player.Instance.Balls.Count}/{Player.Instance.AmountOfBalls}";
        AmountOfBumpers.text = $"Bumpers:{Player.Instance.AmountOfBumpers}/{BumperManager.Instance.Bumpers.Count}";


        float averagedamage = ((Player.Instance.Balls.Count * Player.Instance.BallDamage) + (Player.Instance.Balls.Count * Player.Instance.BallDamage * (Player.Instance.AmountOfBumpers * 0.05f - 0.05f)))  / 3;
        float averageKilled =  averagedamage / Player.Instance.BumperPoints;

        AverageDamage.text = $"Idle Avg Damage: {Mathf.Round(averagedamage * 60)}";
        AverageKills.text = $"Idle Avg Kills: {Mathf.Round(averageKilled * 60)}";
        AveragePoints.text = $"Idle Avg Points: {Mathf.Round(averageKilled * 60) * Player.Instance.BumperPoints}";

    }
}
