using UnityEditor.MPE;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector2 speedRange;
    [SerializeField] private Asteroid asteroidPrefab;
    [SerializeField] private float timeBetweenSpawn;
    [SerializeField] private int asteroidHealth;

    private bool isSpawning = false;
    private float spawnTimer;

    private void Start()
    {
        StartSpawning();
    }

    private void Update()
    {
        if (target == null)
        {
            isSpawning = false;
        }

        if (!isSpawning)
            return;

        if (spawnTimer >= timeBetweenSpawn)
        {
            Spawn();
            spawnTimer = 0f;
        }
        spawnTimer += Time.deltaTime;
    }

    private void StartSpawning()
    {
        isSpawning = true;
    }

    private Vector3 GetSpawnPoint()
    {
        float randomX = Random.Range(-transform.lossyScale.x / 2, transform.lossyScale.x / 2);
        float randomY = Random.Range(-transform.lossyScale.y / 2, transform.lossyScale.y / 2);
        float randomZ = Random.Range(-transform.lossyScale.z / 2, transform.lossyScale.z / 2);
        return transform.position + new Vector3(randomX, randomY, randomZ);
    }

    private void Spawn()
    {
        // Instantiate the asteroid
        Asteroid asteroid = Instantiate(asteroidPrefab);

        // Set a random spawn point based on the spawn area
        asteroid.transform.position = GetSpawnPoint();

        // Set a random speed based on the direction to the target
        Vector3 directionToTarget = (target.position - asteroid.transform.position).normalized;
        Vector3 speed = directionToTarget * Random.Range(speedRange.x, speedRange.y);
        asteroid.Init(speed,asteroidHealth);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(transform.position, transform.lossyScale);
    }
}
