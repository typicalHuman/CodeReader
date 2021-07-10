using CodeReader.Scripts.Enums;
using System;
using System.Runtime.InteropServices;
using System.Windows;

namespace CodeReader.Scripts.View
{
    /// <summary>
    /// Interaction logic for ConfirmingWindow.xaml
    /// </summary>
    public partial class ConfirmingWindow : Window
    {
        public ConfirmingWindow()
        {
            InitializeComponent();
            App.confirmingWindowVM.WindowCloseAction = Close;
        }

        public new RelationshipType ShowDialog()
        {
            SetCoordinatesToMouse();
            base.ShowDialog();
            return App.confirmingWindowVM.RelationshipType;
        }

        private void SetCoordinatesToMouse()
        {
            Left = GetMousePosition().X;
            Top = GetMousePosition().Y;
        }

        #region GetMousePosition
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetCursorPos(ref Win32Point pt);

        [StructLayout(LayoutKind.Sequential)]
        internal struct Win32Point
        {
            public Int32 X;
            public Int32 Y;
        };
        public static Point GetMousePosition()
        {
            var w32Mouse = new Win32Point();
            GetCursorPos(ref w32Mouse);

            return new Point(w32Mouse.X, w32Mouse.Y);
        }
        #endregion
    }
  
}
