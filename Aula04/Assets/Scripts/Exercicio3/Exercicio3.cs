using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercicio3 : MonoBehaviour
{
    private Coroutine hello;

    // Start is called before the first frame update
    private void Start()
    {
        hello = StartCoroutine(Hello(4));
        StartCoroutine(Counter(1, 30));
        StartCoroutine(BeingPressed());
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

    private IEnumerator BeingPressed()
    {
        CustomYieldInstruction waitForPress = new WaitForPress();
        while (true)
        {
            yield return waitForPress;
            Debug.Log("Estou a ser pressionado!! Larga-me!!");
        }
    }

}
