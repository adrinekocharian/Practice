using System;
using System.Collections.Generic;
using System.Text;

namespace Practice7
{
    [Flags]
    public enum DaysOfWeek
    {
        Mon = 128, 
        Tue = 64,
        Wed = 32,
        Thu = 16,
        Fri = 8,
        Sat = 4,
        Sun = 2
    }

    // 2 4 8 16 32 64 128
    // MTWTFSS
    // 0000000
    // 1010100   168
    // 1000000 - 128
    // 0010000 - 32
    // 0000100 - 8

    public class Lesson
    {
        public DaysOfWeek LessonDays { get; set; }
        public Lesson()
        {
            LessonDays = DaysOfWeek.Mon | DaysOfWeek.Wed | DaysOfWeek.Fri;
        }
    }
}
