using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardSnapper.Models {
    public class Card {

        public int id { get; set; }
        public string name { get; set; }
        public int rarity { get; set; }
        public string imageURL { get; set; }
    }
}