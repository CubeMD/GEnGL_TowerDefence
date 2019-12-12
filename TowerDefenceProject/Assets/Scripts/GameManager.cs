using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float damagePerEnemy;
    public int cashPerEnemy;
    public GameObject GameOverMenu;
    
    private Player player;
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            GetPlayer();
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void GetPlayer()
    {
        player = FindObjectOfType<Player>();
    }

    public void EnemyKilled() 
    {
        player.cash += cashPerEnemy;
        player.cashUI.text = ("$" + player.cash);
    }

    public void PlayerTakenDamage()
    {
        player.hp -= damagePerEnemy;
        player.healthbarUI.value = player.hp;
        AudioManager.instance.PlaySounds("PlayerTakenDamage");
    }
    public void RoundIncrease(int round)
    {
        player.roundUI.text = ("Round: " + round);
    }

    public void PlayerDead()
    {
        GameOverMenu.SetActive(true);
    }
}
