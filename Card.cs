﻿using System.Collections.Generic;


namespace YuGiOh
{
    public class Card
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string desc { get; set; }
        public string atk { get; set; }
        public string def { get; set; }
        public string level { get; set; }
        public string race { get; set; }
        public string attribute { get; set; }
        public List<CardSet> card_sets { get; set; }
        public List<CardImage> card_images { get; set; }
        public List<CardPrice> card_prices { get; set; }

        public bool clicked { get; set; }
        public string uniqueId { get; set; }
        public List<string> pictureBoxes { get; set; }
    }

    public class CardSet
    {
        public string set_name { get; set; }
        public string set_code { get; set; }
        public string set_rarity { get; set; }
        public string set_price { get; set; }
    }

    public class CardImage
    {
        public string image_url { get; set; }
        public string image_url_small { get; set; }
    }

    public class CardPrice
    {
        public string cardmarket_price { get; set; }
        public string tcgplayer_price { get; set; }
        public string ebay_price { get; set; }
        public string amazon_price { get; set; }
    }
}