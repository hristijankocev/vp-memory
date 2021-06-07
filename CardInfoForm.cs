using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YuGiOh
{
    public partial class CardInfoForm : Form
    {
        public CardInfoForm(Card card)
        {
            if (card == null)
                return;
            InitializeComponent();

            lblName.Text = card.name;
            tbDesc.Text = @"Description: " + card.desc;
            lblAtk.Text = @"ATK: " + card.atk;
            lblDef.Text = @"DEF: " + card.def;
            lblLevel.Text = @"Level: " + card.level;
            lblType.Text = @"Type: " + card.type;
            lblId.Text = @"ID: " + card.id;
            lblEbayPrice.Text = @"Ebay price: $" + card.card_prices[0].ebay_price;
            lblAmazonPrice.Text = @"Amazon price: $" + card.card_prices[0].amazon_price;

            pbCard.LoadAsync(card.card_images[0].image_url);

            tbDesc.BackColor = Color.DarkOrange;

            tbDesc.ForeColor = Color.Black;
            tbDesc.SelectionLength = 0;

            // tbDesc.Enabled = false;
        }
    }
}