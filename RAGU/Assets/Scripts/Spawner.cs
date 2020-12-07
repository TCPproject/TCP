using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public Text timer;
    public Text scoresText;
    public GameObject Enemy1, Enemy2, Enemy3, nextwave, spawner, Teleport1, Base, Base1, compl,StartWave;
    [SerializeField] private int scan, k, spawnmob, wave = 1;
    public float SpawnTimer = 10f, sec;
    public Transform[] spawnPos;
    public int dead;

    void Start()
    {
        sec = 3f;
        PlayerPrefs.SetInt("kolvo", k);
        StartCoroutine(SpawnCD());
    }
    void Update()
    {
        dead = Enemy.dead;
        k = PlayerPrefs.GetInt("kolvo", k);
        scoresText.text = "Wave:  " + wave;
        timer.text = "in  " + sec;
    }
    void Repeat()
    {
        StartCoroutine(SpawnCD());
    }
    IEnumerator SpawnCD()
    {
        yield return new WaitForSeconds(SpawnTimer);
        if (wave == 1 && k == 0)
        {
            dead = 0;
            StartWave.SetActive(true);
            yield return new WaitForSeconds(1);
            sec--;
            yield return new WaitForSeconds(1);
            sec--;
            yield return new WaitForSeconds(1);
            StartWave.SetActive(false);
            sec = 3;

            yield return new WaitForSeconds(0.5f);
            nextwave.SetActive(true);
            yield return new WaitForSeconds(2);
            nextwave.SetActive(false);
        }
        switch (wave)
        {
            case 1:
                spawnmob = 6;
                if (dead < spawnmob)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        int number1 = Random.Range(0, 8);
                        int Enemyn = Random.Range(1, 4);
                        if (Enemyn == 1)
                        Instantiate(Enemy1, spawnPos[number1].position, Quaternion.identity);
                        if (Enemyn == 2)
                            Instantiate(Enemy2, spawnPos[number1].position, Quaternion.identity);
                        if (Enemyn == 3)
                            Instantiate(Enemy3, spawnPos[number1].position, Quaternion.identity);
                        yield return new WaitForSeconds(0.3f);
                    }
                }

                if (dead >= spawnmob)
                {
                    do
                    {
                        yield return new WaitForSeconds(2f);

                    } while (dead != k);

                    wave++;

                    nextwave.SetActive(true);
                    yield return new WaitForSeconds(2);
                    nextwave.SetActive(false);

                    k = 0;
                    PlayerPrefs.SetInt("kolvo", k);
                    Enemy.dead = 0;
                    spawnmob = 10;


                    break;
                }

                break;
        case 2:

                if (dead < spawnmob)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        int number1 = Random.Range(0, 8);
                        int Enemyn = Random.Range(1, 4);
                        if (Enemyn == 1)
                            Instantiate(Enemy1, spawnPos[number1].position, Quaternion.identity);
                        if (Enemyn == 2)
                            Instantiate(Enemy2, spawnPos[number1].position, Quaternion.identity);
                        if (Enemyn == 3)
                            Instantiate(Enemy3, spawnPos[number1].position, Quaternion.identity);
                        yield return new WaitForSeconds(0.3f);
                    }
                }

                if (dead >= spawnmob)
                {
                    do
                    {
                        yield return new WaitForSeconds(2f);

                    } while (dead != k);

                    wave++;

                    nextwave.SetActive(true);
                    yield return new WaitForSeconds(2);
                    nextwave.SetActive(false);
                    k = 0;
                    PlayerPrefs.SetInt("kolvo", k);
                    Enemy.dead = 0;
                    spawnmob = 12;
                }

                break;

            case 3:

                if (dead < spawnmob)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        int number1 = Random.Range(0, 8);
                        int Enemyn = Random.Range(1, 4);
                        if (Enemyn == 1)
                            Instantiate(Enemy1, spawnPos[number1].position, Quaternion.identity);
                        if (Enemyn == 2)
                            Instantiate(Enemy2, spawnPos[number1].position, Quaternion.identity);
                        if (Enemyn == 3)
                            Instantiate(Enemy3, spawnPos[number1].position, Quaternion.identity);
                        yield return new WaitForSeconds(0.3f);
                    }
                }

                if (dead >= spawnmob)
                {
                    do
                    {
                        yield return new WaitForSeconds(2f);

                    } while (dead != k);

                    wave++;

                    

                    k = 0;
                    PlayerPrefs.SetInt("kolvo", k);
                    Enemy.dead = 0;

                    compl.SetActive(true);
                    yield return new WaitForSeconds(2);
                    compl.SetActive(false);

                    Teleport1.SetActive(true);
                    StopCoroutine(SpawnCD());
                    break;
                }
                break;
        }

        if (wave < 4)
        {
            Repeat();
        }
        else
        {
            wave = 0;
            Base.SetActive(true);
            Base1.SetActive(false);
            spawner.SetActive(false);
        }
    }
}