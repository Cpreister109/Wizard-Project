using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Net;
using System.Runtime.CompilerServices;

namespace second_ns {

    class second_class {
        static void Main(string[] args)
        {
            int user_choice = 0;
            
            static Wizard new_wizard() 
            {
                string input = Console.ReadLine();

                string[] user_build = input.Split('|');

                Wizard user_wizard = new Wizard(user_build[0], user_build[1], user_build[2]);

                return user_wizard;
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Hello! Welcome to Build a Wizard!\nExample: Wizard Name|Wizard Type|Favorite Spell");
            Console.WriteLine("Build your Wizard:");
            Wizard first_wizard = new_wizard();

            Console.WriteLine("----------------------------------------");

            while (user_choice != 5) 
            { 
                Console.WriteLine("What would you like to do?\n1) New Wizard\n2) Cast Spell\n3) Short Rest\n4) Long Rest\n5) Abandon your Journey");
                user_choice = Convert.ToInt32(Console.ReadLine());

                if (user_choice == 1) {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Build a different Wizard:");
                    Console.WriteLine("Example: Wizard Name|Wizard Type|Favorite Spell");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    first_wizard = new_wizard();
                }
                else if (user_choice == 2) {
                    first_wizard.cast_spell();
                }
                else if (user_choice == 3) {
                    first_wizard.short_rest();
                }
                else if (user_choice == 4) {
                    first_wizard.long_rest();
                }
                else if (user_choice == 5) {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Leaving this story behind...");
                }
                else {
                    Console.WriteLine("This path is not yet written!");
                }

                Console.WriteLine("----------------------------------------");

            }
        }
    }

    class Wizard {
        private string name;
        private string type;
        private string favSpell;
        private int spellSlots;
        private int level;

        public Wizard(string _name, string _type, string _favSpell) {
            
            name = _name;
            type = _type;
            favSpell = _favSpell;
            spellSlots = 2;
            level = 0;
        
        }

        public int cast_spell() {
            
            Random random = new Random();
            int damage = random.Next(8, 20) + (level * 10);
                
            if (spellSlots != 0)
            {

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(name + " the " + type + " wizard casted " + favSpell + ", and did " + damage + " damage!");
                
                level++;
                spellSlots--;
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Level Up! lvl " + level);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(spellSlots + " spell slots remain!");
                Console.ForegroundColor = ConsoleColor.Blue;
                
                return damage;
            }
            else 
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(name + " is exhausted, maybe we should rest?");
                Console.ForegroundColor = ConsoleColor.Blue;
                return 0;
            }
        }

        public void long_rest() {
            
            if (spellSlots == 2) {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Not tired.");
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else if (spellSlots < 2 && spellSlots >= 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                spellSlots = 2;
                Console.WriteLine("Fully Restored!");
                Console.ForegroundColor = ConsoleColor.Blue;
            }

        }

        public void short_rest() {
            
            if (spellSlots == 2) {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Not tired.");
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else if (spellSlots < 2 && spellSlots >= 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                spellSlots++;
                Console.WriteLine("Nice nap!");
                Console.WriteLine("Spell slots: " + spellSlots);
                Console.ForegroundColor = ConsoleColor.Blue;
            }

        }
    }

}
