// 
// 
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    private int GetListLength(ref ListNode list) {
        if(list == null) return 0;
        int len = 1;
        ListNode p = list;
        while(p.next != null) {
            len++;
            p = p.next;
        }
        return len;
    }
    
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        int len1 = GetListLength(ref l1);
        int len2 = GetListLength(ref l2);
        
        ListNode longList, shortList;
        int max, min;
        if(len1 > len2) {
            longList = l1;
            shortList = l2;
            max = len1;
            min = len2;
        } else {
            longList = l2;
            shortList = l1;
            max = len2;
            min = len1;
        }
        
        ListNode list = null, p = null, node;
        int plus = 0;
        for(int i=0; i<max; i++) {
            if(i < min) {
                int val = (longList.val + shortList.val + plus);
                node = new ListNode(val % 10);
                plus = val / 10;
                longList = longList.next;
                shortList = shortList.next;
            } else {
                int val = (longList.val + plus);
                node = new ListNode(val % 10);
                plus = val / 10;
                longList = longList.next;
            }
            
            if(p == null) {
                list = node;
                p = node;
            } else {
                p.next = node;
                p = p.next;
            }
        }
        if(plus > 0) {
            node = new ListNode(plus);
            p.next = node;
        }
        return list;
    }
}