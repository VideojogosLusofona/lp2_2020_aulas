using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab = null;
    
    [SerializeField]
    private LevelSpec levelSpec = null;

    private void Awake()
    {
        Camera.main.backgroundColor = levelSpec.BgColor;
        
        foreach (Vector2 pos in levelSpec.EnemySpawnPoints)
        {
            Instantiate(enemyPrefab, pos, Quaternion.identity);
        }
    }
}
