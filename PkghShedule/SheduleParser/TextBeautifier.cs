namespace SheduleParser
{
    internal static class TextBeautifier
    {
        public static string Beauty(string inputData)
        {
            inputData = inputData.Replace("\r", "");

            for (int i = 0; i < inputData.Length; i++)
            {
                if (i == inputData.Length - 1) break;

                if (inputData[i] == '\n' && (inputData[i + 1] == '\n' || inputData[i + 1] == ' '))
                {
                    inputData = inputData.Remove(i, 1);
                }
            }

            return inputData;
        }
    }
}
