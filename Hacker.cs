using System;

namespace adams_exercise
{
    public class Hacker : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }

        public void PerformSkill(Bank Bank)
        {
            Console.WriteLine($"{Name} is taking out the alarms. Decreased Alarm score by {SkillLevel} points.");
            if (Bank.AlarmScore <= 0)
            {
                Console.WriteLine($"{Name} has taken out all of the Alarms!");
            }
            else
            {
                Bank.AlarmScore = Bank.AlarmScore - SkillLevel;
            }
        }
    }
}
