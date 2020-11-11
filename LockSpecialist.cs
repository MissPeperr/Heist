using System;

namespace adams_exercise
{
    public class LockSpecialist : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }

        public void PerformSkill(Bank Bank)
        {
            Console.WriteLine($"{Name} is cracking the vault. Decreased vault score by {SkillLevel} points.");
            if (Bank.VaultScore <= 0)
            {
                Console.WriteLine($"{Name} has cracked the vault!");
            }
            else
            {
                Bank.VaultScore = Bank.VaultScore - SkillLevel;
            }
        }
    }
}
