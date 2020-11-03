using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercicio2 : MonoBehaviour
{
    private Coroutine hello;

    // Start is called before the first frame update
    private void Start()
    {
        hello = StartCoroutine(Hello(4));
        StartCoroutine(Counter(1, 30));
    }

    private IEnumerator Hello(int seconds)
    {
        WaitForSeconds wfs = new WaitForSeconds(seconds);
        while (true)
        {
            yield return wfs;
            Debug.Log("Hello");
        }
    }

    private IEnumerator Counter(int seconds, int stopHelloValue)
    {
        int counter = 0;
        WaitForSeconds wfs = new WaitForSeconds(seconds);
        while (true)
        {
            Debug.Log($"Counter = {counter}");
            if (counter > stopHelloValue)
            {
                StopCoroutine(hello);
            }
            counter++;
            yield return wfs;
        }
    }
}
