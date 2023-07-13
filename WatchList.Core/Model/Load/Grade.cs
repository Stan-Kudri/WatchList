using Ardalis.SmartEnum;

namespace WatchList.Core.Model.Load
{
    public class Grade : SmartEnum<Grade>
    {
        public static readonly Grade AnyGrade = new Grade("Any Grade", 0);
        public static readonly Grade One = new Grade("Great or equal 1", 1);
        public static readonly Grade Two = new Grade("Great or equal 2", 2);
        public static readonly Grade Three = new Grade("Great or equal 3", 3);
        public static readonly Grade Four = new Grade("Great or equal 4", 4);
        public static readonly Grade Five = new Grade("Great or equal 5", 5);
        public static readonly Grade Six = new Grade("Great or equal 6", 6);
        public static readonly Grade Seven = new Grade("Great or equal 7", 7);
        public static readonly Grade Eight = new Grade("Great or equal 8", 8);
        public static readonly Grade Nine = new Grade("Great or equal 9", 9);
        public static readonly Grade Ten = new Grade("Great or equal 10", 10);

        public Grade(string name, int value)
            : base(name, value)
        {
        }
    }
}
