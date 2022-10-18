### This problem will be implemented using two pointers algorithm.
#### It requires some steps to be ready to implement.

- we will store the index of numbers on a map.
- the key represents the number in the array and the value is a  Pair int , int  the first in pair is the index at the original array and the second in the index if this number repeated more than one time.
```
map<int,pair<int,int>>mp;
```
- Two Pointers algorithm needs a sorted array.
```
sort(nums.begin(), nums.end());
```
- Algorithm is ready to be implemented.
```
int start=0,end=nums.size()-1;
        while(start<end)
        {
            if(nums[start]+nums[end]==target)
            {
                if(nums[start]==nums[end])
                {
                    res.push_back(mp[nums[start]].first);
                    res.push_back(mp[nums[end]].second);
                    break;
                }
                else
                {
                    res.push_back(mp[nums[start]].first);
                    res.push_back(mp[nums[end]].first);
                    break;
                }
            }
            else if(nums[start]+nums[end]>target)
                end--;
            else start++;
        }
```
### Complexity.
- Time Complexity: O(nLOG(n)).
- Space Complexity: O(n).
