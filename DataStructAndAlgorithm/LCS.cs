public static int LongestCommonSubstring(string str1, string str2, out string subStr)
{
    subStr = string.Empty;

    if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2))
    {
        return 0;
    }

    int[,] matrix = new int[str1.Length, str2.Length];
    int maxLen = 0;
    int lastSubsBegin = 0;
    StringBuilder subStrBuilder = new StringBuilder();

    for (int i = 0; i < str1.Length; i++)
    {
        for (int j = 0; j < str2.Length; j++)
        {
            if (str1[i] != str2[j])
            {
                matrix[i, j] = 0;
            }
            else
            {
                if ((i == 0) || (j == 0))
                {
                    matrix[i, j] = 1;
                }
                else
                {
                    matrix[i, j] = 1 + matrix[i - 1, j - 1];
                }

                if (matrix[i, j] > maxLen)
                {
                    maxLen = matrix[i, j];

                    int thisSubsBegin = i - matrix[i, j] + 1;

                    if (lastSubsBegin == thisSubsBegin)
                    {
                        subStrBuilder.Append(str1[i]);
                    }
                    else
                    {
                        lastSubsBegin = thisSubsBegin;
                        subStrBuilder.Length = 0;
                        subStrBuilder.Append(str1.Substring(lastSubsBegin, (i + 1) - lastSubsBegin));
                    }
                }
            }
        }
    }

    subStr = subStrBuilder.ToString();

    return maxLen;
}