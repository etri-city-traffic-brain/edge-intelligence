using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Common
{

    public class CustomProgressBar : ProgressBar
    {
        public enum ProgressBarKind
        {
            Vertical,
            Horizontal
        }        

        [Description("텍스트 폰트를 설정 합니다."), Category("Additional Options")]
        public Font _TextFont = new Font("굴림", 11, FontStyle.Regular); 
        public Font TextFont
        {
            get
            {
                return _TextFont;
            }
            set
            {
                _TextFont = value;
            }
        }
        private SolidBrush _textColourBrush = (SolidBrush)Brushes.Black;
        [Category("텍스트 색상을 설정 합니다.")]
        public Color TextColor
        {
            get
            {
                return _textColourBrush.Color;
            }
            set
            {
                _textColourBrush.Dispose();
                _textColourBrush = new SolidBrush(value);
            }
        }

        private string _text = string.Empty;

        [Description("사용자 텍스트 지정합니다."), Category("Additional Options"), Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public string CustomText
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                Invalidate();//redraw component after change value from VS Properties section
            }
        }

        private SolidBrush _progressColourBrush = (SolidBrush)Brushes.ForestGreen;
        [Description("Progress Bar 색상을 설정합니다."), Category("Additional Options"), Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public Color ProgressColor
        {
            get
            {
                return _progressColourBrush.Color;
            }
            set
            {
                _progressColourBrush.Dispose();
                _progressColourBrush = new SolidBrush(value);
            }
        }

        private ProgressBarKind _ProgressKind = ProgressBarKind.Horizontal;
        [Description("Progress Bar 방향을 설정 합니다."), Category("Additional Options"), Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public ProgressBarKind ProgressKind
        {
            get
            {
                return _ProgressKind;
            }
            set
            {
                _ProgressKind = value;
            }
        }

        private int _ProgressDashed = 0;
        [Description("Progress Bar Dash 값을 설정합니다."), Category("Additional Options"), Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public int ProgressDashed
        {
            get { return _ProgressDashed; }
            set { _ProgressDashed = value; }
        }

        private bool _ShowText = false;
        [Description("텍스트를 나타냅니다."), Category("Additional Options"), Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public bool ShowText
        {
            get { return _ShowText; }
            set { _ShowText = value; }
        }

        private bool _PercentView = false;
        [Description("%를 표출 합니다."), Category("Additional Options"), Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public bool PercentView
        {
            get { return _PercentView; }
            set { _PercentView = value; }
        }

        public CustomProgressBar()
        {
            Value = Minimum;
            FixComponentBlinking();
        }

        private void FixComponentBlinking()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            DrawProgressBar(g);

            DrawStringIfNeeded(g);
        }

        private void DrawProgressBar(Graphics g)
        {
            Rectangle rect = ClientRectangle;

            if(_ProgressKind == ProgressBarKind.Horizontal)
            {
                ProgressBarRenderer.DrawHorizontalBar(g, rect);
                //rect.Inflate(-1, -1);

                if (Value > 0)
                {
                    if (this._ProgressDashed <= 0)
                    {
                        float width = ((float)Value / (float)Maximum) * (float)rect.Width;
                        RectangleF clip = new RectangleF(rect.X, rect.Y, width, rect.Height);
                        g.FillRectangle(_progressColourBrush, clip);
                    }
                    else
                    {
                        float OneStepWidth = this.Maximum <= 0 ? 0 : (float)rect.Width / (float)this.Maximum;
                        float StepValue = 0;
                        while(StepValue < Value)
                        {
                            float StepWith = 0;

                            if(StepValue + _ProgressDashed <= Value)
                            {
                                StepWith = OneStepWidth * (float)_ProgressDashed - 1;
                            }
                            else
                            {
                                StepWith = OneStepWidth * ((float)Value - StepValue) - 1;
                            }

                            if (StepWith <= 1)
                                StepWith = 1;

                            RectangleF clip = new RectangleF((float)rect.X + StepValue * OneStepWidth, rect.Y, StepWith, rect.Height);
                            g.FillRectangle(_progressColourBrush, clip);

                            StepValue += _ProgressDashed;
                        }
                    }
                }
            }
            else
            {
                ProgressBarRenderer.DrawVerticalBar(g, rect);
                //rect.Inflate(-1, -1);

                if (Value > 0)
                {
                    if (this._ProgressDashed <= 0)
                    {
                        float height = (((float)Value / (float)Maximum) * (float)rect.Height);
                        RectangleF clip = new RectangleF(rect.X, (float)rect.Height - height, rect.Width, height);
                        g.FillRectangle(_progressColourBrush, clip);
                    }
                    else
                    {
                        float OneStepHeight = this.Maximum <= 0 ? 0 : (float)rect.Height / (float)this.Maximum;
                        float StepValue = 0;
                        while (StepValue < Value)
                        {
                            float StepHeight = 0;

                            if (StepValue + _ProgressDashed <= Value)
                            {
                                StepHeight = OneStepHeight * (float)_ProgressDashed - 1;
                            }
                            else
                            {
                                StepHeight = OneStepHeight * ((float)Value - StepValue) - 1;
                            }

                            if (StepHeight <= 1)
                                StepHeight = 1;

                            RectangleF clip = new RectangleF((float)rect.X, ((float)rect.Height - (StepValue * OneStepHeight) - StepHeight), (float)rect.Width, StepHeight);
                            g.FillRectangle(_progressColourBrush, clip);

                            StepValue += _ProgressDashed;
                        }
                    }
                }
            }
            
        }

        private void DrawStringIfNeeded(Graphics g)
        {
            if (_ShowText == true)
            {
                string text = Value.ToString() + (_PercentView == true ? "%" : string.Empty);

                if(!string.IsNullOrEmpty(_text))
                {
                    try
                    {
                        text = string.Format(_text, text);
                    }
                    catch
                    {
                    }
                }

                SizeF len = g.MeasureString(text, TextFont);

                Point location = new Point(((Width / 2) - (int)len.Width / 2), ((Height / 2) - (int)len.Height / 2));

                g.DrawString(text, TextFont, (Brush)_textColourBrush, location);
            }
        }

    }
}
