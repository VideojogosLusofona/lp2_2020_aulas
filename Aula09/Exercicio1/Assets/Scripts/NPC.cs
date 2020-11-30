using UnityEngine;

public class NPC : MonoBehaviour
{
    private IAnimateBehaviour behaviour;

    private void Awake()
    {
        behaviour = GetComponent<IAnimateBehaviour>();
    }

    // Update is called once per frame
    private void Update()
    {
        behaviour.Animate();
    }
}
