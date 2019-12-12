using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] int health = 100;
    [SerializeField] int gold = 0;
    [SerializeField] int round = 1;
    public TextMeshProUGUI roundtxt;
    public TextMeshProUGUI goldtxt;
    public Slider healthbar;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void EnemyKill() 
    {
        gold += 10;
        goldtxt.text = ("$" + gold);
    }

    public void TakeDamage()
    {
        healthbar.value -= 5;
    }
    public void RoundIncrease()
    {
        roundtxt.text = ("Round: " + round++);
    }
}
