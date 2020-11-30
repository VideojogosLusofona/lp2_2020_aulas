using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{

    private IEnumerable<AnimalsAI> aIs;

    private IEnumerator TakeTurns()
    {
        YieldInstruction wfs = new WaitForSeconds(2);

        while (true)
        {
            foreach (AnimalsAI ai in aIs)
            {
                ai.TakeTurn();
            }
            yield return wfs;
        }
    }

    private void Awake()
    {
        aIs = new List<AnimalsAI>() { new SheepAI(), new WolvesAI() };
    }

    private void Start()
    {
        StartCoroutine(TakeTurns());
    }
}
