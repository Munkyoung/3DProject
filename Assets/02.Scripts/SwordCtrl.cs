using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCtrl : MonoBehaviour
{
    public GameObject obj;
    public void EndSwing()
    {
        obj.SetActive(false);
    }
}
