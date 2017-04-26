// 
// 
public class Solution {
    class Item {
        public int Count {get; set;}
        public int Value {get; set;}
        
        public Item(int count, int value) {
            Count = count;
            Value = value;
        }
    }
    
    public IList<int> TopKFrequent(int[] nums, int k) {
        Dictionary<int, int> frMap = new Dictionary<int, int>();
        foreach(int num in nums) {
            if(frMap.ContainsKey(num)) {
                frMap[num] = frMap[num]+1;
            } else {
                frMap[num] = 1;
            }
        }
        
        Item[] list = new Item[k];
        
        int cnt = 0;
        foreach(var pair in frMap) {
            cnt++;
            if(cnt < k) {
                list[cnt -1] = new Item(pair.Value, pair.Key);
            } else if (cnt ==  k) {
                list[cnt -1] = new Item(pair.Value, pair.Key);
                Array.Sort(list, (item1, item2)=>item2.Count - item1.Count);
            } else {
                if(list[k-1].Count < pair.Value) {
                    list[k-1] = new Item(pair.Value, pair.Key);
                    for(int j=k-1; j>0; j--) {
                        if(list[j].Count > list[j-1].Count) {
                            Item temp = list[j];
                            list[j] = list[j-1];
                            list[j-1] = temp;
                        } else {
                            break;
                        }
                    }
                }
            }
        }
        
        List<int> rst = new List<int>(k);
        for(int i=0; i<k; i++) {
            rst.Add(list[i].Value);
        }
        return rst;
    }
}