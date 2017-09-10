using System;

namespace _10.The_Heigan_Dance
{
    public class HeiganDance
    {
        private const int ChamberSize = 15;
        private const int CloudDamage = 3500;
        private const int EruptionDamage = 6000;
        private const double PlayerStartingHealth = 18500;
        private const double HaigenStartingHealth = 3000000;

        public static void Main()
        {
            var playerPos = new int[] {ChamberSize / 2, ChamberSize / 2};
            var heiganHealth = HaigenStartingHealth;
            var playerHealth = PlayerStartingHealth;
            var isHeiganDead = false;
            var isPlayerDead = false;
            var hasCloud = false;
            var deathSpell = string.Empty;

            var damageToHaigen = double.Parse(Console.ReadLine());

            while (true)
            {
                var spellTokens = Console.ReadLine().Split();
                var spell = spellTokens[0];
                var spellRow = int.Parse(spellTokens[1]);
                var spellCol = int.Parse(spellTokens[2]);

                heiganHealth -= damageToHaigen;
                isHeiganDead = heiganHealth <= 0;

                if (hasCloud)
                {
                    playerHealth -= CloudDamage;
                    hasCloud = false;
                    isPlayerDead = playerHealth <= 0;
                }

                if (isHeiganDead || isPlayerDead)
                {
                    break;
                }

                if (IsPlayerInImpactZone(playerPos, spellRow, spellCol))
                {
                    if (!PlayerTriesToEscape(playerPos, spellRow, spellCol))
                    {
                        switch (spell)
                        {
                            case "Cloud":
                                playerHealth -= CloudDamage;
                                hasCloud = true;
                                deathSpell = "Plague Cloud";
                                break;
                            case "Eruption":
                                playerHealth -= EruptionDamage;
                                deathSpell = spell;
                                break;
                            default:
                                break;
                        }
                    }
                }

                isPlayerDead = playerHealth <= 0;
                if (isPlayerDead)
                {
                    break;
                }
            }

            PrintResult(playerPos, heiganHealth, playerHealth, deathSpell);
        }

        private static void PrintResult(int[] playerPos, double heiganCurrHealth, double playerCurrHealth,
            string deathSpell)
        {
            if (heiganCurrHealth <= 0)
            {
                Console.WriteLine("Heigan: Defeated!");
            }
            else
            {
                Console.WriteLine($"Heigan: {heiganCurrHealth:f2}");
            }

            if (playerCurrHealth <= 0)
            {
                Console.WriteLine($"Player: Killed by {deathSpell}");
            }
            else
            {
                Console.WriteLine($"Player: {playerCurrHealth}");
            }

            Console.WriteLine($"Final position: {playerPos[0]}, {playerPos[1]}");
        }

        private static bool PlayerTriesToEscape(int[] playerPos, int spellRow, int spellCol)
        {
            //Player tries to move up
            if (playerPos[0] - 1 >= 0 && playerPos[0] - 1 < spellRow - 1)
            {
                playerPos[0]--;
                return true;
            }
            //Player tries to move right
            else if (playerPos[1] + 1 < ChamberSize && playerPos[1] + 1 > spellCol + 1)
            {
                playerPos[1]++;
                return true;
            }
            //Player tries to move down
            else if (playerPos[0] + 1 < ChamberSize && playerPos[0] + 1 > spellRow + 1)
            {
                playerPos[0]++;
                return true;
            }
            //Player tries to move left
            else if (playerPos[1] - 1 >= 0 && playerPos[1] - 1 < spellCol - 1)
            {
                playerPos[1]--;
                return true;
            }

            return false;
        }

        private static bool IsPlayerInImpactZone(int[] playerPos, int spellRow, int spellCol)
        {
            bool isOnImpactRow = playerPos[0] >= spellRow - 1 && playerPos[0] <= spellRow + 1;
            bool isOnImpactCol = playerPos[1] >= spellCol - 1 && playerPos[1] <= spellCol + 1;

            return isOnImpactRow && isOnImpactCol;
        }
    }
}