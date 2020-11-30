using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    [Range(0, 100f)]
    private float xSeconds;

    private IEnumerable<Superpower> superpowers;

    private void Start()
    {
        superpowers = GetComponents<Superpower>();

        StartCoroutine(ActivateSuperpowers());
    }

    private IEnumerator ActivateSuperpowers()
    {
        while (true)
        {
            yield return new WaitForSeconds(xSeconds);
            Debug.Log($"~~~~~~~~~~~{gameObject.name}~~~~~~~~~~");
            foreach (Superpower sp in superpowers)
            {
                Debug.Log($"===> {sp.GetType().Name} <===");
                sp.Activate();
            }
        }
    }
}
