namespace SPECIAL_PROJECT_2
{
    partial class PaintForm // Ensure the class name matches your main form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // PaintForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Name = "PaintForm"; // Updated to match your main form class name
            Text = "Paint Application"; // Updated to a more descriptive title
            Load += PaintForm_Load; // Ensure this matches your method
            Paint += PaintForm_Paint; // Ensure this matches your method
            MouseDown += PaintForm_MouseDown; // Ensure this matches your method
            MouseMove += PaintForm_MouseMove; // Ensure this matches your method
            MouseUp += PaintForm_MouseUp; // Ensure this matches your method
            ResumeLayout(false);
        }

        #endregion
    }
}
