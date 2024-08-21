using UnityEngine;

public class MainMenu : MonoBehaviour
{

    [SerializeField] SceneField cloudsScene;

    private void Awake()
    {
        SceneHandler.LoadScene(cloudsScene);
    }
}
