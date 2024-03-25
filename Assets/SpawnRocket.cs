using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRocket : MonoBehaviour
{
    private Vector3 SpwanPosition;

    private GameObject rocket;
    public GameObject rocketModel;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnRocket()
    {
        SpwanPosition = new Vector3(0f, 1.41f, 1.35f);
        rocket = Instantiate(rocketModel, SpwanPosition, Quaternion.identity);
    }
}
