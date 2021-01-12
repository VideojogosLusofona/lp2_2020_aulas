using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private EnemyModel model = null;

    private void Awake()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = model.Sprite;
    }
}
