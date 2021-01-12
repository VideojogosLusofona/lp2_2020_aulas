using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LevelSpec")]
public class LevelSpec : ScriptableObject
{
    [SerializeField]
    private Vector2[] enemySpawnPoints = null;

    [SerializeField]
    private Color bgColor = default;

    public IEnumerable<Vector2> EnemySpawnPoints => enemySpawnPoints;

    public Color BgColor => bgColor;
}
