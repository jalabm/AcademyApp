using System;
using Academy.Core.Enums;
using Academy.Core.Models.BaseModels;

namespace Academy.Core.Models
{
	public class Student : BaseModel
	{
        static int _id;
        public string FullName { get; set; }
        public string Group { get; set; }
        public double Average { get; set; }
        public EducationCategory EducationCategory { get; set; }



        public Student(string fullName, string group, double average, EducationCategory educationCategory)
        {
            _id++;
 
            FullName = fullName;
            Group = group;
            Average = average;
            EducationCategory = educationCategory;
            string categoryName = EducationCategory.ToString();
            Id = $"{categoryName[0]}-{_id}";

        }
    }
}

