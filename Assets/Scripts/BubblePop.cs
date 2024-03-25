using UnityEngine;

public class BubblePop : MonoBehaviour
{
    public GameObject spherePrefab; // Assign your sphere prefab in the inspector
    private GameObject currentSphere;
    private float timer;
    public AudioClip destructionSound; // Assign your sound clip in the inspector
    private AudioSource audioSource;
    private float spawnInterval;
    private float totalTimeElapsed;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // This line assigns the AudioSource component to your variable
        if (audioSource == null)
        {
            Debug.LogError("No AudioSource component found on the GameObject.");
        }
        CreateSphere();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            DestroySphere();
            Debug.LogWarning("Bubble popped");
            // CreateSphere(); // Create a new sphere immediately after destruction
        }

        timer += Time.deltaTime;
        // if (timer >= 3f)
        // {
        //     DestroySphere(); // Ensures the previous sphere is destroyed
        //     CreateSphere(); // Then creates a new sphere
        // }
        totalTimeElapsed += Time.deltaTime;

        // Adjust spawn interval based on elapsed time
        if (totalTimeElapsed <= 30f)
        {
            spawnInterval = 5f;
        }
        else if (totalTimeElapsed <= 75f)
        {
            spawnInterval = 3f;
        }
        else if (totalTimeElapsed <= 105f)
        {
            // Gradually increase spawn interval from 3 to 5 seconds
            float progress = (totalTimeElapsed - 75f) / 30f;
            spawnInterval = 3f + progress * (5f - 3f);
        }
        else
        {
            spawnInterval = 5f;
        }

        if (timer >= spawnInterval)
        {
            DestroySphere(); // Ensures the previous sphere is destroyed
            CreateSphere(); // Then creates a new sphere
        }
    }

    void CreateSphere()
    {
        timer = 0f;
        Vector3 randomPosition = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(1f, 2f), Random.Range(1f, 3f));
        currentSphere = Instantiate(spherePrefab, randomPosition, Quaternion.identity);
    }

    public void DestroySphere()
    {
        if (currentSphere != null)
        {
            Destroy(currentSphere);
            PlayDestructionSound();
        }
    }
    void PlayDestructionSound()
    {
        
        audioSource.PlayOneShot(destructionSound, 1.0f); // Play the sound clip
        Debug.LogWarning("Bubble pop sound played");
        
        
    }

   
}
