using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
 Домашнее задание: 
В один обыденный день к вам в кабинет забегает запыхавшийся геймдизайнер, который, кажется, чем-то очень обеспокоен. 
Не объясняя, что случилось, он сообщает вам, что вынужден срочно оставить рабочее место, но у него осталась незавершённая задача, у которой горят сроки, и поэтому он вынужден обратиться за помощью к вам. 
В игре, над которой он работает, присутствует продвинутая система боя, в которой на исход атаки влияет множество факторов. 
Наносимый урон рассчитывается по формуле, с которой ваш коллега-геймдизайнер как раз и хочет попросить вас помочь. Он делится с вами своими наработками:
Во-первых, у каждого юнита есть своя базовая атака: фиксированное положительное целочисленное значение (например, 15).
Во-вторых, у них есть базовая защита: это положительное целочисленное значение в диапазоне от 0 до 100, показывающее, сколько процентов от получаемого урона будет поглощено (например, если юниту с защитой 10 нанесено 25 урона, он в итоге получит только 25 * 0,9 = 22,5 урона)
В-третьих, на наносимый урон влияет, в каких фракциях находятся юниты. Существует три фракции: добро, зло и нейтралитет. 
Добрые и злые юниты получают дебафф в 50% к урону, если они атакуют юнита из своей фракции, и бафф в 50%, если атакуют юнита из противоположной (для добрых это злые, для злых это добрые). 
На нейтральных юнитов это правило никак не работает.
В-четвертых, в какой-то момент сражения юниты могут достичь состояния берсерка - тогда их базовый урон увеличивается в 2 раза, но базовая защита уменьшается на 80%.
Вам необходимо запрограммировать формулу, которая будет учитывать все эти аспекты, и написать программу, которая будет получать на вход все нужные данные о сражающихся и рассчитывать конечный урон, который получит защищающаяся сторона, по данной формуле.
P. S. Уходя, геймдизайнер мягко намекает, что он был бы совершенно не против, если вы сами решите пофантазировать и ввести какие-то новые переменные в формулу.
*/

namespace DZ_1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            bool gameStart = true;
            Random rand = new Random();

            while (gameStart)
            {

            #region EvilUnit
            double healthEvilUnit = 100;
            int armorEvilUnit = 6;
            int damageEvilUnit = 15;
            #endregion

            #region GoodUnit
            double healthGoodUnit = 100;
            int armorGoodUnit = 5;
            int damageGoodUnit = 20;
            #endregion

            #region NeutralUnit
            double healthNeutralUnit = 100;
            int chanceDodgeNeutralUnit = 10;
            int damageNeutralUnit = 20;
            #endregion

            
                Console.WriteLine("Выберите своего боца!\n");

                Console.WriteLine("1.Персонаж из фракции зла\nХарактеристики:");
                Console.WriteLine($"Здоровье: {healthEvilUnit}\n" +
                    $"Защита: {armorEvilUnit}\n" +
                    $"Урон: {damageEvilUnit}");

                Console.SetCursorPosition(28, 2);
                Console.WriteLine("2.Персонаж из фракции добра");
                Console.SetCursorPosition(28, 3);
                Console.WriteLine("Характеристики:");
                Console.SetCursorPosition(28, 4);
                Console.WriteLine($"Здоровье: {healthGoodUnit}");
                Console.SetCursorPosition(28, 5);
                Console.WriteLine($"Защита: {armorGoodUnit}");
                Console.SetCursorPosition(28, 6);
                Console.WriteLine($"Урон: {damageGoodUnit}");

                Console.SetCursorPosition(58, 2);
                Console.WriteLine("3.Персонаж из нейтральной фракции");
                Console.SetCursorPosition(58, 3);
                Console.WriteLine("Характеристики:");
                Console.SetCursorPosition(58, 4);
                Console.WriteLine($"Здоровье: {healthNeutralUnit}");
                Console.SetCursorPosition(58, 5);
                Console.WriteLine($"Шанс уклонения: {chanceDodgeNeutralUnit}");
                Console.SetCursorPosition(58, 6);
                Console.WriteLine($"Урон: {damageNeutralUnit}");

                Console.SetCursorPosition(0, 8);
                Console.WriteLine("Как только определитесь с выбором, введите число соответсвующее персонужу одной из трех фракций.");
                Console.WriteLine("Ваш выбор: ");

                int choiceUser;

                bool cheeckInput = int.TryParse(Console.ReadLine(), out choiceUser);
                if (cheeckInput && choiceUser > 0 && choiceUser < 4)
                {
                    Console.WriteLine("Отличный выбор!");
                    Console.WriteLine("Сражение начнется как только определится ваш противник");
                    Thread.Sleep(4000);
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Такого номера фракции нет(\n" +
                        "Число 1 - персонаж из фракации зла\n" +
                        "Число 2 - персонаж из фракации добра\n" +
                        "Число 3 - персонаж из нейтральной фракции\n");
                    Thread.Sleep(4000);
                    Console.Clear();
                    continue;
                }

                int defineEnemy = rand.Next(1, 4);
                defineEnemy = 3;

                if (choiceUser == 1)
                {
                    if (defineEnemy == 1)
                    {
                        Console.WriteLine("Ого, вот это неожиданность противник из тойже фракции.\n" +
                            "Похоже сейчас мы и узнаем зло в чей душе сильнее.");
                        Console.WriteLine("Да начнется битва!!!");

                        double healthEvilUnitEnemy = 100;
                        int armorEvilUnitEnemy = 50;
                        int damageEvilUnitEnemy = 15;
                        int i = 1;
                       
                        while (healthEvilUnitEnemy > 0 && healthEvilUnit > 0)
                        {
                            healthEvilUnitEnemy -= ((armorEvilUnitEnemy * 0.09) * rand.Next(2, damageEvilUnit + 1));
                            healthEvilUnit -= ((armorEvilUnit * 0.09) * rand.Next(2, damageEvilUnitEnemy + 1)) / 2;

                            if (healthEvilUnitEnemy < 0) healthEvilUnitEnemy = 0;
                            else if (50 > healthEvilUnitEnemy && damageEvilUnitEnemy != 30) {
                                armorEvilUnitEnemy = armorEvilUnitEnemy * 20 / 100;
                                damageEvilUnitEnemy *= 2;
                            }
                            if (healthEvilUnit < 0) healthEvilUnit = 0;
                            else if (50 > healthEvilUnit && damageEvilUnit != 30)
                            {
                                armorEvilUnit = armorEvilUnit * 20 / 100;
                                damageEvilUnit *= 2;
                            }

                            Console.WriteLine($"Битва {i}");
                            Console.WriteLine($"Здоровье вашего персонажа {healthEvilUnit}");
                            Console.WriteLine($"Здоровье противника {healthEvilUnitEnemy}\n");
                             i++;
                        }

                        if (healthEvilUnitEnemy == healthEvilUnit)
                            Console.WriteLine("Ничего себе! Похоже вышла ничья, как жаль)");
                        else if (healthEvilUnitEnemy == 0)
                            Console.WriteLine("Поздравляем! Победа за вашим персонажем");
                        else if (healthEvilUnit == 0)
                            Console.WriteLine("К сожалению в этот раз противник оказался сильнее...");
                    }
                    else if (defineEnemy == 2)
                    {
                        Console.WriteLine("И ваш противник из фракции добра\n" +
                            "Какая каноничнаяя битва у нас выходит");
                        Console.WriteLine("Да начнется битва!!!");
                        int i = 1;

                        while (healthGoodUnit > 0 && healthEvilUnit > 0)
                        {
                            healthGoodUnit -= ((armorGoodUnit * 0.09) * rand.Next(2, damageEvilUnit + 1));
                            healthEvilUnit -= ((armorEvilUnit * 0.09) * rand.Next(2, damageGoodUnit + 1)) * 2;

                            if (healthGoodUnit < 0) healthGoodUnit = 0;
                            else if (50 > healthGoodUnit && damageGoodUnit != 10)
                            {
                                damageGoodUnit = damageGoodUnit * 20 / 100;
                                armorGoodUnit *= 2;
                            }
                            if (healthEvilUnit < 0) healthEvilUnit = 0;
                            else if (50 > healthEvilUnit && damageEvilUnit != 30)
                            {
                                armorEvilUnit = armorEvilUnit * 20 / 100;
                                damageEvilUnit *= 2;
                            }

                             Console.WriteLine($"Битва {i}");
                            Console.WriteLine($"Здоровье вашего персонажа {healthEvilUnit}");
                            Console.WriteLine($"Здоровье противника {healthGoodUnit}\n");
                            i++;
                        }

                        if (healthGoodUnit == healthEvilUnit)
                            Console.WriteLine("Ничего себе! Похоже вышла ничья, как жаль)");
                        else if (healthGoodUnit == 0)
                            Console.WriteLine("Поздравляем! Победа за вашим персонажем");
                        else if (healthEvilUnit == 0)
                            Console.WriteLine("К сожалению в этот раз противник оказался сильнее...");
                    }
                    else if (defineEnemy == 3)
                    {
                        Console.WriteLine("Ваш противник из нейтральной фракции удача это или нет?))\n");
                        Console.WriteLine("Да начнется битва!!!");
                        int i = 1;

                        while (healthNeutralUnit > 0 && healthEvilUnit > 0)
                        {
                            healthNeutralUnit -= ((rand.Next(0, chanceDodgeNeutralUnit + 1) * 0.09) * rand.Next(2, damageEvilUnit + 1));
                            healthEvilUnit -= ((armorEvilUnit * 0.09) * rand.Next(2, damageNeutralUnit + 1));

                            if (healthEvilUnit < 0) healthEvilUnit = 0;
                            else if (50 > healthEvilUnit && damageEvilUnit != 30)
                            {
                                armorEvilUnit = armorEvilUnit * 20 / 100;
                                damageEvilUnit *= 2;
                            }
                            if (healthNeutralUnit < 0) healthNeutralUnit = 0;
                            else if (50 > healthNeutralUnit && damageNeutralUnit != 10)
                            {
                                damageNeutralUnit = damageNeutralUnit / 2;
                                chanceDodgeNeutralUnit = 3;
                            }

                            Console.WriteLine($"Битва {i}");
                            Console.WriteLine($"Здоровье вашего персонажа {healthEvilUnit}");
                            Console.WriteLine($"Здоровье противника {healthNeutralUnit}\n");
                            i++;
                        }
                        if (healthNeutralUnit == healthEvilUnit)
                            Console.WriteLine("Ничего себе! Похоже вышла ничья, как жаль)");
                        else if (healthNeutralUnit == 0)
                            Console.WriteLine("Поздравляем! Победа за вашим персонажем");
                        else if (healthEvilUnit == 0)
                            Console.WriteLine("К сожалению в этот раз противник оказался сильнее...");
                    }
                }

                if (choiceUser == 2)
                {
                    if (defineEnemy == 1)
                    {
                        Console.WriteLine("Ого, вот это неожиданность противник из тойже фракции.\n" +
                            "Похоже сейчас мы и узнаем добро в чей душе сильнее.");
                        Console.WriteLine("Да начнется битва!!!");

                        double healthGoodUnitEnemy = 100;
                        int armorGoodUnitEnemy = 5;
                        int damageGoodUnitEnemy = 20;
                        int i = 1;

                        while (healthGoodUnitEnemy > 0 && healthEvilUnit > 0)
                        {
                            healthGoodUnitEnemy -= ((armorGoodUnitEnemy * 0.09) * rand.Next(2, damageGoodUnit + 1));
                            healthGoodUnit -= ((armorGoodUnit * 0.09) * rand.Next(2, damageGoodUnitEnemy + 1)) / 2;

                            if (healthGoodUnitEnemy < 0) healthGoodUnitEnemy = 0;
                            else if (50 > healthGoodUnitEnemy && damageGoodUnitEnemy != 30)
                            {
                                damageGoodUnitEnemy = damageGoodUnitEnemy * 20 / 100;
                                armorGoodUnitEnemy *= 2;
                            }
                            if (healthGoodUnit < 0) healthGoodUnit = 0;
                            else if (50 > healthGoodUnit && damageGoodUnit != 10)
                            {
                                damageGoodUnit = damageGoodUnit * 20 / 100;
                                armorGoodUnit *= 2;
                            }

                            Console.WriteLine($"Битва {i}");
                            Console.WriteLine($"Здоровье вашего персонажа {healthGoodUnit}");
                            Console.WriteLine($"Здоровье противника {healthGoodUnitEnemy}\n");
                            i++;
                        }

                        if (healthGoodUnitEnemy == healthGoodUnit)
                            Console.WriteLine("Ничего себе! Похоже вышла ничья, как жаль)");
                        else if (healthGoodUnitEnemy == 0)
                            Console.WriteLine("Поздравляем! Победа за вашим персонажем");
                        else if (healthGoodUnit == 0)
                            Console.WriteLine("К сожалению в этот раз противник оказался сильнее...");
                    }
                    else if (defineEnemy == 2)
                    {
                        Console.WriteLine("И ваш противник из фракции зла\n" +
                            "Какая каноничнаяя битва у нас выходит");
                        Console.WriteLine("Да начнется битва!!!");
                        int i = 1;

                        while (healthGoodUnit > 0 && healthEvilUnit > 0)
                        {
                            healthGoodUnit -= ((armorGoodUnit * 0.09) * rand.Next(2, damageEvilUnit + 1)) * 2;
                            healthEvilUnit -= ((armorEvilUnit * 0.09) * rand.Next(2, damageGoodUnit + 1));

                            if (healthGoodUnit < 0) healthGoodUnit = 0;
                            else if (50 > healthGoodUnit && damageGoodUnit != 10)
                            {
                                damageGoodUnit = damageGoodUnit * 20 / 100;
                                armorGoodUnit *= 2;
                            }
                            if (healthEvilUnit < 0) healthEvilUnit = 0;
                            else if (50 > healthEvilUnit && damageEvilUnit != 30)
                            {
                                armorEvilUnit = armorEvilUnit * 20 / 100;
                                damageEvilUnit *= 2;
                            }

                            Console.WriteLine($"Битва {i}");
                            Console.WriteLine($"Здоровье вашего персонажа {healthGoodUnit}");
                            Console.WriteLine($"Здоровье противника {healthEvilUnit}\n");
                            i++;
                        }

                        if (healthGoodUnit == healthEvilUnit)
                            Console.WriteLine("Ничего себе! Похоже вышла ничья, как жаль)");
                        else if (healthEvilUnit == 0)
                            Console.WriteLine("Поздравляем! Победа за вашим персонажем");
                        else if (healthGoodUnit == 0)
                            Console.WriteLine("К сожалению в этот раз противник оказался сильнее...");
                    }
                    else if (defineEnemy == 3)
                    {
                        Console.WriteLine("Ваш противник из нейтральной фракции удача это или нет?))\n");
                        Console.WriteLine("Да начнется битва!!!");
                        int i = 1;

                        while (healthNeutralUnit > 0 && healthGoodUnit > 0)
                        {
                            healthNeutralUnit -= ((rand.Next(0, chanceDodgeNeutralUnit + 1) * 0.09) * rand.Next(2, damageGoodUnit + 1));
                            healthGoodUnit -= ((armorGoodUnit * 0.09) * rand.Next(2, damageNeutralUnit + 1));

                            if (healthGoodUnit < 0) healthGoodUnit = 0;
                            else if (50 > healthGoodUnit && damageGoodUnit != 10)
                            {
                                damageGoodUnit = damageGoodUnit * 20 / 100;
                                armorGoodUnit *= 2;
                            }
                            if (healthNeutralUnit < 0) healthNeutralUnit = 0;
                            else if (50 > healthNeutralUnit && damageNeutralUnit != 10)
                            {
                                damageNeutralUnit = damageNeutralUnit / 2;
                                chanceDodgeNeutralUnit = 3;
                            }

                            Console.WriteLine($"Битва {i}");
                            Console.WriteLine($"Здоровье вашего персонажа {healthGoodUnit}");
                            Console.WriteLine($"Здоровье противника {healthNeutralUnit}\n");
                            i++;
                        }
                        if (healthNeutralUnit == healthGoodUnit)
                            Console.WriteLine("Ничего себе! Похоже вышла ничья, как жаль)");
                        else if (healthNeutralUnit == 0)
                            Console.WriteLine("Поздравляем! Победа за вашим персонажем");
                        else if (healthGoodUnit == 0)
                            Console.WriteLine("К сожалению в этот раз противник оказался сильнее...");
                    }
                }

                if (choiceUser == 3)
                {
                    if (defineEnemy == 1)
                    {
                        Console.WriteLine("И ваш противник из фракции добра\n");
                        Console.WriteLine("Да начнется битва!!!");
                        int i = 1;

                        while (healthNeutralUnit > 0 && healthGoodUnit > 0)
                        {
                            healthNeutralUnit -= ((chanceDodgeNeutralUnit * 0.09) * rand.Next(2, damageGoodUnit + 1));
                            healthGoodUnit -= ((armorGoodUnit * 0.09) * rand.Next(2, damageNeutralUnit + 1));

                            if (healthNeutralUnit < 0) healthNeutralUnit = 0;
                            else if (50 > healthNeutralUnit && damageNeutralUnit != 10)
                            {
                                damageNeutralUnit = damageNeutralUnit / 2;
                                chanceDodgeNeutralUnit = 3;
                            }
                            if (healthGoodUnit < 0) healthGoodUnit = 0;
                            else if (50 > healthGoodUnit && damageGoodUnit != 10)
                            {
                                damageGoodUnit = damageGoodUnit * 20 / 100;
                                armorGoodUnit *= 2;
                            }

                            Console.WriteLine($"Битва {i}");
                            Console.WriteLine($"Здоровье вашего персонажа {healthNeutralUnit}");
                            Console.WriteLine($"Здоровье противника {healthGoodUnit}\n");
                            i++;
                        }

                        if (healthGoodUnit == healthNeutralUnit)
                            Console.WriteLine("Ничего себе! Похоже вышла ничья, как жаль)");
                        else if (healthGoodUnit == 0)
                            Console.WriteLine("Поздравляем! Победа за вашим персонажем");
                        else if (healthNeutralUnit == 0)
                            Console.WriteLine("К сожалению в этот раз противник оказался сильнее...");
                    }
                    else if (defineEnemy == 2)
                    {
                        Console.WriteLine("И ваш противник из фракции зла\n");
                        Console.WriteLine("Да начнется битва!!!");
                        int i = 1;

                        while (healthNeutralUnit > 0 && healthEvilUnit > 0)
                        {
                            healthNeutralUnit -= ((chanceDodgeNeutralUnit * 0.09) * rand.Next(2, damageEvilUnit + 1));
                            healthEvilUnit -= ((armorEvilUnit * 0.09) * rand.Next(2, damageNeutralUnit + 1));

                            if (healthNeutralUnit < 0) healthNeutralUnit = 0;
                            else if (50 > healthNeutralUnit && damageNeutralUnit != 10)
                            {
                                damageNeutralUnit = damageNeutralUnit / 2;
                                chanceDodgeNeutralUnit = 3;
                            }
                            if (healthEvilUnit < 0) healthEvilUnit = 0;
                            else if (50 > healthEvilUnit && damageEvilUnit != 30)
                            {
                                armorEvilUnit = armorEvilUnit * 20 / 100;
                                damageEvilUnit *= 2;
                            }

                            Console.WriteLine($"Битва {i}");
                            Console.WriteLine($"Здоровье вашего персонажа {healthNeutralUnit}");
                            Console.WriteLine($"Здоровье противника {healthEvilUnit}\n");
                            i++;
                        }

                        if (healthNeutralUnit == healthEvilUnit)
                            Console.WriteLine("Ничего себе! Похоже вышла ничья, как жаль)");
                        else if (healthEvilUnit == 0)
                            Console.WriteLine("Поздравляем! Победа за вашим персонажем");
                        else if (healthNeutralUnit == 0)
                            Console.WriteLine("К сожалению в этот раз противник оказался сильнее...");
                    }
                    else if (defineEnemy == 3)
                    {
                        Console.WriteLine("Ого, вот это неожиданность противник из тойже фракции.\n" +
                            "Похоже сейчас мы и узнаем добро в чей душе сильнее.");
                        Console.WriteLine("Да начнется битва!!!");
                        int i = 1;

                        double healthNeutraUnitEnemy = 100;
                        int chanceDodgeNeutralUnitEnemy = 5;
                        int damageNeutraUnitEnemy = 20;

                        while (healthNeutralUnit > 0 && healthNeutraUnitEnemy > 0)
                        {
                            healthNeutralUnit -= ((rand.Next(0, chanceDodgeNeutralUnit + 1) * 0.09) * rand.Next(2, damageNeutraUnitEnemy + 1));
                            healthNeutraUnitEnemy -= ((chanceDodgeNeutralUnitEnemy * 0.09) * rand.Next(2, damageNeutralUnit + 1));

                            if (healthNeutraUnitEnemy < 0) healthNeutraUnitEnemy = 0;
                            else if (50 > healthNeutraUnitEnemy && damageNeutraUnitEnemy != 10)
                            {
                                damageNeutraUnitEnemy = damageNeutraUnitEnemy / 2;
                                chanceDodgeNeutralUnitEnemy = 3;
                            }
                            if (healthNeutralUnit < 0) healthNeutralUnit = 0;
                            else if (50 > healthNeutralUnit && damageNeutralUnit != 10)
                            {
                                damageNeutralUnit = damageNeutralUnit / 2;
                                chanceDodgeNeutralUnit = 3;
                            }

                            Console.WriteLine($"Битва {i}");
                            Console.WriteLine($"Здоровье вашего персонажа {healthNeutralUnit}");
                            Console.WriteLine($"Здоровье противника {healthNeutraUnitEnemy}\n");
                            i++;
                        }
                        if (healthNeutralUnit == healthNeutraUnitEnemy)
                            Console.WriteLine("Ничего себе! Похоже вышла ничья, как жаль)");
                        else if (healthNeutraUnitEnemy == 0)
                            Console.WriteLine("Поздравляем! Победа за вашим персонажем");
                        else if (healthNeutralUnit == 0)
                            Console.WriteLine("К сожалению в этот раз противник оказался сильнее...");
                    }
                }

                Console.ReadKey();
                Console.Clear();
            }


        }
    }
}
