using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    public class Card
    {
        public Card(string name, string suit, int value)
        {
            this.name = name;
            this.suit = suit;
            this.value = value;
        }

        public string name;
        public int value;
        public string suit;
    }

}
