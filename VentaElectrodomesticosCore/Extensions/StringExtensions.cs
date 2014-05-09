namespace System
{
    /// <summary>
    /// Method extensions de la clase String.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Retorna un valor nulo si la string esta vacia.
        /// </summary>
        /// <param name="str">String a evaluar.</param>
        /// <returns>String no vacia o nula.</returns>
        public static string GetNullIfEmpty(this string str)
        {
            if (String.IsNullOrEmpty(str))
                return null;

            return str;
        }

        /// <summary>
        /// Retorna una string vacia si el valor es nulo.
        /// </summary>
        /// <param name="str">String a evaluar.</param>
        /// <returns>String no nula.</returns>
        public static string GetEmptyIfNull(this string str)
        {
            if (String.IsNullOrEmpty(str))
                return String.Empty;

            return str;
        }

        /// <summary>
        /// Parsea una una string como un valor entero.
        /// </summary>
        /// <param name="str">String a evaluar.</param>
        /// <returns>Valor entero resultado del parseo.</returns>
        public static int IntParse(this string str)
        {
            int value;
            Int32.TryParse(str, out value);
            return value;
        }

        /// <summary>
        /// Parsea una una string como un valor entero.
        /// </summary>
        /// <param name="str">String a evaluar.</param>
        /// <returns>Valor entero resultado del parseo, o null si falla.</returns>
        public static int? NullableIntParse(this string str)
        {
            int value;
            if (Int32.TryParse(str, out value))
                return value;

            return null;
        }

        /// <summary>
        /// Parsea una una string como un valor double.
        /// </summary>
        /// <param name="str">String a evaluar.</param>
        /// <returns>Valor double resultado del parseo.</returns>
        public static double DoubleParse(this string str)
        {
            double value;
            Double.TryParse(str, out value);
            return value;
        }

        /// <summary>
        /// Parsea una una string como un valor double.
        /// </summary>
        /// <param name="str">String a evaluar.</param>
        /// <returns>Valor double resultado del parseo, o null si falla.</returns>
        public static double? NullableDoubleParse(this string str)
        {
            double value;
            if (Double.TryParse(str, out value))
                return value;

            return null;
        }

        /// <summary>
        /// Retorna el SHA256 de una string.
        /// </summary>
        /// <param name="str">String a evaluar.</param>
        /// <returns>Retorna el hash de la string.</returns>
        public static string ComputeHash(this string str)
        {
            var input = System.Text.Encoding.UTF8.GetBytes(str);
            using (var algorithm = System.Security.Cryptography.SHA256CryptoServiceProvider.Create())
            {
                var hashedBytes = algorithm.ComputeHash(input);
                return BitConverter.ToString(hashedBytes);
            }
        }
    }
}
