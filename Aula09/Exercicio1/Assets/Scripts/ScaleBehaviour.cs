using UnityEngine;

public class ScaleBehaviour : MonoBehaviour, IAnimateBehaviour
{
    private Vector3 minScale = new Vector3(0.1f, 0.1f, 0.1f);
    private float angle = 0.0f;

    public void Animate()
    {
        transform.localScale =
            minScale + Mathf.Abs(Mathf.Cos(angle)) * Vector3.one;
        angle += 0.01f;
    }
}
