// Runtime	: 112 ms
// Beats	: 98.59%

public class Solution {
    private int IndexOf(char[] chars, int start, int end, char c) {
        for(int i=start; i<=end; i++) {
            if(c == chars[i]) {
                return i;
            }
        }
        return -1;
    }
    
    public int LengthOfLongestSubstring(string s) {
        int maxCnt = 0, start = 0, end = 0;
        char[] chars = s.ToArray();
        if(chars.Length < 2) return chars.Length;
        
        for(int i=1; i<chars.Length; i++) {
            int index = IndexOf(chars, start, end, chars[i]);
            if(index != -1) {
                if(end - start + 1 > maxCnt) 
                    maxCnt = end - start + 1;
                start = index + 1;
                end = i;
            } else {
                end++;
            }
        }
        
        return end - start + 1 > maxCnt ? end - start + 1 : maxCnt;
    }
}