using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ready : MonoBehaviour
{
    public GameObject CamParent;
    public GameObject Camera2;
    public void SwitchCameraT()
    {
        Camera2.SetActive(true);
        CamParent.SetActive(false);
    }
}
