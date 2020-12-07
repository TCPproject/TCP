using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DroneController : MonoBehaviour
{
    [SerializeField] protected GameObject DeadMenu, PauseMenu, Joy1, Joy2, But, nextwave, compl, startwave;
    public Image UIHPplayer;
    public Text scoresText;
    private int score = 0;
    public float PlayerHealth;
    public float MaxHealth = 100;
    private float PlayerHealthUI;
    public float HealthToolsNumber = 5;
    private Vector2 moveVelocity;
    public Transform bumpPoint;
    public GameObject bumpTrack;
    public GameObject bullet;
    public VariableJoystick joystick1;
    public FixedJoystick joystick2;
    protected Joybutton joybutton;
    public float Speed = 3f;
    Rigidbody2D rb;

    void Start()
    {
        int k = 0;
        PlayerPrefs.SetInt("kolvo", k);
        score = PlayerPrefs.GetInt("Score", score);
        PlayerHealth = MaxHealth;
        PlayerHealthUI = PlayerHealth;
        joystick1 = FindObjectOfType<VariableJoystick>();
        joystick2 = FindObjectOfType<FixedJoystick>();
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        {
            UIHPplayer.fillAmount = PlayerHealth / PlayerHealthUI;
        }
        Vector2 pos = new Vector2(joystick1.Horizontal, joystick1.Vertical);
        moveVelocity = pos.normalized * Speed;
        if (joystick1.Horizontal < 0 && !joystick2.Pressed)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (joystick1.Horizontal > 0 && !joystick2.Pressed)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (joystick2.Horizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (joystick2.Horizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (!joystick1.Pressed && !joystick2.Pressed)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        score = PlayerPrefs.GetInt("Score", score);
        scoresText.text = "Money:  " + score + " ";
    }
void bump()
    {
        Instantiate(bumpTrack, bumpPoint.position, bumpPoint.rotation);
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Speed * Time.deltaTime);
    }
    public void TakeDamagePlayer(float DamagePlayer) // дамаг герою и смерть
    {
        PlayerHealth -= DamagePlayer;
        if (PlayerHealth <= 0)
        {
            Deady(Joy1, Joy2, PauseMenu, DeadMenu, But, nextwave, compl, startwave);
            DiePlayer();
        }
    }
    public void Deady(GameObject a, GameObject b, GameObject c, GameObject d, GameObject e, GameObject f, GameObject g, GameObject k)
    {
        a.SetActive(false);
        b.SetActive(false);
        c.SetActive(false);
        d.SetActive(true);
        e.SetActive(false);
        f.SetActive(false);
        g.SetActive(false);
        k.SetActive(false);
        Time.timeScale = 0;
    }
    public void DiePlayer()
    { 
        Destroy(gameObject);
    }
    // востановление хп аптеской
    public void HPadd()
    {
        ChangeHealth(HealthToolsNumber);
    }
    public void ChangeHealth(float amount)
    {
        PlayerHealth = Mathf.Clamp(PlayerHealth + amount, 0, MaxHealth);
        Debug.Log(PlayerHealth + "/" + MaxHealth);
    }
}