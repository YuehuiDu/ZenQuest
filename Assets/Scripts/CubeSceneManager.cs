using UnityEngine;

public class CubeSceneManager : MonoBehaviour
{
    // public GameObject smallSpherePrefab;
    // public GameObject mediumSpherePrefab;
    // public GameObject largeSpherePrefab;

    // private GameObject currentSphere;
    public static int cubeState = 0;



    void Start()
    {
  
    }
    void Update()
    {

    }
    

    public void SelectScene1()
    {
        Debug.LogWarning("Cube State is 1");
        cubeState = 1;
    }
    
    public void SelectScene2()
    {
        Debug.LogWarning("Cube State is 2");
        cubeState = 2;
    }
    
    public void SelectScene3()
    {
        Debug.LogWarning("Cube State is 3");
        cubeState = 3;
    }

}
