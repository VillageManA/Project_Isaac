using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupScore : MonoBehaviour
{
    private PlayerStats Player;
    [SerializeField] private Text Score;
    public int moneyScore;
    public int BombScore;
    public int KeyScore;
    private void Awake()
    {
        moneyScore = Player.Money;
        BombScore = Player.Boom;
        KeyScore = Player.Key;
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("MoneyScore", moneyScore);
        PlayerPrefs.SetInt("BombScore", BombScore);
        PlayerPrefs.SetInt("KeyScore", KeyScore);
    }
}
