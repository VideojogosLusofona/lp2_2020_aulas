using UnityEngine;

public class RotateBehaviour : MonoBehaviour, IAnimateBehaviour
{
    // Update is called once per frame
    public void Animate()
    {
        transform.Rotate(0.2f, 0.2f, 0.2f);
    }
}
