using System;


namespace R5T.T0119
{
    /// <summary>
    /// Empty implementation as base for extension methods.
    /// </summary>
    public class Expectation : IExpectation
    {
        #region Static
        
        public static Expectation Instance { get; } = new();

        #endregion
    }
}