using System;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using R5T.T0119;


namespace System
{
    public static class IAssertionExtensions
    {
        public static async Task ThrowsExceptionAsync<TException>(this IAssertion _,
            Func<Task> action)
            where TException : Exception
        {
            await Assert.ThrowsExceptionAsync<TException>(action);
        }
    }
}