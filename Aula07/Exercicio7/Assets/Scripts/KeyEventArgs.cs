using System;

public class KeyEventArgs : EventArgs
{
    public char Key { get; }

    public KeyEventArgs(char key)
    {
        Key = key;
    }
}
