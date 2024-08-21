using UnityEngine;

public class PersistentSingleton : MonoBehaviour
{

    public static PersistentSingleton Instance;

    static Transform cloudsCam;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        } else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public static void UpdateCloudsCam(Transform planeCam)
    {
        if (cloudsCam == null) return;

        cloudsCam.rotation = planeCam.rotation;
        cloudsCam.position = planeCam.position;
    }

    public static void SetCloudsCam(Transform _cloudsCam) => cloudsCam = _cloudsCam;
    
}
