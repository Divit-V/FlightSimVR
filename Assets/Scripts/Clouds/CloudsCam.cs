using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsCam : MonoBehaviour
{
    private void Awake()
    {
        PersistentSingleton.SetCloudsCam(transform);
    }
}
