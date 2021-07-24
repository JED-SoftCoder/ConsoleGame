using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class ProgramUI
    {
        Player player = new Player();
        public void Run()
        {
            Menu();
        }

        public void Menu()
        {
            
            Starter();
            bool keepRunning = true;
            while (keepRunning)
            {
                Intersection();
                string input = Console.ReadLine().ToLower();
                if(input.Contains("left")){
                    LeftHallway();
                }
                else if (input.Contains("forward"))
                {
                    ForwardHallway();
                }
                else if (input.Contains("right"))
                {
                    RightHallway();
                }
                else
                {
                    Console.WriteLine("You did not enter a valid choice!");
                }
            
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void Starter()
        {
            Console.WriteLine("You open your eyes to discover you are in a dungeon with chains on the wall and rats around you. In front of you light shimmers down a stone hallway. Going down the hallway leads you to an intersection.");

        }

        private void Intersection()
        {
            Console.WriteLine("You now stand in an intersection of hallways. There is a hallway to your left, right, and one in front of you. Which hallway do you go down? The left, right, or forward? Please enter your choice!");
        }

        private void LeftHallway()
        {
            Console.Clear();
            if (player.HasKey == false)
            {
                Console.WriteLine("You enter a room which looks to be like a guard's office. There is an old wooden table with an old key on it. Around the room, some scattered papers and overturned chairs lay on the floor. Do you take the key or turn back?");
                string input = Console.ReadLine().ToLower();
                if (input.Contains("key"))
                {
                    player.HasKey = true;
                    Console.WriteLine("You take the key and return to the intersection that you came from! Press any key to continue!");
                }
                else if (input.Contains("back"))
                {
                    Console.WriteLine("You decide to go back to the intersection! Press any key to continue!");
                }
            }
            else if(player.HasKey == true)
            {
                Console.WriteLine("You enter a room which looks to be like a guard's office. There is an old wooden table with nothing on it. Around the room, some scattered papers and overturned chairs lay on the floor. Finding nothing of importance here, you decide to head back to the intersection. Press any key to continue!");

            }
        }
        
        private void ForwardHallway()
        {
            Console.Clear();
            if (player.HasUnlockedGate == false)
            {
                Console.WriteLine("You are stopped in your tracks by a locked gate. Do you use a key or do you turn back?");
                string input = Console.ReadLine().ToLower();
                if (input.Contains("key"))
                {
                    if (player.HasKey == true)
                    {
                        Console.WriteLine("You unlock the gate and continue!");
                        player.HasUnlockedGate = true;
                        ContinueDownHallway();
                    }
                    else
                    {
                        Console.WriteLine("You do not have a key for this gate! You decide to go check the other rooms for a key! Press any key to return to the intersection!");
                    }
                }
                else if (input.Contains("back"))
                {
                    Console.WriteLine("You decide to go back to the intersection! Press any key to continue!");
                }
            }
            else if (player.HasUnlockedGate == true)
            {
                ContinueDownHallway();
            }
        }

        private void RightHallway()
        {
            if (player.HasVisitedSphinx == false)
            {
                Console.Clear();
                Console.WriteLine("You enter an empty room. Finding nothing here, you simply turn back. Press any key to return to the intersection.");
            }

            else if (player.HasVisitedSphinx == true)
            {
                Console.Clear();
                Console.WriteLine("The room is now different than before. You enter a dimly lit room with a stone tablet with images and an inscription mounted on the main wall. Besides the tablet, you see nothing else in this room. Do you inspect the tablet or turn back?");
                string input = Console.ReadLine().ToLower();
                if (input.Contains("tablet"))
                {
                    Console.WriteLine("Upon moving closer and inspecting the tablet, you find a very strange depiction. You see a baby crawling forward, with a man walking in front of it, with an elderly man walking with a cane in front of the man. Below this depiction is a single line of text chiseled in. The words say: The evolution of a person. With nothing else in this room, you now turn back.");
                           Console.WriteLine("Press any key to return to the main hallway...");
                }
                else if (input.Contains("back"))
                {
                    Console.WriteLine("Press any button to return to the main hallway!");
                }
            }
        }

        private void ContinueDownHallway()
        {
            Console.Clear();
            player.HasVisitedSphinx = true;
            Console.WriteLine("You enter a large room with a sleeping sphinx in front of you. Upon moving further into the room, the sphinx wakes up and greets you. Upon a bit of conversation, the sphinx tells you that if you wish to continue on, you must answer a riddle. Upon accepting, the sphinx says: What goes on four feet in the morning, two feet at noon, and three feet in the evening? The sphinx then awaits your answer.");
            string input = Console.ReadLine().ToLower();
            if (input.Contains("person"))
            {
                Console.Clear();
                Console.WriteLine("The sphinx congratulates you on answering the riddle and moves aside, revealing a hallway behind him.");
                MovePastSphinx();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("The sphinx informs you that you have answered incorrectly. The sphinx then offers some advice: Go back and look for a hint to my riddle! Taking the advice, the sphinx goes back to sleep, you go back past the gate, and you return to the intersection. Press any key to continue.");
             
            }
        }

        private void MovePastSphinx()
        {
            Console.Clear();
            Console.WriteLine("You now stand at a hallway going left and right. A dim light glows to the left. You get an eerie feeling looking down the right. Which way do you go?");
            string input = Console.ReadLine().ToLower();
            if (input.Contains("left"))
            {
                Armory();
            }
            else if (input.Contains("right"))
            {
                Console.Clear();
                StrangerEncounters();
            }
        }

        private void StrangerEncounters()
        {
            Console.Clear();
            player.HasVisitedStranger = true;
            if (player.HasVisitedArmory == false)
            {
                Console.WriteLine("A stranger emerges from the shadows as you venture down the hallway. He warns you of a sleeping dragon in the next room and beyond that, the door to your freedom. The stranger informs you that you should go back down the other hallway to get some gear from the armory. Taking this advice you head back towards the armory! Press any key to continue!");
                Console.ReadKey();
                MovePastSphinx();
            }
            else if (player.HasVisitedArmory == true)
            {
                Console.WriteLine("A stranger emerges from the shadows as you approach the end of the hallway. He takes a look at your newly acquired gear and offers some advice for the battle ahead. The dragon has a weak spot. Make sure to look for it and good luck! As you move past, he grabs your shoulder and says: Don't be stubborn and save that potion. If things get dire, use it! He then lets you continue on! Press any key to continue!");
                Console.ReadKey();
                DragonFight();
            }
        }

        private void Armory()
        {
            Console.Clear();
            Console.WriteLine("You enter a room with many armor racks lining the walls and a few tables with lots of random odds and ends. After scouring the room for a minute, you find a sword and a health potion.");
            player.HasVisitedArmory = true;
            player.HasSword = true;
            player.HasHealthPotion = true;
            if (player.HasVisitedStranger == false)
            {
                Console.WriteLine("Press any key to continue on...");
                Console.ReadKey();
            }
            else if(player.HasVisitedStranger == true)
            {
                Console.WriteLine("Finding nothing else, you decide to head back towards the stranger to continue to fight the dragon! Press any key to continue!");
                Console.ReadKey();
            }
            MovePastSphinx();
        }

        private void DragonFight()
        {
            Console.Clear();
            Console.WriteLine("You enter the room of the great sleeping dragon. Upon moving in, the dragon raises it's great head and follows up by quickly standing up. You now enter battle! Press any key to continue!");
            Console.ReadKey();
            int PlayerHealth = 15;
            int DragonsHealth = 30;
            bool keepRunning = true;
            while (keepRunning == true)
            {
                if (PlayerHealth > 0 && DragonsHealth > 0)
                {

                    Console.WriteLine($"Your HP: {PlayerHealth}");
                    Console.WriteLine($"Dragon's Hp: {DragonsHealth}");
                    if (player.HasHealthPotion == true)
                    {
                    
                        Console.WriteLine("What do you do? Attack or use potion?");
                        string input = Console.ReadLine().ToLower();
                        if (input.Contains("attack"))
                        {
                            Console.WriteLine("Which part of the dragon do you attack? The scaly arm, the chest missing a few scales, or his left wing?");
                            string input2 = Console.ReadLine().ToLower();
                            if (input2.Contains("arm"))
                            {
                                Console.WriteLine("You swing and clip the dragon's arm! Press any key to continue!");
                                Console.ReadKey();
                                DragonsHealth -= 5;
                            }
                            else if (input2.Contains("chest"))
                            {
                                Console.WriteLine("You score a big hit on the dragon's chest! Press any key to continue!");
                                Console.ReadKey();
                                DragonsHealth -= 10;
                            }
                            else if (input2.Contains("wing"))
                            {
                                Console.WriteLine("You cut a hole in part of the dragon's wing! Press any key to continue!");
                                Console.ReadKey();
                                DragonsHealth -= 8;

                            }
                        }
                        else if (input.Contains("potion"))
                        {
                            Console.WriteLine("You pull the cork and drink the contents!");
                            PlayerHealth += 10;
                            player.HasHealthPotion = false;
                        }
                    }
                    else if (player.HasHealthPotion == false)
                    { 
                        Console.WriteLine("Which part of the dragon do you attack? The scaly arm, the chest missing a few scales, or his left wing?");
                        string input = Console.ReadLine().ToLower();
                        if (input.Contains("arm"))
                        {
                            Console.WriteLine("You swing and clip the dragon's arm! Press any key to continue!");
                            Console.ReadKey();
                            DragonsHealth -= 5;
                        }
                        else if (input.Contains("chest"))
                        {
                            Console.WriteLine("You score a big hit on the dragon's chest! Press any key to continue!");
                            Console.ReadKey();
                            DragonsHealth -= 10;
                        }
                        else if (input.Contains("wing"))
                        {
                            Console.WriteLine("You cut a hole in part of the dragon's wing! Press any key to continue!");
                            Console.ReadKey();
                            DragonsHealth -= 8;

                        }
                    }
                    Console.WriteLine("The dragon attacks you! You take 5 damage! Press any key to continue!");
                    Console.ReadKey();
                    PlayerHealth -= 5;
                }
                else if (DragonsHealth <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Congratulations! You have slain the dragon and earned your freedom! You move past the slain dragon to the large wooden door behind it. You push the door open to reveal the outside world! Thanks for playing! Press any key to exit the terminal!");
                    Console.ReadKey();
                    Environment.Exit(0);
                   

                }
                else if (PlayerHealth <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("You swing one last time only to be struck first by the dragon. Feeling the beast's mighty swing, you fall to the ground and pass out. Press any key to exit the terminal!");
                    Console.ReadKey();
                    Environment.Exit(0);
                    
                }
            }
        }
    }
}
