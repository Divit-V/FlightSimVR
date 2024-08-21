using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler
{
    public static void LoadScene(string sceneName, bool additive = false)
    {
        SceneManager.LoadScene(sceneName, additive ? LoadSceneMode.Additive : LoadSceneMode.Single);
        //SceneManager.LoadScene("VRFlight", LoadSceneMode.Additive);

        //Scene scene = GetSceneFromName(sceneName);
        //if (additive)
        //{
        //    Scene scene = GetSceneFromName(sceneName);
        //    //SceneManager.GetSceneByPath
        //    Debug.Log($"Scene name: {sceneName}, scene found: {scene != null}, scene: {scene.name}, index: {scene.buildIndex}");
        //    if (!scene.isLoaded)
        //    {
        //        SceneManager.LoadSceneAsync(scene.buildIndex, LoadSceneMode.Additive);
        //    }
        //} else
        //{
        //    SceneManager.LoadScene(sceneName);
        //}
    }

    //static Scene GetSceneFromName(string sceneName)
    //{
        //for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        //{
            //Debug.Log(SceneManager.GetSceneByBuildIndex(2).name);
            //Debug.Log(scene.name);
            //Scene scene = SceneManager.GetSceneByBuildIndex(i);
            //if (scene.name == sceneName)
            //{
            //    Debug.Log("Found");
            //    return scene;
            //}
            //else
            //{
            //    Debug.Log($"Wrong: {scene.name}, Wanted: {sceneName}");
            //}
        //}
    //    Debug.Log("Failed");
    //    return default;
    //}
}
