using System;

namespace AbiokaDDD.Infrastructure.Common
{
    public class Ensure
    {
        public static void IsNotNull(object parameter, string name) {
            if (parameter == null)
                throw new ArgumentNullException(name);
        }
    }
}
