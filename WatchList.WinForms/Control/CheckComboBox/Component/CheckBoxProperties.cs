using System.ComponentModel;

namespace WatchList.WinForms.Control.CheckComboBox.Component
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class CheckBoxProperties
    {
        private Appearance _appearance = Appearance.Normal;
        private bool _autoSize = false;
        private bool _autoCheck = true;
        private bool _autoEllipsis = false;
        private ContentAlignment _checkAlign = ContentAlignment.MiddleLeft;
        private Color _flatAppearanceBorderColor = Color.Empty;
        private int _flatAppearanceBorderSize = 1;
        private Color _flatAppearanceCheckedBackColor = Color.Empty;
        private Color _flatAppearanceMouseDownBackColor = Color.Empty;
        private Color _flatAppearanceMouseOverBackColor = Color.Empty;
        private FlatStyle _flatStyle = FlatStyle.Standard;
        private Color _foreColor = SystemColors.ControlText;
        private RightToLeft _rightToLeft = RightToLeft.No;
        private ContentAlignment _textAlign = ContentAlignment.MiddleLeft;
        private bool _threeState = false;

        public CheckBoxProperties()
        {
        }

        /// <summary>
        /// Called when any property changes.
        /// </summary>
        public event EventHandler PropertyChanged;

        [DefaultValue(Appearance.Normal)]
        public Appearance Appearance
        {
            get => _appearance;
            set
            {
                _appearance = value;
                OnPropertyChanged();
            }
        }

        [DefaultValue(true)]
        public bool AutoCheck
        {
            get => _autoCheck;
            set
            {
                _autoCheck = value;
                OnPropertyChanged();
            }
        }

        [DefaultValue(false)]
        public bool AutoEllipsis
        {
            get => _autoEllipsis;
            set
            {
                _autoEllipsis = value;
                OnPropertyChanged();
            }
        }

        [DefaultValue(false)]
        public bool AutoSize
        {
            get => _autoSize;
            set
            {
                _autoSize = true;
                OnPropertyChanged();
            }
        }

        [DefaultValue(ContentAlignment.MiddleLeft)]
        public ContentAlignment CheckAlign
        {
            get => _checkAlign;
            set
            {
                _checkAlign = value;
                OnPropertyChanged();
            }
        }

        [DefaultValue(typeof(Color), "")]
        public Color FlatAppearanceBorderColor
        {
            get => _flatAppearanceBorderColor;
            set
            {
                _flatAppearanceBorderColor = value;
                OnPropertyChanged();
            }
        }

        [DefaultValue(1)]
        public int FlatAppearanceBorderSize
        {
            get => _flatAppearanceBorderSize;
            set
            {
                _flatAppearanceBorderSize = value;
                OnPropertyChanged();
            }
        }

        [DefaultValue(typeof(Color), "")]
        public Color FlatAppearanceCheckedBackColor
        {
            get => _flatAppearanceCheckedBackColor;
            set
            {
                _flatAppearanceCheckedBackColor = value;
                OnPropertyChanged();
            }
        }

        [DefaultValue(typeof(Color), "")]
        public Color FlatAppearanceMouseDownBackColor
        {
            get => _flatAppearanceMouseDownBackColor;
            set
            {
                _flatAppearanceMouseDownBackColor = value;
                OnPropertyChanged();
            }
        }

        [DefaultValue(typeof(Color), "")]
        public Color FlatAppearanceMouseOverBackColor
        {
            get => _flatAppearanceMouseOverBackColor;
            set
            {
                _flatAppearanceMouseOverBackColor = value;
                OnPropertyChanged();
            }
        }

        [DefaultValue(FlatStyle.Standard)]
        public FlatStyle FlatStyle
        {
            get => _flatStyle;
            set
            {
                _flatStyle = value;
                OnPropertyChanged();
            }
        }

        [DefaultValue(typeof(SystemColors), "ControlText")]
        public Color ForeColor
        {
            get => _foreColor;
            set
            {
                _foreColor = value;
                OnPropertyChanged();
            }
        }

        [DefaultValue(RightToLeft.No)]
        public RightToLeft RightToLeft
        {
            get => _rightToLeft;
            set
            {
                _rightToLeft = value;
                OnPropertyChanged();
            }
        }

        [DefaultValue(ContentAlignment.MiddleLeft)]
        public ContentAlignment TextAlign
        {
            get => _textAlign;
            set
            {
                _textAlign = value;
                OnPropertyChanged();
            }
        }

        [DefaultValue(false)]
        public bool ThreeState
        {
            get => _threeState;
            set
            {
                _threeState = value;
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged() => PropertyChanged?.Invoke(this, EventArgs.Empty);
    }
}
