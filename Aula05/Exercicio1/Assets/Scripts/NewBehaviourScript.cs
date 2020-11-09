using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [Tooltip("I'm some value!!!!")]
    [Range(0, 500)]
    [SerializeField]
    private int someValue;
}
