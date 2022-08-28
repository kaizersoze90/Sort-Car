using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashDetector : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.GameOver();
    }
}
