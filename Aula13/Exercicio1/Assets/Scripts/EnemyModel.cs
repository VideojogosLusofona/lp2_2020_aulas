using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyModel")]
public class EnemyModel : ScriptableObject
{
    [SerializeField]
    private Sprite sprite = null;

    public Sprite Sprite => sprite;
}
