using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightButton : MonoBehaviour
{
    PlatformManager _manager;

    void Start()
    {
        _manager = FindObjectOfType<PlatformManager>();

        GetComponent<MeshRenderer>().material.color = LevelEditor.Instance.RightButtonColor;
    }

    void OnMouseDown()
    {
        if (!GameManager.Instance.GameActive) { return; }

        _manager.TriggerRightButton();
    }
}
