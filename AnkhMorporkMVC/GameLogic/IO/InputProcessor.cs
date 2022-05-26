using System;

namespace AnkhMorporkMVC.GameLogic.IO
{
    public class InputProcessor
    {
        internal static bool Is(Type typeToValidate, string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;

            if (typeToValidate == typeof(string))
                return true;

            var temp = Activator.CreateInstance(typeToValidate);
            var method = typeToValidate.GetMethod("TryParse",
                new[]
                {
                    typeof (string),
                    Type.GetType($"{typeToValidate.FullName}&")
                }
            );

            var result = method.Invoke(null, new object[] { input, temp });
            if (result == null) { return false; }
            return (bool)result;
        }

        public static bool ValidInput(string input, Type typeToValidate, Func<object, bool> check = null)
        {
            if (check == null)
                return Is(typeToValidate, input);
            return Is(typeToValidate, input) && check(input);
        }
    }
}