namespace Exercicio2
{
    /// <summary>
    /// Delegate that returns void and accepts a string. It's the same as
    /// using the predefined delegate Action&lt;string&gt;.
    /// </summary>
    /// <param name="str">
    /// String accepted by the methods compatible with this delegate.
    /// </param>
    public delegate void StringOp(string str);
}
