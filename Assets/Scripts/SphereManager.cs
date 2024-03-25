using UnityEngine;

public class SphereManager : MonoBehaviour
{
    public GameObject smallSpherePrefab;
    public GameObject mediumSpherePrefab;
    public GameObject largeSpherePrefab;

    private GameObject currentSphere;
    public int sphereState = 0;
    private int previousSphereState = -1;  // -1 indicates no previous sphere

    private Vector3 SpwanPosition; // yuehui updated new spawn position for spheres
    void Start()
    {
        // Log the initial state on start
        UnityEngine.Debug.LogWarning($"Initial sphere state: {sphereState}");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeSphere();
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            UndoSphereChange();
        }
    }

    public void ChangeSphere()
    {
        UnityEngine.Debug.LogWarning($"Changing sphere. Current state: {sphereState}");
        if (currentSphere != null)
        {
            Destroy(currentSphere);
            UnityEngine.Debug.LogWarning("Sphere destroyed");
        }

        previousSphereState = sphereState-1; //The last state
        CreateSphere(sphereState);
        sphereState = (sphereState + 1) % 3;
    }

    public void UndoSphereChange()
    {
        if (previousSphereState != -1)
        {
            if (currentSphere != null)
            {
                Destroy(currentSphere);
                UnityEngine.Debug.LogWarning("Sphere destroyed for undo");
            }

            CreateSphere(previousSphereState);
            sphereState = previousSphereState;  // Revert the state
            previousSphereState = previousSphereState - 1;  // Reset the previous state
        }
    }

    void CreateSphere(int state)
    {
        SpwanPosition = new Vector3(0f, 1.41f, 1.35f); // aligned with OVRCamera center
        switch (state)
        {
            case 0:
                currentSphere = Instantiate(smallSpherePrefab, SpwanPosition, Quaternion.identity); //yuehui updates - changed the spawn position
                UnityEngine.Debug.LogWarning("Small sphere created");
                break;
            case 1:
                currentSphere = Instantiate(mediumSpherePrefab, SpwanPosition, Quaternion.identity);
                UnityEngine.Debug.LogWarning("Medium sphere created");
                break;
            case 2:
                currentSphere = Instantiate(largeSpherePrefab, SpwanPosition, Quaternion.identity);
                UnityEngine.Debug.LogWarning("Large sphere created");
                break;
        }
    }
}
