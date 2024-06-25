using Ardalis.SmartEnum;
using WatchList.Core.Enums;

namespace WatchList.Core.Model.Load
{
    public class Grade : SmartEnum<Grade>
    {
        public static readonly Grade AnyGrade = new Grade("Any Grade", Grades.AnyGrade);
        public static readonly Grade One = new Grade("Great or equal 1", Grades.One);
        public static readonly Grade Two = new Grade("Great or equal 2", Grades.Two);
        public static readonly Grade Three = new Grade("Great or equal 3", Grades.Three);
        public static readonly Grade Four = new Grade("Great or equal 4", Grades.Four);
        public static readonly Grade Five = new Grade("Great or equal 5", Grades.Five);
        public static readonly Grade Six = new Grade("Great or equal 6", Grades.Six);
        public static readonly Grade Seven = new Grade("Great or equal 7", Grades.Seven);
        public static readonly Grade Eight = new Grade("Great or equal 8", Grades.Eight);
        public static readonly Grade Nine = new Grade("Great or equal 9", Grades.Nine);
        public static readonly Grade Ten = new Grade("Great or equal 10", Grades.Ten);

        public Grade(string name, Grades grade)
            : base(name, (int)grade)
        {
        }
    }
}
