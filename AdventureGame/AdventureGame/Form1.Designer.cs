namespace AdventureGame;

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
        outputTB = new TextBox();
        EBtn = new Button();
        NBtn = new Button();
        WBtn = new Button();
        SBtn = new Button();
        LookBtn = new Button();
        SuspendLayout();
        // 
        // outputTB
        // 
        outputTB.Location = new Point(12, 12);
        outputTB.Multiline = true;
        outputTB.Name = "outputTB";
        outputTB.Size = new Size(557, 257);
        outputTB.TabIndex = 0;
        // 
        // EBtn
        // 
        EBtn.Location = new Point(494, 309);
        EBtn.Name = "EBtn";
        EBtn.Size = new Size(75, 23);
        EBtn.TabIndex = 1;
        EBtn.Text = "E";
        EBtn.UseVisualStyleBackColor = true;
        EBtn.Click += EBtn_Click;
        // 
        // NBtn
        // 
        NBtn.Location = new Point(454, 280);
        NBtn.Name = "NBtn";
        NBtn.Size = new Size(75, 23);
        NBtn.TabIndex = 2;
        NBtn.Text = "N";
        NBtn.UseVisualStyleBackColor = true;
        NBtn.Click += NBtn_Click;
        // 
        // WBtn
        // 
        WBtn.Location = new Point(400, 309);
        WBtn.Name = "WBtn";
        WBtn.Size = new Size(75, 23);
        WBtn.TabIndex = 3;
        WBtn.Text = "W";
        WBtn.UseVisualStyleBackColor = true;
        WBtn.Click += WBtn_Click;
        // 
        // SBtn
        // 
        SBtn.Location = new Point(454, 338);
        SBtn.Name = "SBtn";
        SBtn.Size = new Size(75, 23);
        SBtn.TabIndex = 4;
        SBtn.Text = "S";
        SBtn.UseVisualStyleBackColor = true;
        SBtn.Click += SBtn_Click;
        // 
        // LookBtn
        // 
        LookBtn.BackColor = SystemColors.ControlLight;
        LookBtn.Location = new Point(12, 275);
        LookBtn.Name = "LookBtn";
        LookBtn.Size = new Size(75, 23);
        LookBtn.TabIndex = 5;
        LookBtn.Text = "Look";
        LookBtn.UseVisualStyleBackColor = true;
        LookBtn.Click += LookBtn_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(581, 382);
        Controls.Add(LookBtn);
        Controls.Add(SBtn);
        Controls.Add(WBtn);
        Controls.Add(NBtn);
        Controls.Add(EBtn);
        Controls.Add(outputTB);
        Name = "Form1";
        Text = "Form1";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox outputTB;
    private Button EBtn;
    private Button NBtn;
    private Button WBtn;
    private Button SBtn;
    private Button LookBtn;
}
