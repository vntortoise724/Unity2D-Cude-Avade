using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject catchEnemyPrefab;

    [SerializeField] private float spawnInterval;
    [SerializeField] private Vector2 spawnPosRangeX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(KwaiSpawn), 0f, spawnInterval);
        InvokeRepeating(nameof(KwquaSpawn), 1f, spawnInterval);
    }

    private void KwaiSpawn()
    {
        EnemySpawn(EnemyType.Kwai);
    }

    private void KwquaSpawn()
    {
        EnemySpawn(EnemyType.Kwqua);
    }

    private void EnemySpawn(EnemyType enemyType)
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range (spawnPosRangeX[0], spawnPosRangeX[1]), 
            enemyPrefab.transform.position.y, 
            enemyPrefab.transform.position.z);

        if (enemyType == EnemyType.Kwai)
            Instantiate(enemyPrefab, spawnPosition, enemyPrefab.transform.rotation);
        else
            Instantiate(catchEnemyPrefab, spawnPosition, catchEnemyPrefab.transform.rotation);
    }
}
