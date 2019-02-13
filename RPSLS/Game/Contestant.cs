using System;

namespace RPSLS
{
    class Contestant : IComparable<Contestant>
    {
        public Type AI { get; set; }
        public string Nickname { get; set; }
        public string Author { get; set; }
        public int WinCount { get; set; }
        public Section CourseSection { get; set; }

        public Contestant(Type ai, string nickname, string author, Section courseSection)
        {
            AI = ai;
            Nickname = nickname;
            Author = author;
            CourseSection = courseSection;
        }

        public override string ToString()
        {
            return $"{Nickname} ({Author}) has {WinCount} wins.";
        }

        public int CompareTo(Contestant other)
        {
            return -WinCount.CompareTo(other.WinCount);
        }
    }
}
