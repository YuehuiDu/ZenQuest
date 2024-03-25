using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour


{
    public void LoadScene()
    {
        if (CubeSceneManager.cubeState == 1)
        {
            Debug.LogWarning("Scene1 is loading");
            SceneManager.LoadScene("Scene1");
            
        }
        else if (CubeSceneManager.cubeState == 2)
        {
            Debug.LogWarning("Scene2 is loading");
            SceneManager.LoadScene("Scene2");
            
        }
        else if (CubeSceneManager.cubeState == 3)
        {
            Debug.LogWarning("Scene3 is loading");
            SceneManager.LoadScene("Scene3");
        }
        else
        {
            
        }
    }

    public void LoadStressLevelScene()
    {
        Debug.Log("Go to stress level scene");
        SceneManager.LoadScene("Scene0");
    }

    public void BackMainScene()
    {
        Debug.Log("Back to the Scene0");
        SceneManager.LoadScene("Scene00");
        
    }
    

}
