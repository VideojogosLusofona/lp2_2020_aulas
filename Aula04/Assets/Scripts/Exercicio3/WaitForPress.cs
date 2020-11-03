using UnityEngine;

public class WaitForPress : CustomYieldInstruction
{
    public override bool keepWaiting => !Input.anyKey;
}