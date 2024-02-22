using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Windows.Forms.VisualStyles;
using VS = System.Windows.Forms.VisualStyles;

namespace TestTask.Controls.CheckComboBox
{
    /// <summary>
    /// Popup.
    /// </summary>
    [CLSCompliant(true)]
    [ToolboxItem(false)]
    public partial class Popup : ToolStripDropDown
    {
        internal DateTime _lastClosedTimeStamp = DateTime.Now;

        private const int Frames = 1;
        private const int Totalduration = 0; // ML : 2007-11-05 : was 100 but caused a flicker.
        private const int Frameduration = Totalduration / Frames;

        private readonly ToolStripControlHost _host;

        private Control content;
        private bool _resizableTop;
        private bool _resizableRight;

        /// <summary>
        /// Initializes a new instance of the <see cref="Popup"/> class.
        /// </summary>
        /// <param name="content">The content of the pop-up.</param>
        /// <remarks>
        /// Pop-up will be disposed immediately after disposion of the content control.
        /// </remarks>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="content" /> is.<code>null</code>.</exception>
        public Popup(Control? content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            this.content = content;
            Fade = SystemInformation.IsMenuAnimationEnabled && SystemInformation.IsMenuFadeEnabled;
            Resizable = true;
            InitializeComponent();
            AutoSize = false;
            DoubleBuffered = true;
            ResizeRedraw = true;
            _host = new ToolStripControlHost(content);
            Padding = Margin = _host.Padding = _host.Margin = Padding.Empty;
            MinSize = content.MinimumSize;
            content.MinimumSize = content.Size;
            MaxSize = content.MaximumSize;
            content.MaximumSize = content.Size;
            Size = content.Size;
            content.Location = Point.Empty;
            Items.Add(_host);
            content.Disposed += (sender, e) =>
            {
                content = null;
                Dispose(true);
            };
            content.RegionChanged += (sender, e) =>
            {
                UpdateRegion();
            };
            content.Paint += (sender, e) =>
            {
                PaintSizeGrip(e);
            };
            UpdateRegion();
        }

        /// <summary>
        /// Gets the content of the pop-up.
        /// </summary>
        public Control Content
        {
            get { return content; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="PopupControl.Popup"/> uses the fade effect.
        /// </summary>
        /// <value><c>true</c> if pop-up uses the fade effect; otherwise, <c>false</c>.</value>
        /// <remarks>To use the fade effect, the FocusOnOpen property also has to be set to <c>true</c>.</remarks>
        public bool UseFadeEffect
        {
            get => Fade;
            set
            {
                if (Fade == value)
                {
                    return;
                }

                Fade = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to focus the content after the pop-up has been opened.
        /// </summary>
        /// <value><c>true</c> if the content should be focused after the pop-up has been opened; otherwise, <c>false</c>.</value>
        /// <remarks>If the FocusOnOpen property is set to <c>false</c>, then pop-up cannot use the fade effect.</remarks>
        public bool FocusOnOpen { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether presing the alt key should close the pop-up.
        /// </summary>
        /// <value><c>true</c> if presing the alt key does not close the pop-up; otherwise, <c>false</c>.</value>
        public bool AcceptAlt { get; set; } = true;

        /// <summary>
        /// Gets a value indicating whether this <see cref="PopupControl.Popup" /> is resizable.
        /// </summary>
        /// <value><c>true</c> if resizable; otherwise, <c>false</c>.</value>
        public bool Resizable { get; internal set; }

        public VisualStyleRenderer SizeGripRenderer { get; set; }

        public bool Fade { get; set; }

        /// <summary>
        /// Gets the size that is the lower limit that <see cref="M:System.Windows.Forms.Control.GetPreferredSize(System.Drawing.Size)" /> can specify.
        /// </summary>
        /// <returns>An ordered pair of type <see cref="T:System.Drawing.Size" /> representing the width and height of a rectangle.</returns>
        public Size MinSize { get; private set; }

        /// <summary>
        /// Gets the size that is the upper limit that <see cref="M:System.Windows.Forms.Control.GetPreferredSize(System.Drawing.Size)" /> can specify.
        /// </summary>
        /// <returns>An ordered pair of type <see cref="T:System.Drawing.Size" /> representing the width and height of a rectangle.</returns>
        public Size MaxSize { get; private set; }

        public Popup OwnerPopup { get; set; }

        public Popup ChildPopup { get; set; }

        /// <summary>
        /// Gets parameters of a new window.
        /// </summary>
        /// <returns>An object of type <see cref="T:System.Windows.Forms.CreateParams" /> used when creating a new window.</returns>
        protected override CreateParams CreateParams
        {
            [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= NativeMethods.WS_EX_NOACTIVATE;
                return cp;
            }
        }

        /// <summary>
        /// Shows pop-up window below the specified control.
        /// </summary>
        /// <param name="control">The control below which the pop-up will be shown.</param>
        /// <remarks>
        /// When there is no space below the specified control, the pop-up control is shown above it.
        /// </remarks>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="control"/> is.<code>null</code>.</exception>
        public void Show(Control control)
        {
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            SetOwnerItem(control);
            Show(control, control.ClientRectangle);
        }

        /// <summary>
        /// Shows pop-up window below the specified area of specified control.
        /// </summary>
        /// <param name="control">The control used to compute screen location of specified area.</param>
        /// <param name="area">The area of control below which the pop-up will be shown.</param>
        /// <remarks>
        /// When there is no space below specified area, the pop-up control is shown above it.
        /// </remarks>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="control"/> is.<code>null</code>.</exception>
        public void Show(Control control, Rectangle area)
        {
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            SetOwnerItem(control);
            _resizableTop = _resizableRight = false;
            Point location = control.PointToScreen(new Point(area.Left, area.Top + area.Height));
            Rectangle screen = Screen.FromControl(control).WorkingArea;

            if (location.X + Size.Width > (screen.Left + screen.Width))
            {
                _resizableRight = true;
                location.X = (screen.Left + screen.Width) - Size.Width;
            }

            if (location.Y + Size.Height > (screen.Top + screen.Height))
            {
                _resizableTop = true;
                location.Y -= Size.Height + area.Height;
            }

            location = control.PointToClient(location);
            Show(control, location, ToolStripDropDownDirection.BelowRight);
        }

        /// <summary>
        /// Paints the size grip.
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs" /> instance containing the event data.</param>
        public void PaintSizeGrip(PaintEventArgs e)
        {
            if (e == null || e.Graphics == null || !Resizable)
            {
                return;
            }

            Size clientSize = content.ClientSize;
            if (Application.RenderWithVisualStyles)
            {
                if (SizeGripRenderer == null)
                {
                    SizeGripRenderer = new VS.VisualStyleRenderer(VS.VisualStyleElement.Status.Gripper.Normal);
                }

                SizeGripRenderer.DrawBackground(e.Graphics, new Rectangle(clientSize.Width - 0x10, clientSize.Height - 0x10, 0x10, 0x10));
            }
            else
            {
                ControlPaint.DrawSizeGrip(e.Graphics, content.BackColor, clientSize.Width - 0x10, clientSize.Height - 0x10, 0x10, 0x10);
            }
        }

        /// <summary>
        /// Processes the resizing messages.
        /// </summary>
        /// <param name="m">The message.</param>
        /// <returns>true, if the WndProc method from the base class shouldn't be invoked.</returns>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public bool ProcessResizing(ref Message m) => InternalProcessResizing(ref m);

        /// <summary>
        /// Processes a dialog box key.
        /// </summary>
        /// <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys" /> values that represents the key to process.</param>
        /// <returns>
        /// true if the key was processed by the control; otherwise, false.
        /// </returns>
        protected override bool ProcessDialogKey(Keys keyData)
            => AcceptAlt && ((keyData & Keys.Alt) == Keys.Alt) ? false : base.ProcessDialogKey(keyData);

        /// <summary>
        /// Updates the pop-up region.
        /// </summary>
        protected void UpdateRegion()
        {
            if (Region != null)
            {
                Region.Dispose();
                Region = null;
            }

            if (content.Region != null)
            {
                Region = content.Region.Clone();
            }
        }

        /// <summary>
        /// Adjusts the size of the owner <see cref="T:System.Windows.Forms.ToolStrip" /> to accommodate the <see cref="T:System.Windows.Forms.ToolStripDropDown" /> if the owner <see cref="T:System.Windows.Forms.ToolStrip" /> is currently displayed, or clears and resets active <see cref="T:System.Windows.Forms.ToolStripDropDown" /> child controls of the <see cref="T:System.Windows.Forms.ToolStrip" /> if the <see cref="T:System.Windows.Forms.ToolStrip" /> is not currently displayed.
        /// </summary>
        /// <param name="visible">true if the owner <see cref="T:System.Windows.Forms.ToolStrip" /> is currently displayed; otherwise, false.</param>
        protected override void SetVisibleCore(bool visible)
        {
            double opacity = Opacity;
            if (visible && Fade && FocusOnOpen)
            {
                Opacity = 0;
            }

            base.SetVisibleCore(visible);
            if (!visible || !Fade || !FocusOnOpen)
            {
                return;
            }

            for (int i = 1; i <= Frames; i++)
            {
                if (i > 1)
                {
                    Thread.Sleep(Frameduration);
                }

                Opacity = opacity * i / Frames;
            }

            Opacity = opacity;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            content.MinimumSize = Size;
            content.MaximumSize = Size;
            content.Size = Size;
            content.Location = Point.Empty;
            base.OnSizeChanged(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ToolStripDropDown.Opening" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.ComponentModel.CancelEventArgs" /> that contains the event data.</param>
        protected override void OnOpening(CancelEventArgs e)
        {
            if (content.IsDisposed || content.Disposing)
            {
                e.Cancel = true;
                return;
            }

            UpdateRegion();
            base.OnOpening(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ToolStripDropDown.Opened" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnOpened(EventArgs e)
        {
            if (OwnerPopup != null)
            {
                OwnerPopup.Resizable = false;
            }

            if (FocusOnOpen)
            {
                content.Focus();
            }

            base.OnOpened(e);
        }

        protected override void OnClosed(ToolStripDropDownClosedEventArgs e)
        {
            if (OwnerPopup != null)
            {
                OwnerPopup.Resizable = true;
            }

            base.OnClosed(e);
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            if (!Visible)
            {
                _lastClosedTimeStamp = DateTime.Now;
            }

            base.OnVisibleChanged(e);
        }

        /// <summary>
        /// Processes Windows messages.
        /// </summary>
        /// <param name="m">The Windows <see cref="T:System.Windows.Forms.Message" /> to process.</param>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
        {
            if (InternalProcessResizing(ref m, false))
            {
                return;
            }

            base.WndProc(ref m);
        }

        private void SetOwnerItem(Control control)
        {
            if (control == null)
            {
                return;
            }

            if (control is Popup)
            {
                Popup popupControl = control as Popup;
                OwnerPopup = popupControl;
                OwnerPopup.ChildPopup = this;
                OwnerItem = popupControl.Items[0];
                return;
            }

            if (control.Parent != null)
            {
                SetOwnerItem(control.Parent);
            }
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        private bool InternalProcessResizing(ref Message m, bool contentControl = true)
        {
            if (m.Msg == NativeMethods.WM_NCACTIVATE && m.WParam != IntPtr.Zero && ChildPopup != null && ChildPopup.Visible)
            {
                ChildPopup.Hide();
            }

            if (!Resizable)
            {
                return false;
            }

            if (m.Msg == NativeMethods.WM_NCHITTEST)
            {
                return OnNcHitTest(ref m, contentControl);
            }
            else if (m.Msg == NativeMethods.WM_GETMINMAXINFO)
            {
                return OnGetMinMaxInfo(ref m);
            }

            return false;
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        private bool OnGetMinMaxInfo(ref Message m)
        {
            NativeMethods.MINMAXINFO minmax = (NativeMethods.MINMAXINFO)Marshal.PtrToStructure(m.LParam, typeof(NativeMethods.MINMAXINFO));
            minmax.maxTrackSize = this.MaxSize;
            minmax.minTrackSize = this.MinSize;
            Marshal.StructureToPtr(minmax, m.LParam, false);
            return true;
        }

        private bool OnNcHitTest(ref Message m, bool contentControl)
        {
            int x = NativeMethods.LOWORD(m.LParam);
            int y = NativeMethods.HIWORD(m.LParam);
            Point clientLocation = PointToClient(new Point(x, y));

            GripBounds gripBouns = new GripBounds(contentControl ? content.ClientRectangle : ClientRectangle);
            IntPtr transparent = new IntPtr(NativeMethods.HTTRANSPARENT);

            if (_resizableTop)
            {
                if (IsResizableTop(ref m, contentControl, clientLocation, gripBouns, transparent))
                {
                    return true;
                }
            }
            else
            {
                if (IsResizableBottom(ref m, contentControl, clientLocation, gripBouns, transparent))
                {
                    return true;
                }
            }

            if (_resizableRight && gripBouns.Left.Contains(clientLocation))
            {
                m.Result = contentControl ? transparent : NativeMethods.HTLEFT;
                return true;
            }

            if (!_resizableRight && gripBouns.Right.Contains(clientLocation))
            {
                m.Result = contentControl ? transparent : NativeMethods.HTRIGHT;
                return true;
            }

            return false;
        }

        private bool IsResizableTop(ref Message message, bool contentControl, Point clientLocation, GripBounds gripBouns, IntPtr transparent)
        {
            if (_resizableRight && gripBouns.TopLeft.Contains(clientLocation))
            {
                message.Result = contentControl ? transparent : NativeMethods.HTTOPLEFT;
                return true;
            }

            if (!_resizableRight && gripBouns.TopRight.Contains(clientLocation))
            {
                message.Result = contentControl ? transparent : NativeMethods.HTTOPRIGHT;
                return true;
            }

            if (gripBouns.Top.Contains(clientLocation))
            {
                message.Result = contentControl ? transparent : NativeMethods.HTTOP;
                return true;
            }

            return false;
        }

        private bool IsResizableBottom(ref Message message, bool contentControl, Point clientLocation, GripBounds gripBouns, IntPtr transparent)
        {
            if (_resizableRight && gripBouns.BottomLeft.Contains(clientLocation))
            {
                message.Result = contentControl ? transparent : NativeMethods.HTBOTTOMLEFT;
                return true;
            }

            if (!_resizableRight && gripBouns.BottomRight.Contains(clientLocation))
            {
                message.Result = contentControl ? transparent : NativeMethods.HTBOTTOMRIGHT;
                return true;
            }

            if (gripBouns.Bottom.Contains(clientLocation))
            {
                message.Result = contentControl ? transparent : NativeMethods.HTBOTTOM;
                return true;
            }

            return false;
        }
    }
}
