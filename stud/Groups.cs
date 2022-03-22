using System;
using System.Collections.Generic;
using System.Text;

namespace stud
{
    class Groups
    {
        int GroupName;
        List<double> GroupValues;

        public Groups()
        {}

        public void SetGroupName(int name)
        {
            GroupName = name;
        }

        public int GetGroupName()
        {
            return GroupName;
        }

        public void SetGroupValues(List<double> values)
        {
            GroupValues = values;
        }

        public List<double> GetGroupValues()
        {
            return GroupValues;
        }

    }
}
