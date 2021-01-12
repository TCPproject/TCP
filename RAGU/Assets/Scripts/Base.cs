using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Base : MonoBehaviour
{
    //[SerializeField] protected GameObject DeadMenu, PauseMenu, Joy1, Joy2, But, nextwave, compl, startwave;
    public float health = 100;
    private float healthUI;
    //public GameObject base0, base1, base2, base3, base4, base5;
    public Image UIHPBase;
    void Start()
    {
        healthUI = health;
    }

    void Update()
    {
        UIHPBase.fillAmount = health / healthUI;
    }

    public void TakeDamage(float Damage)
    {
        health -= Damage;
        if (health <= 0)
        {
            StartCoroutine(Dead());
        }
    }

    IEnumerator Dead()
    {
        yield return new WaitForSeconds(0.18f);
        Destroy(gameObject);
    }
    //public void Deady(GameObject a, GameObject b, GameObject c, GameObject d, GameObject e, GameObject f, GameObject g, GameObject k)
    //{
    //    a.SetActive(false);
    //    b.SetActive(false);
    //    c.SetActive(false);
    //    d.SetActive(true);
    //    e.SetActive(false);
    //    f.SetActive(false);
    //    g.SetActive(false);
    //    k.SetActive(false);
    //    Time.timeScale = 0;
    //}
}
