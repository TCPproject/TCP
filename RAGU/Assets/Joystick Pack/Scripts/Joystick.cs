using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Test : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public bool Pressed;
    public Image joystickBg;
    public Image joystick;
    Vector2 inputVector;
    private void Start()
    {
        joystickBg = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        Pressed = false;
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBg.rectTransform, eventData.position, eventData.pressEventCamera, out pos))
        {
            pos.x = (pos.x / joystickBg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / joystickBg.rectTransform.sizeDelta.x);
        }

        inputVector = new Vector2(pos.x * 2 - 1, pos.y * 2 - 1);
        inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

        joystick.rectTransform.anchoredPosition = new Vector2(inputVector.x * (joystickBg.rectTransform.sizeDelta.x / 2), inputVector.y * (joystickBg.rectTransform.sizeDelta.y / 2));
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        joystick.rectTransform.anchoredPosition = Vector2.zero;
    }

    public float Horizontal()
    {
        if (inputVector.x != 0)
            return inputVector.x;
        else
            return Input.GetAxis("Horizontal");
    }
    public float Vertical()
    {
        if (inputVector.y != 0)
            return inputVector.y;
        else
            return Input.GetAxis("Vertical");
    }
}
