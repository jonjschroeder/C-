using System;

namespace humans
{
    public class Humans{
        public string name;
        public int strength = 3;
        public int intelligence = 3;
        public int dexterity = 3;
        public int health = 100;
        // When an object is constructed from this class it should have the ability to pass a name
        public Humans(string n){
            name = n;
        }
        public Humans(string n, int str, int intel, int dex, int heal){
            name = n;
            strength = str;
            intelligence = intel;
            dexterity = dex;
            health = heal;

        }
        public void Attack(Humans enemy){
            enemy.health -= 5*strength;

        }
        static void Main(string[] args)
        {
            
        }
    }
}
