using System;
using System.Collections.Generic;
using System.Text;

namespace MordorsCruelPlan.Mood
{
    public class Mood
    {
        public Mood(string mood)
        {
            this.MoodName = mood;
        }

        public string MoodName { get; private set; }
    }
}
