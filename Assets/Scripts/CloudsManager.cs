using UnityEngine;

public class CloudsManager : MonoBehaviour
{

    [SerializeField] SceneField gameScene;

    private void Awake()
    {
        SceneHandler.LoadScene(gameScene, additive: true);
    }
}
