using System.Drawing;
using System.Windows.Forms;

namespace YuGiOh
{
    public partial class CardInfoForm : Form
    {
        public static Card _card;

        public CardInfoForm(Card card)
        {
            _card = card;
            if (_card == null)
                return;
            InitializeComponent();

            lblName.Text = _card.name;
            tbDesc.Text = @"Description: " + _card.desc;
            lblAtk.Text = @"ATK: " + _card.atk;
            lblDef.Text = @"DEF: " + _card.def;
            lblLevel.Text = @"Level: " + _card.level;
            lblType.Text = @"Type: " + _card.type;
            lblId.Text = @"ID: " + _card.id;
            lblEbayPrice.Text = @"Ebay price: $" + _card.card_prices[0].ebay_price;
            lblAmazonPrice.Text = @"Amazon price: $" + _card.card_prices[0].amazon_price;

            pbCard.LoadAsync(_card.card_images[0].image_url);

            tbDesc.BackColor = Color.DarkOrange;
            tbDesc.ForeColor = Color.Black;
        }
    }
}