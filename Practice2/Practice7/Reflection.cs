using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using static Practice7.Student;

namespace Practice7
{
    public class Reflection
    {
        public static void Test()
        {
            Student student = new Student() { Class = 90 };
            Type typeOfStudent = student.GetType();
            Type typeOfStudent2 = typeof(Student);

            var allattrs = typeOfStudent.GetCustomAttributes();
            UniversityAttribute uniAttr = typeOfStudent.GetCustomAttribute(typeof(UniversityAttribute)) as UniversityAttribute;
            Console.WriteLine("Student Uni name is {0}", uniAttr.Name);

            PropertyInfo deptProp = typeOfStudent.GetProperty("Dept");

            var attrData = deptProp.GetCustomAttributesData();
            var appliedAtributes = from atd in attrData
                                   group atd by atd.AttributeType into attrGroup
                                   select new { attrGroup.Key, count = attrGroup.Count() };

            var appliedAtributes2 = attrData.GroupBy(x => x.AttributeType).Select(x => new { x.Key, count = x.Count() });
            var appliedAtributes3 = appliedAtributes2.Join(attrData, a => a.Key,
                                                       a1 => a1.AttributeType,
                                                       (a, a1) => new { a1.NamedArguments, a.Key, a.count });

            foreach (var item in appliedAtributes)
            {
                if (item.count > 1)
                {
                    IEnumerable<Attribute> attributes = deptProp.GetCustomAttributes(Type.GetType(item.Key.FullName));

                }
                else
                {
                    var attribute = deptProp.GetCustomAttribute(Type.GetType(item.Key.FullName));
                    Console.WriteLine(attribute.GetType().Name);
                }
            }
            
            // This will work throw exception if there are multiple attributes applied to a property. 
            var deptPropAttr = deptProp.GetCustomAttribute(Type.GetType("Practice7.Student+UniversityAttribute")) as UniversityAttribute;
            Console.WriteLine("Department Uni name is {0}", deptPropAttr.Name);

            IEnumerable<Attribute> deptPropAttrs = deptProp.GetCustomAttributes(Type.GetType("Practice7.Student+UniversityAttribute"));
            Console.WriteLine($"This department can be attended in {deptPropAttrs.Count()} universities.");
            foreach (var attr in deptPropAttrs)
            {
                Console.WriteLine("Department Uni name is {0}", ((UniversityAttribute)attr).Name);
            }

            PropertyInfo[] properties = typeOfStudent.GetProperties();
            foreach (var pi in properties)
            {
                Console.WriteLine(pi.Name);
            }

            PropertyInfo[] allProps = typeOfStudent.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            PropertyInfo[] allStaticProps = typeOfStudent.GetProperties(BindingFlags.Static);
            PropertyInfo[] allPublicProps = typeOfStudent.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            MethodInfo[] allMethods = typeOfStudent.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            MemberInfo[] allMembers = typeOfStudent.GetMembers(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            foreach (var member in allMembers)
            {
                Console.WriteLine($"{member.MemberType}\t{member.Name}");
            }

            PropertyInfo gradeProperty = typeOfStudent.GetProperty("Grade");
            MethodInfo[] fullNameAccessors = student.GetType().GetProperty("FullName").GetAccessors();

            MethodInfo gradeGetMethod = gradeProperty.GetGetMethod(true);
            var result = gradeGetMethod.Invoke(student, null);
            MethodInfo mi = typeOfStudent.GetMethod("ChangedGrade");
            var changedGrade = mi.Invoke(student, new object[] { 100, "StudentName"});
        }
    }

    [University("AUA")]
    public class Student
    {
        private string fullName;
        private int grade;
        public string FullName { get; }
        public int Class { get; set; }
        public int Grade { get; set; }
        public DaysOfWeek Lessons { get; set; }

        [University(Name = "YSU")]
        [University(Name = "RAU")]
        [Obsolete]
        public Department Dept { get; set; }

        public int ChangedGrade(int grade, string name)
        {
            this.Grade = grade;
            return grade;
        }

        public class Department
        {
            public string Name { get; set; }
        }

        //[Flags]
        //public enum DaysOfWeek
        //{
        //    Mon = 128,
        //    Tue = 64,
        //    Wed = 32,
        //    Thu = 16,
        //    Fri = 8,
        //    Sat = 4,
        //    Sun = 2
        //}

        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = true)]
        public class UniversityAttribute : Attribute
        {
            public string Name { get; set; }
            public UniversityAttribute()
            {

            }
            public UniversityAttribute(string name)
            {
                this.Name = name;
            }
        }
    }
}
