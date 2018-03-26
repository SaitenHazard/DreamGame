using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour {

    public static Status instance;

    private GameObject status;

    private void Awake()
    {
        instance = this;
        status = instance.gameObject;
    }

    public void Show(bool show)
    {
        status.SetActive(show);
    }
}
