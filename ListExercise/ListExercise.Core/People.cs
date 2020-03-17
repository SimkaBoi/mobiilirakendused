using System;
using System.Collections.Generic;

namespace ListExercise.Core
{
    public partial class People
    {
        public long Count { get; set; }
        public object Next { get; set; }
        public object Previous { get; set; }
        public List<PeopleDetails> Results { get; set; }
    }

    public partial class PeopleDetails
    {
        public string Name { get; set; }
        public long Height { get; set; }
        public long Mass { get; set; }
        public string HairColor { get; set; }
        public string SkinColor { get; set; }
        public string EyeColor { get; set; }
        public string BirthYear { get; set; }
        public string Gender { get; set; }
    }
}
