using UnityEngine;
using UnityEngine.EventSystems;

public class Joybutton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [HideInInspector]
    public bool Pressed;
    public static float timer;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        timer = 0;
        PlayerPrefs.SetFloat("Timer", timer);
        Pressed = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        timer = 0.25f;
        PlayerPrefs.SetFloat("Timer", timer);
        Pressed = false;
    }
}
