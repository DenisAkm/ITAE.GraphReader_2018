using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphReader.Classes
{
    class Info
    {
        List<String> Title;
                
        List<Single> MaxList;
        List<Single> MinList;

        public Single Max;
        public Single Min;

        public Info()
        {
            Title = new List<string>();
            MaxList = new List<float>();
            MinList = new List<float>();            
        }
        //private void AddMedian(String title, Single start, Single finish, Single step)
        //{
        //    Title.Add(title + "_median");
        //    StartList.Add(start);
        //    FinishList.Add(finish);
        //    StepList.Add(step);
        //}
        //private void AddMiddle(String title, Single start, Single finish, Single step)
        //{
        //    Title.Add(title + "_middle");
        //    StartList.Add(start);
        //    FinishList.Add(finish);
        //    StepList.Add(step);
        //}
        public void Add(String title, Single min, Single max)
        {
            Title.Add(title);            

            MinList.Add(min);
            MaxList.Add(max);            

            FindMax();
            FindMin();
        }
        public void FindMax()
        {            
            if (!(Title.Count == 0))
            {
                Max = MaxList[0];
                for (int i = 0; i < Title.Count; i++)
                {                    
                    if (Max < MaxList[i])
                    {
                        Max = MaxList[i];
                    }
                }    
            }    
        }
        public void FindMin()
        {
            
            if (!(Title.Count == 0))
            {
                Min = MinList[0];
                for (int i = 0; i < Title.Count; i++)
                {
                    if (Min > MinList[i])
                    {
                        Min = MinList[i];
                    }
                }
            }
            else
            {
                Min = 0;
            }            
        }
        public void Remove(String removeName)
        {
            int t = Title.IndexOf(removeName);
            Title.RemoveAt(t);
            MinList.RemoveAt(t);
            MaxList.RemoveAt(t);

            FindMax();
            FindMin();
        }

        public void Clear()
        {
            Title.Clear();
            MaxList.Clear();
            MinList.Clear();
            Max = new float();
            Min = new float();
        }

        public bool Exist(string name)
        {
            bool answer = false;
            for (int i = 0; i < Title.Count; i++)
            {
                if (name == Title[i])
                {
                    answer = true;
                }
            }
            return answer;
        }
    }
}
