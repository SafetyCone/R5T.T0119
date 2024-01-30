using System;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using R5T.T0119;


namespace System
{
    [Obsolete("Use R5T.F0101")]
    public static class IAssertionExtensions
    {
        public static void AreEqual<T>(this IAssertion _,
            T actual,
            T expected)
        {
            Assert.AreEqual(expected, actual);
        }

        public static void AreEqual_ForArray<T>(this IAssertion _,
            T[] actual,
            T[] expected)
        {
            CollectionAssert.AreEqual(actual, expected);
        }

        /// <summary>
        /// Allows explicitly stating that an action should not thrown an exception.
        /// With MSTest, if code throws an exception the test will fail. However, relying on this behavior means that test code will lack an assertion, which makes these test look different from all other tests.
        /// This method allows a conforming assertion to be made in the case of testing for no exceptions.
        /// </summary>
        /// <remarks>
        /// From: https://stackoverflow.com/a/9417242
        /// </remarks>
        public static async Task DoesNotThrowExceptionAsync(this IAssertion _,
            Func<Task> action)
        {
            try
            {
                await action();
            }
            catch (Exception exception)
            {
                Assert.Fail($"Expected no exception, found:\n{exception.Message}");
            }
        }

        public static void IsNull(this IAssertion _,
            object value)
        {
            Assert.IsNull(value);
        }

        public static void ThrowsException<TException>(this IAssertion _,
            Action action)
            where TException : Exception
        {
            Assert.ThrowsException<TException>(action);
        }

        public static void ThrowsException<TException>(this IAssertion _,
            Action action,
            string expectedMessageOfException)
            where TException : Exception
        {
            var exceptionWasThrown = false;
            var exceptionMessageWasAsExpected = false;

            try
            {
                action();
            }
            catch (TException ex)
            {
                exceptionWasThrown = true;

                exceptionMessageWasAsExpected = ex.Message == expectedMessageOfException;
            }

            if (!exceptionWasThrown)
            {
                Assert.Fail($"Expected an exception, but no exception occurred.");
            }

            if (!exceptionMessageWasAsExpected)
            {
                Assert.Fail($"Exception message was not as expected.\nExpected:{expectedMessageOfException}");
            }
        }

        public static async Task ThrowsExceptionAsync(this IAssertion _,
            Func<Task> action)
        {
            var exceptionWasThrown = false;
            try
            {
                await action();
            }
            catch
            {
                exceptionWasThrown = true;
            }

            if(!exceptionWasThrown)
            {
                Assert.Fail($"Expected an exception, but no exception occurred.");
            }
        }

        public static async Task ThrowsExceptionAsync<TException>(this IAssertion _,
            Func<Task> action)
            where TException : Exception
        {
            await Assert.ThrowsExceptionAsync<TException>(action);
        }
    }
}