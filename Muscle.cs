using System;

namespace adams_exercise
{
    public class Muscle : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }

        public void PerformSkill(Bank Bank)
        {
            Console.WriteLine($"{Name} is taking out the Security Guards. Decreased Guard score by {SkillLevel} points.");
            if (Bank.SecurityGuardScore <= 0)
            {
                Console.WriteLine($"{Name} has taken out all of the Security Guards!");
            }
            else
            {
                Bank.SecurityGuardScore = Bank.SecurityGuardScore - SkillLevel;
            }
        }
    }
}
