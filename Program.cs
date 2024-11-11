namespace MajorityElement2
{
    internal class Program
    {
        //Given an array of N integers, write a program to return an element that occurs
        //more than N/3 times in the given array.
        //You may consider that such an element always exists in the array.
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        static IList<int> MajorityElementBrute(int[] nums)
        {
            int n = nums.Length;
            List<int> ans = new List<int>();
            for (int i = 0; i < n; i++)
            {

                if (ans.Count == 0 || !ans.Contains(nums[i]))
                {
                    int count = 0;
                    for (int j = 0; j < n; j++)
                    {
                        if (nums[i] == nums[j])
                        {
                            count++;
                        }
                    }
                    if (count > n / 3)
                    {
                        ans.Add(nums[i]);
                    }
                }
                
                //It is not theoretically possible to have more than two elements that appear more than n/3 times in an array of size n
                if (ans.Count == 2)
                {
                    break;
                }
            }
            return ans;

        }

        static IList<int> MajorityElementBetter(int[] nums)
        {
            int n = nums.Length;
            List<int> ans = new List<int>();
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int min = n / 3 + 1;
            for (int i = 0; i < n; i++)
            {
                if (dict.ContainsKey(nums[i]))
                {
                    dict[nums[i]] += 1;
                }
                else
                {
                    dict.Add(nums[i], 1);
                }

                if (dict[nums[i]] == min)
                {
                    ans.Add(nums[i]);
                }
            }

            //foreach (var d in dict)
            //{
            //    if (d.Value > n / 3)
            //    {
            //        ans.Add(d.Key);
            //    }
            //}

            return ans;
        }

        //Boyer-Moore Voting Algorithm 
        static IList<int> MajorityElementOptimal(int[] nums)
        {
            int n = nums.Length;
            int min = n / 3 + 1;
            List<int> ans = new List<int>();

            int el1 = 0, el2 = 0, count1 = 0, count2 = 0;

            for (int i = 0; i < n; i++)
            {
                if (count1 == 0 && nums[i] != el2)
                {
                    count1++;
                    el1 = nums[i];
                }
                else if (count2 == 0 && nums[i] != el1)
                {
                    count2++;
                    el2 = nums[i];
                }
                else if (nums[i] == el1)
                {
                    count1++;
                }
                else if (nums[i] == el2)
                {
                    count2++;
                }
                else
                {
                    count1--;
                    count2--;
                }
            }

            count1 = 0;
            count2 = 0;
            for (int i = 0; i < n; i++)
            {
                if (nums[i] == el1)
                {
                    count1++;
                }
                if (nums[i] == el2)
                {
                    count2++;
                }
            }

            if (count1 > n / 3)
            {
                ans.Add(el1);
            }

            if (count2 > n / 3 && el2 != el1)
            {
                ans.Add(el2);
            }
            return ans;
        }
    }

    }
}
