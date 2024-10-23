using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float spawnInterval = 5f;
    public float destroyDelay = 3f;

    public Vector3 spawnRotation = new Vector3(-71.525f, 4.999f, -95.269f); // Rotation in Euler angles
    public Vector3 spawnScale = new Vector3(3f, 3f, 3f); // Scale

    private void Start()
    {
        StartCoroutine(SpawnAndDestroy());
    }

    private IEnumerator SpawnAndDestroy()
    {
        while (true)
        {
            // Generate a random X position
            float randomX = Random.Range(-14f, 12f);
            Vector3 spawnPosition = new Vector3(randomX, 10f, 0f);

            // Instantiate the object
            GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.Euler(spawnRotation));

            // Set the scale of the instantiated object
            spawnedObject.transform.localScale = spawnScale;

            // Destroy the object after a delay
            Destroy(spawnedObject, destroyDelay);

            // Wait for the specified interval before spawning the next object
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
