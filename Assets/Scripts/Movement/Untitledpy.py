

class Solution:
    def threeSumClosest(self, nums, target: int) -> int:
        nums.sort()
        j = 1
        result = 10000
   
        for i in range(len(nums) - 2):
            j = i +1
            k = len(nums) -1
            soma = 0
            while j < k:
                if abs(nums[i] + nums[j] + nums[k] - target) < abs(result - target):
                    print(nums[i], nums[j], nums[k])
                    result = abs(nums[i] + nums[j] + nums[k] - target)
                    soma = nums[i] + nums[j] + nums[k]
                   
                if  nums[i] + nums[j] + nums[k] < target:
                    j+=1
                else:
                    k -= 1
            return soma
      
      

a = Solution()
print(a.threeSumClosest([-1,2,1,-4], 1))
