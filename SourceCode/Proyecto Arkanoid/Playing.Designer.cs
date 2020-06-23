using System.ComponentModel;

namespace Proyecto_Arkanoid
{
    partial class Playing
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Proyecto_Arkanoid.Playing));
            this.game1 = new Proyecto_Arkanoid.Game();
            this.SuspendLayout();
            this.game1.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("game1.BackgroundImage")));
            this.game1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.game1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.game1.Location = new System.Drawing.Point(0, 0);
            this.game1.Name = "game1";
            this.game1.Size = new System.Drawing.Size(800, 450);
            this.game1.TabIndex = 0;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.game1);
            this.Name = "Playing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Playing";
            this.ResumeLayout(false);
        }

        private Proyecto_Arkanoid.Game game1;

        #endregion
    }
}