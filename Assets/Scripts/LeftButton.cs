using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftButton : MonoBehaviour
{
    PlatformManager _manager;

    void Start()
    {
        _manager = FindObjectOfType<PlatformManager>();

        GetComponent<MeshRenderer>().material.color = LevelEditor.Instance.LeftButtonColor;
    }

    void OnMouseDown()
    {
        if (!GameManager.Instance.GameActive) { return; }

        _manager.TriggerLeftButton();
    }
}
