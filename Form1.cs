using System;
using System.Drawing;
using System.Windows.Forms;

namespace SPECIAL_PROJECT_2
{
    public enum ShapeType
    {
        Rectangle,
        Circle
    }
    public partial class PaintForm : Form
    {
        private ShapeType selectedShape; //Holds the shape
        private Color shapeColor = Color.Black; //Shape color
        private int shapeX = 50, shapeY = 50, shapeWidth = 100, shapeHeight = 100; //Shape dimensions
        private Rectangle currentShape; //Current shape being drawn
        private bool isDragging = false; //Shape is being dragged
        private Point dragStart; //Starting point for dragging

        //UI controls
        private ComboBox shapeComboBox; //Shape selection
        private ComboBox colorComboBox; //Color selection
        private TextBox xTextBox; //X position
        private TextBox yTextBox; //Y position
        private TextBox widthTextBox; //For width
        private TextBox heightTextBox; //For height
        private Button drawButton; //Draw the shape
        private Button resetButton; //Reset inputs
        private Button colorButton; //Pick color
        private ColorDialog colorDialog; //Color selection

        public PaintForm()
        {
            InitializeComponent(); //Initialize form controls
            InitializeControls(); //Controls
        }

        private void InitializeComponent() //Error with this part
        {
            this.shapeComboBox = new ComboBox();
            this.colorComboBox = new ComboBox();
            this.xTextBox = new TextBox();
            this.yTextBox = new TextBox();
            this.widthTextBox = new TextBox();
            this.heightTextBox = new TextBox();
            this.drawButton = new Button();
            this.resetButton = new Button();
            this.colorButton = new Button();
            this.colorDialog = new ColorDialog();

            this.shapeComboBox.Location = new Point(10, 10); //Shape
            this.shapeComboBox.Width = 120;
            this.shapeComboBox.Items.AddRange(new object[] { "Rectangle", "Circle" });
            this.shapeComboBox.SelectedIndex = 0;

            this.colorComboBox.Location = new Point(140, 10); //Color
            this.colorComboBox.Width = 120;
            this.colorComboBox.Items.AddRange(new object[] { "Black", "Red", "Green", "Blue", "Yellow", "Orange", "Purple" });
            this.colorComboBox.SelectedIndex = 0;

            this.xTextBox.Location = new Point(10, 40); //X location
            this.xTextBox.Width = 50;
            this.xTextBox.Text = "50";

            this.yTextBox.Location = new Point(70, 40); //Y location
            this.yTextBox.Width = 50;
            this.yTextBox.Text = "50";

            this.widthTextBox.Location = new Point(130, 40); //Width
            this.widthTextBox.Width = 50;
            this.widthTextBox.Text = "100";

            this.heightTextBox.Location = new Point(190, 40); //Height
            this.heightTextBox.Width = 50;
            this.heightTextBox.Text = "100";

            this.drawButton.Location = new Point(10, 70); //Draw part
            this.drawButton.Width = 80;
            this.drawButton.Text = "Draw";
            this.drawButton.Click += new EventHandler(drawButton_Click);

            this.resetButton.Location = new Point(100, 70); //Location part
            this.resetButton.Width = 80;
            this.resetButton.Text = "Reset";
            this.resetButton.Click += new EventHandler(resetButton_Click);

            this.colorButton.Location = new Point(190, 70); //Color Part
            this.colorButton.Width = 80;
            this.colorButton.Text = "Color";
            this.colorButton.Click += new EventHandler(colorButton_Click);

            this.ClientSize = new Size(300, 150); //Controls
            this.Controls.Add(this.shapeComboBox);
            this.Controls.Add(this.colorComboBox);
            this.Controls.Add(this.xTextBox);
            this.Controls.Add(this.yTextBox);
            this.Controls.Add(this.widthTextBox);
            this.Controls.Add(this.heightTextBox);
            this.Controls.Add(this.drawButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.colorButton);
            this.Load += new EventHandler(PaintForm_Load);
            this.Paint += new PaintEventHandler(PaintForm_Paint);
            this.MouseDown += new MouseEventHandler(PaintForm_MouseDown);
            this.MouseMove += new MouseEventHandler(PaintForm_MouseMove);
            this.MouseUp += new MouseEventHandler(PaintForm_MouseUp);
        }

        private void InitializeControls()
        {
            selectedShape = ShapeType.Rectangle; //Default to rectangle
            shapeColor = Color.Black; //Default to black
        }

        private void PaintForm_Load(object sender, EventArgs e)
        {
            InitializeControls(); //Initialize controls
        }

        private void drawButton_Click(object sender, EventArgs e)
        {
            if (ValidateInput()) //Valid input
            {
                CreateShape(); //Create shape
                this.Invalidate(); //Request a redraw
            }
        }

        private void PaintForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics; //Get graphics
            Brush brush = new SolidBrush(shapeColor); //Create brush

            //Draw the shape based on selected type
            if (selectedShape == ShapeType.Rectangle)
                g.FillRectangle(brush, currentShape);
            else if (selectedShape == ShapeType.Circle)
                g.FillEllipse(brush, currentShape);
        }

        private void CreateShape()
        {
            selectedShape = (ShapeType)shapeComboBox.SelectedIndex; //Shape area
            shapeX = int.Parse(xTextBox.Text); //Text
            shapeY = int.Parse(yTextBox.Text);
            shapeWidth = int.Parse(widthTextBox.Text);
            shapeHeight = int.Parse(heightTextBox.Text);
            currentShape = new Rectangle(shapeX, shapeY, shapeWidth, shapeHeight);
            shapeColor = GetColorFromSelection(colorComboBox.SelectedItem.ToString());
        }

        private Color GetColorFromSelection(string colorName)
        {
            return colorName switch //Color
            {
                "Red" => Color.Red,
                "Green" => Color.Green,
                "Blue" => Color.Blue,
                "Yellow" => Color.Yellow,
                "Orange" => Color.Orange,
                "Purple" => Color.Purple,
                _ => Color.Black, //Default to black
            };
        }

        private bool ValidateInput()
        {
            try
            {
                shapeX = int.Parse(xTextBox.Text); //X position
                shapeY = int.Parse(yTextBox.Text); //Y position
                shapeWidth = int.Parse(widthTextBox.Text); //Width
                shapeHeight = int.Parse(heightTextBox.Text); //Height

                if (shapeWidth <= 0 || shapeHeight <= 0) //Dimensions area
                {
                    MessageBox.Show("Width and Height must be positive");
                    return false;
                }
                return true; //Input valid
            }
            catch
            {
                MessageBox.Show("Enter valid numbers"); //Handle parsing errors
                return false;
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            ResetDefaults(); //Reset input
        }

        private void ResetDefaults() //Value reset
        {
            xTextBox.Text = "50"; //Default X position
            yTextBox.Text = "50"; //Default Y position
            widthTextBox.Text = "100"; //Default width
            heightTextBox.Text = "100"; //Default height
            shapeColor = Color.Black; //Reset shape color
            currentShape = new Rectangle(shapeX, shapeY, shapeWidth, shapeHeight); //Recreate shape
            this.Invalidate(); //Request a redraw
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK) //Color
                shapeColor = colorDialog.Color; //Set shape color
        }

        private void PaintForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (currentShape.Contains(e.Location))
            {
                isDragging = true; //Start dragging
                dragStart = e.Location; //Starting position
            }
        }

        private void PaintForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging) //Move shape
            {
                int dx = e.Location.X - dragStart.X; //Change in X
                int dy = e.Location.Y - dragStart.Y; //Change in Y
                currentShape.X += dx; //Shape position
                currentShape.Y += dy; //Shape position
                dragStart = e.Location; //Drag start point
                this.Invalidate(); //Request a redraw
            }
        }

        private void PaintForm_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false; //Stop dragging
        }
    }
}
