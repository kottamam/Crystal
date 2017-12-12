using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tv.Crystal.UI.CustomControls
{
    public partial class nPopup : Component
    {
        #region Constructor

        public nPopup()
        {
            InitializeComponent();
        }

        public nPopup(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public nPopup(Control UserControl, Control parent)//Constructor
        {
            mParent = parent; //private variable 
            mUserControl = UserControl;
            InitializeComponent();//control  designer.cs					
        }

        #endregion

        #region public variables

        public Control mUserControl;
        public Control mParent;
        public static Form parentForm;

        #endregion

        #region Enum
        
        /// <summary>
        /// For setting display location of popup
        /// </summary>
        public enum ePlacement
        {
            Left = 1,
            Right = 2,
            Top = 4,
            Bottom = 8,
            TopLeft = Top | Left,
            TopRight = Top | Right,
            BottomLeft = Bottom | Left,
            BottomRight = Bottom | Right
        };

        /// <summary>
        /// Setting popup display style
        /// </summary>
        public enum AnimationType
        {
            Fading = 0,
            PopupMenu = 1
        };

        #endregion

        #region Private variables

        ePlacement mPlacement = ePlacement.BottomRight;//popup display style(position)		
        PopupForm mForm;

        #endregion

        #region Public methods

        /// <summary>
        /// For displaying popup
        /// </summary>
        public void Show()
        {
            mForm = new PopupForm(this,mUserControl.Width);
        }
        
        public interface IPopupUserControl //interface 
        {
            bool AcceptPopupClosing();
        }

        public class PopupForm : Form//form class'ýndan receiving inheritance (Form inheritance)
        {
            const int BORDER_MARGIN = 1;
            public static bool mShowShadow;//shadow 
            Size mControlSize;
            Size mWindowSize;
            Point mNormalPos;
            Rectangle mCurrentBounds;
            nPopup mPopup;//component 
            ePlacement mPlacement;
            bool mClosing;

            public PopupForm(nPopup popup, int mWidth) //Form constructor
            {
                mPopup = popup;
                SetStyle(ControlStyles.ResizeRedraw, true);
                FormBorderStyle = FormBorderStyle.None;
                StartPosition = FormStartPosition.Manual;
                this.ShowInTaskbar = false;//Do not display task bar
                this.DockPadding.All = BORDER_MARGIN;//1 from left to right of that space
                mControlSize = mPopup.mUserControl.Size;
                mPopup.mUserControl.Dock = DockStyle.Fill;
                Controls.Add(mPopup.mUserControl);//usercontrol 
                mWindowSize.Width = mControlSize.Width + 2 * BORDER_MARGIN;
                mWindowSize.Height = mControlSize.Height + 2 * BORDER_MARGIN;
                parentForm = mPopup.mParent.FindForm();

                mPlacement = mPopup.mPlacement;

                ReLocate(mWidth); //Setting position

                Rectangle workingArea = Screen.FromControl(mPopup.mParent).WorkingArea;

                if (mNormalPos.X + this.Width > workingArea.Right)
                {
                    switch (mPlacement)//Make left and right to play
                    {
                        case ePlacement.BottomRight:
                            mPlacement = ePlacement.BottomLeft;
                            break;
                        case ePlacement.TopRight:
                            mPlacement = ePlacement.TopLeft;
                            break;
                        case ePlacement.Bottom:
                            mPlacement = ePlacement.BottomLeft;
                            break;
                        case ePlacement.Top:
                            mPlacement = ePlacement.TopLeft;
                            break;
                        case ePlacement.Right:
                            mPlacement = ePlacement.Left;
                            break;
                    }
                }
                else if (mNormalPos.X < workingArea.Left)//to the left of the screen
                {
                    switch (mPlacement)//make the correct right to play
                    {
                        case ePlacement.BottomLeft:
                            mPlacement = ePlacement.BottomRight;
                            break;
                        case ePlacement.TopLeft:
                            mPlacement = ePlacement.TopRight;
                            break;
                        case ePlacement.Bottom:
                            mPlacement = ePlacement.BottomRight;
                            break;
                        case ePlacement.Top:
                            mPlacement = ePlacement.TopRight;
                            break;
                        case ePlacement.Left:
                            mPlacement = ePlacement.Right;
                            break;
                    }
                }

                if (mNormalPos.Y + this.Height > workingArea.Bottom)//the bottom of the screen
                {
                    switch (mPlacement)//Find the top right to play
                    {
                        case ePlacement.BottomLeft:
                            mPlacement = ePlacement.TopLeft;
                            break;
                        case ePlacement.BottomRight:
                            mPlacement = ePlacement.TopRight;
                            break;
                        case ePlacement.Bottom:
                            mPlacement = ePlacement.Top;
                            break;
                        case ePlacement.Left:
                            mPlacement = ePlacement.TopLeft;
                            break;
                        case ePlacement.Right:
                            mPlacement = ePlacement.TopRight;
                            break;
                    }
                }
                else if (mNormalPos.Y < workingArea.Top)//top of the display
                {
                    switch (mPlacement)//Skip to bottom right to play
                    {
                        case ePlacement.TopLeft:
                            mPlacement = ePlacement.BottomLeft;
                            break;
                        case ePlacement.TopRight:
                            mPlacement = ePlacement.BottomRight;
                            break;
                        case ePlacement.Top:
                            mPlacement = ePlacement.Bottom;
                            break;
                        case ePlacement.Left:
                            mPlacement = ePlacement.BottomLeft;
                            break;
                        case ePlacement.Right:
                            mPlacement = ePlacement.BottomRight;
                            break;
                    }
                }
                SetFinalLocation();//popup location
                Show(); //to display popup
            }

            private void ReLocate(int mWidth)
            {
                int rH, rW;
                rH = mWindowSize.Height;
                rW = mWindowSize.Width;

                mNormalPos = mPopup.mParent.PointToScreen(new Point());

                switch (mPlacement)
                {
                    case ePlacement.Top:
                        mNormalPos.Y -= rH;
                        break;
                    case ePlacement.TopLeft:
                        mNormalPos.Y -= rH;
                        break;
                    case ePlacement.TopRight:
                        mNormalPos.Y -= rH;
                        break;
                    case ePlacement.Bottom:
                        mNormalPos.Y += mPopup.mParent.Height;
                        break;
                    case ePlacement.BottomLeft:
                        mNormalPos.Y += mPopup.mParent.Height;
                        break;
                    case ePlacement.BottomRight:
                        //mNormalPos.Y += mPopup.mParent.Height;
                        mNormalPos.Y = 150; //TresconPopup position made static
                        //mNormalPos.X = popupLeft;
                        mNormalPos.X = Screen.PrimaryScreen.WorkingArea.Width/2 - (mWidth/2);
                        break;
                    case ePlacement.Left:
                        mNormalPos.Y += (mPopup.mParent.Height - rH) / 2;
                        break;
                    case ePlacement.Right:
                        mNormalPos.Y += (mPopup.mParent.Height - rH) / 2;
                        break;
                }

                switch (mPlacement)
                {
                    case ePlacement.Left:
                        mNormalPos.X -= rW;
                        break;
                    case ePlacement.Right:
                        mNormalPos.X += mPopup.mParent.Width;
                        break;
                    case ePlacement.TopLeft:
                        mNormalPos.X += mPopup.mParent.Width - rW;
                        break;
                    case ePlacement.BottomLeft:
                        mNormalPos.X += mPopup.mParent.Width - rW;
                        break;
                    case ePlacement.Top:
                        mNormalPos.X += (mPopup.mParent.Width - rW) / 2;
                        break;
                    case ePlacement.Bottom:
                        mNormalPos.X += (mPopup.mParent.Width - rW) / 2;
                        break;
                }
            }

            protected override void OnDeactivate(EventArgs e)
            {
                base.OnDeactivate(e);

                if (mClosing == false)
                {
                    if (this.mPopup.mUserControl is IPopupUserControl)
                    {
                        mClosing = ((IPopupUserControl)(this.mPopup.mUserControl)).AcceptPopupClosing();
                    }
                    else
                    {
                        mClosing = true;
                    }

                    if (mClosing) DoClose();
                }
            }

            internal void DoClose()
            {
                try
                {
                    mPopup.mUserControl.Parent = null;
                    mPopup.mUserControl.Size = mControlSize;
                    mPopup.mForm = null;

                    if (parentForm != null)
                        parentForm.RemoveOwnedForm(this);
                    parentForm.Focus();
                    Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);
                this.StartPosition = FormStartPosition.CenterScreen;
                this.Bounds = mCurrentBounds;
            }

            private void SetFinalLocation()
            {
                AnimateForm(1);
                Invalidate();
            }

            private void AnimateForm(double progress)
            {
                //Position X and Y, forms width and height
                double[] dizi = { 0, 0, 0, 0 };//x,y,w,h				
                mCurrentBounds.X = mNormalPos.X;//formun x distance
                mCurrentBounds.Y = mNormalPos.Y;//formun y distance
                mCurrentBounds.Width = mControlSize.Width + (2 * BORDER_MARGIN);
                mCurrentBounds.Height = mControlSize.Height + (2 * BORDER_MARGIN);

                this.Bounds = mCurrentBounds;
            }
        }

        #endregion
    }
}
