namespace First_Windows_Form_CSharp_
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            submitButton = new Button();
            TestTextBox = new TextBox();
            WeatherIcon = new PictureBox();
            City_Label = new Label();
            State_Label = new Label();
            comboBoxStates = new ComboBox();
            comboBoxCities = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)WeatherIcon).BeginInit();
            SuspendLayout();
            // 
            // submitButton
            // 
            submitButton.Location = new Point(157, 82);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(61, 23);
            submitButton.TabIndex = 6;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // TestTextBox
            // 
            TestTextBox.Location = new Point(89, 111);
            TestTextBox.Multiline = true;
            TestTextBox.Name = "TestTextBox";
            TestTextBox.ReadOnly = true;
            TestTextBox.Size = new Size(200, 50);
            TestTextBox.TabIndex = 7;
            // 
            // WeatherIcon
            // 
            WeatherIcon.Location = new Point(128, 167);
            WeatherIcon.Name = "WeatherIcon";
            WeatherIcon.Size = new Size(117, 74);
            WeatherIcon.TabIndex = 8;
            WeatherIcon.TabStop = false;
            // 
            // City_Label
            // 
            City_Label.AutoSize = true;
            City_Label.Location = new Point(58, 9);
            City_Label.Name = "City_Label";
            City_Label.Size = new Size(28, 15);
            City_Label.TabIndex = 11;
            City_Label.Text = "City";
            // 
            // State_Label
            // 
            State_Label.AutoSize = true;
            State_Label.Location = new Point(316, 9);
            State_Label.Name = "State_Label";
            State_Label.Size = new Size(33, 15);
            State_Label.TabIndex = 12;
            State_Label.Text = "State";
            // 
            // comboBoxStates
            // 
            comboBoxStates.FormattingEnabled = true;
            comboBoxStates.Items.AddRange(new object[] { "Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado", "Connecticut",
                "Delaware", "Florida", "Georgia", "Hawaii", "Idaho", "Illinois", "Indiana", "Iowa", "Kansas", "Kentucky", "Louisiana",
                "Maine", "Maryland", "Massachusetts", "Michigan", "Minnesota", "Mississippi", "Missouri", "Montana", "Nebraska",
                "Nevada", "New Hampshire", "New Jersey", "New Mexico", "New York", "North Carolina", "North Dakota", "Ohio",
                "Oklahoma", "Oregon", "Pennsylvania", "Rhode Island", "South Carolina", "South Dakota", "Tennessee",
                "Texas", "Utah", "Vermont", "Virginia", "Washington", "West Virginia", "Wisconsin", "Wyoming" });
            comboBoxStates.Location = new Point(251, 27);
            comboBoxStates.Name = "comboBoxStates";
            comboBoxStates.Size = new Size(121, 23);
            comboBoxStates.TabIndex = 14;
            comboBoxStates.TabStop = false;
            // 
            // comboBoxCities
            // 
            comboBoxCities.FormattingEnabled = true;
            comboBoxCities.Items.AddRange(new object[] { "Albany", "Annapolis", "Atlanta", "Augusta", "Austin", "Baton Rouge", "Bismarck", "Boise",
            "Boston", "Carson City", "Charleston", "Cheyenne", "Columbia", "Columbus", "Concord", "Denver", "Des Moines", "Dover", "Frankfort",
            "Harrisburg", "Hartford", "Helena", "Honolulu", "Indianapolis", "Jackson", "Jefferson City", "Juneau", "Lansing", "Lincoln",
            "Little Rock", "Madison", "Montgomery", "Montpelier", "Nashville", "Oklahoma City", "Olympia", "Phoenix", "Pierre", "Providence",
            "Raleigh", "Richmond", "Sacramento", "Salem", "Salt Lake City", "Santa Fe", "Springfield", "St. Paul", "Tallahassee", "Topeka",
            "Trenton" });
            comboBoxCities.Location = new Point(12, 27);
            comboBoxCities.Name = "comboBoxCities";
            comboBoxCities.Size = new Size(121, 23);
            comboBoxCities.TabIndex = 15;
            comboBoxCities.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 361);
            Controls.Add(comboBoxCities);
            Controls.Add(comboBoxStates);
            Controls.Add(State_Label);
            Controls.Add(City_Label);
            Controls.Add(WeatherIcon);
            Controls.Add(TestTextBox);
            Controls.Add(submitButton);
            Name = "Form1";
            Text = "Test Weather App";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)WeatherIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button submitButton;
        private TextBox TestTextBox;
        private PictureBox WeatherIcon;
        private Label City_Label;
        private Label State_Label;
        private ComboBox comboBoxStates;
        private ComboBox comboBoxCities;
    }
}
