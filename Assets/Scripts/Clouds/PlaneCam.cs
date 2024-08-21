using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCam : MonoBehaviour
{
    void Update()
    {
        PersistentSingleton.UpdateCloudsCam(transform);
    }
}
