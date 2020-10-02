/*
 * @Author: rrr@burntsugar.rocks 
 * @Date: 2020-10-02 19:39:35 
 * @Last Modified by:   rrr@burntsugar.rocks 
 * @Last Modified time: 2020-10-02 19:39:35 
 */
using System;

public class Utils
{

    public static string EX_STRING_NULL = "String is null";
    public static string EX_STRING_BREACH_MIN = "String is too short";
    public static string EX_STRING_BREACH_MAX = "String is too long";

    public static bool validateLength(string s, int maxLen)
    {
        return validateLength(s, 0, maxLen);
    }
    public static bool validateLength(string s, int minLen, int maxLen)
    {
        if (s == null) throw new Exception(EX_STRING_NULL);
        if (s.Length < minLen) throw new Exception($"{EX_STRING_BREACH_MIN} Given: {s.Length} Required: {minLen}");
        if (s.Length > maxLen) throw new Exception($"{EX_STRING_BREACH_MAX} Given: {s.Length} Required: {maxLen}");
        return true;
    }

}