using Telerik.WinControls;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.UI;

namespace SchoolManagement.UI.CustomControls
{
    public partial class DateNavigator : UserControl
    {
        #region fields
        private TextPrimitive calendarGlyph = new TextPrimitive();
        #endregion

        #region Constructors
        public DateNavigator()
        {
            InitializeComponent();

            this.BackColor = Color.Transparent;
            this.navigatorDateTimePicker.BackColor = Color.Transparent;

            this.navigatorDateTimePicker.DateTimePickerElement.TextBoxElement.Visibility = ElementVisibility.Collapsed;
            ImagePrimitive imagePrimitive = this.navigatorDateTimePicker.DateTimePickerElement.ArrowButton.FindDescendant<ImagePrimitive>();
            imagePrimitive.Visibility = ElementVisibility.Collapsed;

            this.navigatorDateTimePicker.DateTimePickerElement.ArrowButton.Children.Add(calendarGlyph);
            calendarGlyph.Text = "\ue108";
            calendarGlyph.CustomFont = "TelerikWebUI";
            calendarGlyph.CustomFontSize = 15;

            this.navigatorDateTimePicker.DateTimePickerElement.ArrowButton.Alignment = ContentAlignment.MiddleRight;
            this.navigatorDateTimePicker.DateTimePickerElement.ArrowButton.Padding = new Padding(0);
            this.navigatorDateTimePicker.DateTimePickerElement.ArrowButton.Margin = new Padding(5, 15, 5, 15);

            this.navigatorDateTimePicker.ValueChanged += NavigatorDateTimePicker_ValueChanged;

            this.leftNavigationButton.RootElement.EnableElementShadow = false;
            this.rightNavigationButton.RootElement.EnableElementShadow = false;
            this.navigatorDateTimePicker.RootElement.EnableElementShadow = false;

            this.leftNavigationButton.ButtonElement.Text = "\ue016";
            this.leftNavigationButton.ButtonElement.CustomFont = "TelerikWebUI";
            this.leftNavigationButton.ButtonElement.CustomFontSize = 15;
            this.leftNavigationButton.ButtonElement.ForeColor = Color.Gray;
            this.leftNavigationButton.ButtonElement.Padding = new Padding(0, 5, 0, 0);
            this.leftNavigationButton.ButtonElement.Margin = new Padding(0, 15, 0, 15);
            this.leftNavigationButton.ButtonElement.EnableElementShadow = false;

            this.rightNavigationButton.ButtonElement.Text = "\ue014";
            this.rightNavigationButton.ButtonElement.CustomFont = "TelerikWebUI";
            this.rightNavigationButton.ButtonElement.CustomFontSize = 15;
            this.rightNavigationButton.ButtonElement.ForeColor = Color.Gray;
            this.rightNavigationButton.ButtonElement.Padding = new Padding(0, 5, 0, 0);
            this.rightNavigationButton.ButtonElement.Margin = new Padding(0, 15, 0, 15);
            this.rightNavigationButton.ButtonElement.EnableElementShadow = false;

            this.dateLabel.LabelElement.CustomFont = Utilities.ViewUtilities.MainFont;
            this.dateLabel.LabelElement.CustomFontSize = 15;
            this.dateLabel.LabelElement.CustomFontStyle = FontStyle.Regular;
            this.dateLabel.TextAlignment = ContentAlignment.MiddleLeft;
            this.dateLabel.Margin = new Padding(-10, 0, 0, 0);
            this.dateLabel.LabelElement.LabelText.Margin = new Padding(0, 5, 0, 0);

            RadDateTimePickerCalendar calendar = this.navigatorDateTimePicker.DateTimePickerElement.CurrentBehavior as RadDateTimePickerCalendar;
            if (calendar != null)
            {
                calendar.DateTimePickerElement.FindDescendant<StackLayoutElement>().StretchHorizontally = false;
                calendar.Calendar.ShowFooter = true;
            }
            this.leftNavigationButton.Click += LeftNavigationButton_Click;
            this.rightNavigationButton.Click += RightNavigationButton_Click;
            this.navigatorDateTimePicker.Value = DateTime.Today;

            this.navigatorDateTimePicker.DateTimePickerElement.CalendarSize = new Size(340, 420);
        }
        #endregion

        #region Events
        private void NavigatorDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            this.dateLabel.Text = this.navigatorDateTimePicker.Value.ToString("dd/MM/yyyy");
            if (this.navigatorDateTimePicker.Value == DateTime.Today)
            {
                this.dateLabel.Text += " Ajourd'hui";
            }
        }

        private void RightNavigationButton_Click(object sender, EventArgs e)
        {
            this.navigatorDateTimePicker.Value = this.navigatorDateTimePicker.Value.AddDays(1);
        }

        private void LeftNavigationButton_Click(object sender, EventArgs e)
        {
            this.navigatorDateTimePicker.Value = this.navigatorDateTimePicker.Value.AddDays(-1);
        }
        #endregion

        #region Properties
        public DateTime CurrentDate
        {
            get
            {
                return this.navigatorDateTimePicker.Value;
            }
        }

        public RadButton LeftNavigationButton
        {
            get
            {
                return this.leftNavigationButton;
            }
        }

        public RadButton RightNavigationButton
        {
            get
            {
                return this.rightNavigationButton;
            }
        }

        public RadLabel DateLabel
        {
            get
            {
                return this.dateLabel;
            }
        }

        public RadDateTimePicker DateTimePicker
        {
            get
            {
                return this.navigatorDateTimePicker;
            }
        }

        #endregion

        #region Overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            calendarGlyph.ForeColor = Utilities.ViewUtilities.MainThemeColor;
        }
        #endregion
    }
}
