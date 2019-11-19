using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphReader.Classes
{
    public class Info
    {
        List<String> Title;
                
        List<Single> MaxList;
        List<Single> MinList;
        List<int> ColX;
        List<int> ColY;
        public Single Max;
        public Single Min;
        
        public Info()
        {
            Title = new List<string>();
            MaxList = new List<float>();
            MinList = new List<float>();
            ColX = new List<int>();
            ColY = new List<int>();
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
        public void Add(DataElement elementInfo)
        {
            Title.Add(elementInfo.Title);
            ColX.Add(elementInfo.xColumn);
            ColY.Add(elementInfo.yColumn);
            MinList.Add(elementInfo.Min);
            MaxList.Add(elementInfo.Max);            

            FindMax();
            FindMin();
        }
        public void Add(string title, int xCol, int yCol, float min, float max)
        {
            Title.Add(title);
            ColX.Add(xCol);
            ColY.Add(yCol);
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
            ColX.RemoveAt(t);
            ColY.RemoveAt(t);

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
            ColX.Clear();
            ColY.Clear();
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
        
        public int GetX(int k)
        {
            return ColX[k];
        }

        public int GetY(int k)
        {
            return ColY[k];
        }

        public int Number(string name)
        {
            int number = 0;
            for (int i = 0; i < Title.Count; i++)
            {
                if (name == Title[i])
                {
                    number = i;
                    break;
                }
            }
            return number;
        }
    }
}
