using System;

    public static class ValidationHelpers
    {
        public static void ValidatePositiveInt(string value, string FieldName)
        {
            int i;
            if (!int.TryParse(value,out i)) 
                throw new ArgumentException("The value must be a valid integer", FieldName);

            if (int.Parse(value) <=0)
                throw new ArgumentException("The value must be positive", FieldName);
        }

        public static void IntGreaterOrEqual(int value, int Floor, string FieldName)
        {
            if (value < Floor) 
                throw new ArgumentException(string.Format("The value must be at least {0}",Floor), FieldName);
        }

        public static void IntInRange(int value, int Floor,int Ceiling, string FieldName)
        {
            if (value < Floor || value > Ceiling) 
                throw new ArgumentException(string.Format("The value must be at least {0} and no more than {1}", Floor,Ceiling), FieldName);
        }
    }

