using System.Collections.Generic;

namespace Messaging.Tests.Utilities
{
    internal class MemberData
    {
        public static IEnumerable<object[]> NullOrWhiteSpace =>
            new List<object[]>
            {
                new object[] { null },
                new object[] { "" },
                new object[] { "  " }
            };
    }
}
