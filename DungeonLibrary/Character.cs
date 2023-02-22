namespace DungeonLibrary
{
    public class Character
    {
        //Fields

        /*
         * int life(cannot be more than maxlife)
         * int maxlife (assign first in ctor)
         * string name
         * int hitChance
         * int block
         */

        private int _life;
        private int _maxLife;
        private string _name;
        private int _hitChance;
        private int _block;

        //Properties - 1 for each field

        public int MaxLife
        {
            get { return _maxLife; }
            set { _maxLife = value; }
        }
        public int Life
        {
            get { return _life; }
            set { _life = value <= MaxLife ? value : MaxLife; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int HitChance
        {
            get { return _hitChance; }
            set { _hitChance = value; }
        }
        public int Block
        {
            get { return _block; }
            set { _block = value; }
        }


        //Ctors - 1 fully qualified, 1 default/unqualified
        
        //Default
        public Character() { }

        //Fully Qualified
        public Character(int maxLife, int life, string name, int hitChance, int block)
        {
            MaxLife = maxLife;
            Life = life;
            Name = name;
            HitChance = hitChance;
            Block = block;
        }


        //Methods
        //ToString() override
        public override string ToString()
        {
            return $"Name: {Name}\n" +
                   $"Current Health: {Life}\n" +
                   $"Max Health: {MaxLife}\n" +
                   $"Hit Chance: {HitChance}\n" +
                   $"Block: {Block}\n";
        }//end string

        //CalcBlock() returns an int -> return Block;
        public int CalcBlock() 
        {
            return Block;
        }
        //CalcHitChance() returns an int -> return HitChance;
        public int CalcHitChance()
        {
            return HitChance;
        }
        //CalcDamage() returns an int -> return 0;
        public int CalcDamage()
        {
            return 0;
        }
    }
}