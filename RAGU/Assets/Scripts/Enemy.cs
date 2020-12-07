using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public static int dead;
    int k;
    public GameObject healthtool;
    public float health = 5;
    private float healthUI;
    int number;
    public Image UIHP;
    void Start()
    {
        k = PlayerPrefs.GetInt("kolvo", k);
        SetKol();
        healthUI = health;
    }

    public void SetKol()
    {
        k++;
        PlayerPrefs.SetInt("kolvo", k);
    }
    void Update()
    {
        UIHP.fillAmount = health / healthUI;
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            number = Random.Range(1, 11);

            if (number == 5)
            {
                Instantiate(healthtool, transform.position, Quaternion.identity);
            }
            Die();
        }
    }
    void Die()
    {
        dead++;
        DestroyImmediate(gameObject);
    }

    //public void LoadData(SaveLoad.Save.EnemySaveData save)
    //{
    //    transform.position = new Vector2(save.Position.x, save.Position.y);
    //}
}