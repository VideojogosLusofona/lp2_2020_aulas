using System;

namespace Exercicio7
{
    [Flags]
    public enum Mood
    {
        Happy = 1 << 0,  // Equivalente a 1 (0001)
        Grumpy = 1 << 1, // Equivalente a 2 (0010)
        IgnoringYou = 1 << 2, // Equivalente a 4 (0100)
        HyperActive = 1 << 3, // Equivalente a 8 (1000)
    }
}
