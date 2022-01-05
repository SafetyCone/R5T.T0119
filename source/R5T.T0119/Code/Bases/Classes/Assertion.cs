using System;


namespace R5T.T0119
{
    /// <summary>
    /// Empty implementation as base for extension methods.
    /// </summary>
    public class Assertion : IAssertion
    {
        #region Static
        
        public static Assertion Instance { get; } = new();

        #endregion
    }
}