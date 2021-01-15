using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heroesFollow : MonoBehaviour
{
    public GameObject Heroes;
        public void Startspawn()
        {
            Instantiate(Heroes, transform.position, Quaternion.identity);
        }
}
