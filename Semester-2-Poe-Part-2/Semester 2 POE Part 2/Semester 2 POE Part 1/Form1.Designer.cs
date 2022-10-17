namespace Semester_2_POE_Part_1
{
    partial class Form1
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
            this.upButton = new System.Windows.Forms.Button();
            this.leftButton = new System.Windows.Forms.Button();
            this.downButton = new System.Windows.Forms.Button();
            this.rightButton = new System.Windows.Forms.Button();
            this.mapDisplayTextBox = new System.Windows.Forms.TextBox();
            this.playerStatsLabel = new System.Windows.Forms.Label();
            this.EnemyStatsTextbox = new System.Windows.Forms.RichTextBox();
            this.SelectEnemyDropDownList = new System.Windows.Forms.ComboBox();
            this.attackEnemyButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // upButton
            // 
            this.upButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.upButton.Location = new System.Drawing.Point(412, 237);
            this.upButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(67, 75);
            this.upButton.TabIndex = 0;
            this.upButton.Text = "Up";
            this.upButton.UseVisualStyleBackColor = true;
            this.upButton.Click += new System.EventHandler(this.upButton_Click);
            // 
            // leftButton
            // 
            this.leftButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.leftButton.Location = new System.Drawing.Point(332, 331);
            this.leftButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(67, 75);
            this.leftButton.TabIndex = 1;
            this.leftButton.Text = "Left";
            this.leftButton.UseVisualStyleBackColor = true;
            this.leftButton.Click += new System.EventHandler(this.leftButton_Click);
            // 
            // downButton
            // 
            this.downButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.downButton.Location = new System.Drawing.Point(412, 331);
            this.downButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(67, 75);
            this.downButton.TabIndex = 2;
            this.downButton.Text = "Down";
            this.downButton.UseVisualStyleBackColor = true;
            this.downButton.Click += new System.EventHandler(this.downButton_Click);
            // 
            // rightButton
            // 
            this.rightButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rightButton.Location = new System.Drawing.Point(493, 331);
            this.rightButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(67, 75);
            this.rightButton.TabIndex = 3;
            this.rightButton.Text = "Right";
            this.rightButton.UseVisualStyleBackColor = true;
            this.rightButton.Click += new System.EventHandler(this.rightButton_Click);
            // 
            // mapDisplayTextBox
            // 
            this.mapDisplayTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mapDisplayTextBox.Font = new System.Drawing.Font("Monospac821 BT", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapDisplayTextBox.Location = new System.Drawing.Point(70, 42);
            this.mapDisplayTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mapDisplayTextBox.Multiline = true;
            this.mapDisplayTextBox.Name = "mapDisplayTextBox";
            this.mapDisplayTextBox.ReadOnly = true;
            this.mapDisplayTextBox.Size = new System.Drawing.Size(240, 361);
            this.mapDisplayTextBox.TabIndex = 4;
            // 
            // playerStatsLabel
            // 
            this.playerStatsLabel.AutoSize = true;
            this.playerStatsLabel.Location = new System.Drawing.Point(363, 42);
            this.playerStatsLabel.Name = "playerStatsLabel";
            this.playerStatsLabel.Size = new System.Drawing.Size(176, 17);
            this.playerStatsLabel.TabIndex = 5;
            this.playerStatsLabel.Text = "Player stats comes here wow";
            // 
            // EnemyStatsTextbox
            // 
            this.EnemyStatsTextbox.Location = new System.Drawing.Point(563, 42);
            this.EnemyStatsTextbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EnemyStatsTextbox.Name = "EnemyStatsTextbox";
            this.EnemyStatsTextbox.ReadOnly = true;
            this.EnemyStatsTextbox.Size = new System.Drawing.Size(127, 204);
            this.EnemyStatsTextbox.TabIndex = 6;
            this.EnemyStatsTextbox.Text = "";
            this.EnemyStatsTextbox.TextChanged += new System.EventHandler(this.EnemyStatsTextbox_TextChanged);
            // 
            // SelectEnemyDropDownList
            // 
            this.SelectEnemyDropDownList.FormattingEnabled = true;
            this.SelectEnemyDropDownList.Location = new System.Drawing.Point(571, 263);
            this.SelectEnemyDropDownList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SelectEnemyDropDownList.Name = "SelectEnemyDropDownList";
            this.SelectEnemyDropDownList.Size = new System.Drawing.Size(106, 25);
            this.SelectEnemyDropDownList.TabIndex = 7;
            this.SelectEnemyDropDownList.SelectedIndexChanged += new System.EventHandler(this.SelectEnemy_SelectedIndexChanged);
            // 
            // attackEnemyButton
            // 
            this.attackEnemyButton.Location = new System.Drawing.Point(592, 310);
            this.attackEnemyButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.attackEnemyButton.Name = "attackEnemyButton";
            this.attackEnemyButton.Size = new System.Drawing.Size(66, 25);
            this.attackEnemyButton.TabIndex = 8;
            this.attackEnemyButton.Text = "Attack";
            this.attackEnemyButton.UseVisualStyleBackColor = true;
            this.attackEnemyButton.Click += new System.EventHandler(this.attackEnemyButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(592, 356);
            this.saveButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(66, 25);
            this.saveButton.TabIndex = 9;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(592, 385);
            this.loadButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(66, 25);
            this.loadButton.TabIndex = 10;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 484);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.attackEnemyButton);
            this.Controls.Add(this.SelectEnemyDropDownList);
            this.Controls.Add(this.EnemyStatsTextbox);
            this.Controls.Add(this.playerStatsLabel);
            this.Controls.Add(this.mapDisplayTextBox);
            this.Controls.Add(this.rightButton);
            this.Controls.Add(this.downButton);
            this.Controls.Add(this.leftButton);
            this.Controls.Add(this.upButton);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Button leftButton;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.Button rightButton;
        private System.Windows.Forms.TextBox mapDisplayTextBox;
        private System.Windows.Forms.Label playerStatsLabel;
        private System.Windows.Forms.RichTextBox EnemyStatsTextbox;
        private System.Windows.Forms.ComboBox SelectEnemyDropDownList;
        private System.Windows.Forms.Button attackEnemyButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
    }
}

