
public class Solution
{
    public int MaxVowels(string s, int k)
    {
        int current = 0;

        for (int i = 0; i < k; i++)
        {
            if (IsVowel(s[i]))
                current++;
        }

        int maximum = current;

        for (int i = k; i < s.Length; i++)
        {
            if (IsVowel(s[i - k]))
                current--;

            if (IsVowel(s[i]))
                current++;

            maximum = Math.Max(maximum, current);
        }

        return maximum;
    }

    private bool IsVowel(char c)
    {
        return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
    }
}
