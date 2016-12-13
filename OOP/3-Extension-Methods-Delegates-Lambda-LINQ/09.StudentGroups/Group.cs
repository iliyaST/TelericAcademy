using System;

namespace StudentGroups
{
    public class Group
    {
        public int GroupNumber { get; set; }
        public string DepartmentName { get; set; }

        /// <summary>
        /// Initializes new instance of group class to a specified group number and department name.
        /// </summary>
        /// <param name="groupNumber">Group number.</param>
        /// <param name="departmentName">Department name.</param>
        public Group(int groupNumber, string departmentName)
        {
            this.GroupNumber = groupNumber;
            this.DepartmentName = departmentName;
        }
    }
}
