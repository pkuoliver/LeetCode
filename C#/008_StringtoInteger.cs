// Runtime	: 119 ms
// Beats	: 68.77%

public class Solution {
    public int MyAtoi(string str) {
        if(string.IsNullOrEmpty(str)) return 0;
        
        char[] chars = str.Trim().ToArray();
        if(chars == null || chars.Length == 0) return 0;
        
        int result = 0, flag = 1, start = 0;
        if(chars[0] == '-') {
            flag = -1;
            start = 1;
        } else if (chars[0] == '+') {
            flag = 1;
            start = 1;
        }
        
        for(int i=start; i<chars.Length; i++) {
            if(chars[i] <= '9' && chars[i] >= '0') {
                
                // max int value
                if(flag == 1 && ((result * 10 + chars[i] - '0' < 0) || (result != result * 10 /10))) {
                    return Int32.MaxValue;
                }
                
                // min int value
                if(flag == -1 && ((-1 * (result * 10 + chars[i] - '0') > 0) || (result != result * 10 /10))) {
                    return Int32.MinValue;
                }
                result = result * 10 + chars[i] - '0';
            } else {
                break;
            }
        }
        return result * flag;
    }
}