using System;


namespace R5T.T0119
{
    /// <summary>
    /// Empty implementation as base for extension methods.
    /// </summary>
    public class ExpectedValue : IExpectedValue
    {
        #region Static
        
        public static ExpectedValue Instance { get; } = new();

        #endregion
    }
}