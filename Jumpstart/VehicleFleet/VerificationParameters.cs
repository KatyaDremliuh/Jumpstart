using System;

namespace Jumpstart.VehicleFleet
{
    public class VerificationParameters
    {
        public static bool IsDefault(string key)
        {
            return key.Equals("D", StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool IsValidLength(string vehicleType)
        {
            return vehicleType.Trim().Length == 1;
        }

        public static bool IsValidName(string name)
        {
            return name.Trim().Length >= 2 && name.Trim().Length <= 30;
        }

        public static bool IsValidNumber(byte value, byte min, byte max)
        {
            return value >= min && value <= max;
        }

        public static bool IsValidNumber(ushort value, ushort min, ushort max)
        {
            return value >= min && value <= max;
        }

        public static bool IsValidNumber(double value, double min, double max)
        {
            return value >= min && value <= max;
        }

        public static string[] IsValidParameterToFindAuto(string input, out bool valid)
        {
            string[] goodQuery = { "capacity", "trucks&buses", "transmission", };
            string[] parts = input.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            switch (parts.Length)
            {
                case 1 when (string.Equals(parts[0], goodQuery[1]) || string.Equals(parts[0], goodQuery[2])):
                    valid = true;
                    return parts;
                case 2 when double.TryParse(parts[1], out double _):
                    valid = true;
                    return parts;
                default:
                    valid = false;
                    return Array.Empty<string>();
            }
        }
    }

    class GetAutoByParameterException : ArgumentException
    {
        public string Value { get; }
        public string ExMessage = "Error! It is impossible to find the car model by the specified parameter.";

        public GetAutoByParameterException(string message, string value) : base(message)
        {
            Value = value;
        }
    }

    public class UpdateAutoException : Exception
    {
        public int Value { get; }

        public UpdateAutoException()
        {
        }

        public UpdateAutoException(string message, int value) : base(message)
        {
            Value = value;
        }

        public UpdateAutoException(string message, Exception inner) : base(message, inner)
        {
        }
    }

    public class RemoveAutoException : ArgumentException
    {
        public string Value { get; }

        public RemoveAutoException() { }

        public RemoveAutoException(string message, string value) : base(message)
        {
            Value = value;
        }
    }

    public class AddException : Exception
    {
        public string Value { get; }

        public string ExMessage = "It failed to add car. Engine Vin number ought to be unique.";

        public AddException() { }

        public AddException(string message, string value) : base(message)
        {
            Value = value;
        }
    }

    public class InitializationException : Exception
    {
        public string Value { get; }

        public InitializationException(string message, string value) : base(message)
        {
            Value = value;
        }
    }
}