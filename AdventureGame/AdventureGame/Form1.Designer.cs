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
        components = new System.ComponentModel.Container();
        outputTB = new TextBox();
        EBtn = new Button();
        NBtn = new Button();
        WBtn = new Button();
        SBtn = new Button();
        LookBtn = new Button();
        InventoryBtn = new Button();
        groupBox1 = new GroupBox();
        LookAtBtn = new Button();
        inputTB = new TextBox();
        DropBtn = new Button();
        TakeBtn = new Button();
        groupBox1.SuspendLayout();
        SuspendLayout();
        // 
        // outputTB
        // 
        outputTB.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
        outputTB.Location = new Point(12, 27);
        outputTB.Multiline = true;
        outputTB.Name = "outputTB";
        outputTB.Size = new Size(846, 392);
        outputTB.TabIndex = 0;
        // 
        // EBtn
        // 
        EBtn.Location = new Point(776, 513);
        EBtn.Name = "EBtn";
        EBtn.Size = new Size(75, 23);
        EBtn.TabIndex = 4;
        EBtn.Text = "E";
        EBtn.UseVisualStyleBackColor = true;
        EBtn.Click += EBtn_Click;
        // 
        // NBtn
        // 
        NBtn.Location = new Point(736, 484);
        NBtn.Name = "NBtn";
        NBtn.Size = new Size(75, 23);
        NBtn.TabIndex = 2;
        NBtn.Text = "N";
        NBtn.UseVisualStyleBackColor = true;
        NBtn.Click += NBtn_Click;
        // 
        // WBtn
        // 
        WBtn.Location = new Point(682, 513);
        WBtn.Name = "WBtn";
        WBtn.Size = new Size(75, 23);
        WBtn.TabIndex = 3;
        WBtn.Text = "W";
        WBtn.UseVisualStyleBackColor = true;
        WBtn.Click += WBtn_Click;
        // 
        // SBtn
        // 
        SBtn.Location = new Point(736, 542);
        SBtn.Name = "SBtn";
        SBtn.Size = new Size(75, 23);
        SBtn.TabIndex = 5;
        SBtn.Text = "S";
        SBtn.UseVisualStyleBackColor = true;
        SBtn.Click += SBtn_Click;
        // 
        // LookBtn
        // 
        LookBtn.BackColor = SystemColors.ControlLight;
        LookBtn.Location = new Point(571, 513);
        LookBtn.Name = "LookBtn";
        LookBtn.Size = new Size(75, 23);
        LookBtn.TabIndex = 1;
        LookBtn.Text = "Look";
        LookBtn.UseVisualStyleBackColor = true;
        LookBtn.Click += LookBtn_Click;
        // 
        // InventoryBtn
        // 
        InventoryBtn.Location = new Point(571, 542);
        InventoryBtn.Name = "InventoryBtn";
        InventoryBtn.Size = new Size(75, 23);
        InventoryBtn.TabIndex = 7;
        InventoryBtn.Text = "Inventory";
        InventoryBtn.UseVisualStyleBackColor = true;
        InventoryBtn.Click += InventoryBtn_Click;
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(LookAtBtn);
        groupBox1.Controls.Add(inputTB);
        groupBox1.Controls.Add(DropBtn);
        groupBox1.Controls.Add(TakeBtn);
        groupBox1.Location = new Point(12, 484);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(315, 91);
        groupBox1.TabIndex = 6;
        groupBox1.TabStop = false;
        groupBox1.Text = "Select object...";
        // 
        // LookAtBtn
        // 
        LookAtBtn.Location = new Point(229, 58);
        LookAtBtn.Name = "LookAtBtn";
        LookAtBtn.Size = new Size(75, 23);
        LookAtBtn.TabIndex = 3;
        LookAtBtn.Text = "Look At";
        LookAtBtn.UseVisualStyleBackColor = true;
        LookAtBtn.Click += LookAtBtn_Click;
        // 
        // inputTB
        // 
        inputTB.Location = new Point(7, 20);
        inputTB.Name = "inputTB";
        inputTB.Size = new Size(297, 25);
        inputTB.TabIndex = 2;
        inputTB.KeyDown += inputTB_KeyDown;
        // 
        // DropBtn
        // 
        DropBtn.Location = new Point(119, 58);
        DropBtn.Name = "DropBtn";
        DropBtn.Size = new Size(75, 23);
        DropBtn.TabIndex = 1;
        DropBtn.Text = "Drop";
        DropBtn.UseVisualStyleBackColor = true;
        DropBtn.Click += DropBtn_Click;
        // 
        // TakeBtn
        // 
        TakeBtn.Location = new Point(7, 58);
        TakeBtn.Name = "TakeBtn";
        TakeBtn.Size = new Size(75, 23);
        TakeBtn.TabIndex = 0;
        TakeBtn.Text = "Take";
        TakeBtn.UseVisualStyleBackColor = true;
        TakeBtn.Click += TakeBtn_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(870, 588);
        Controls.Add(groupBox1);
        Controls.Add(InventoryBtn);
        Controls.Add(LookBtn);
        Controls.Add(SBtn);
        Controls.Add(WBtn);
        Controls.Add(NBtn);
        Controls.Add(EBtn);
        Controls.Add(outputTB);
        Name = "Form1";
        Text = "Dark Neon City...";
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
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
    private Button InventoryBtn;
    private GroupBox groupBox1;
    private TextBox inputTB;
    private Button DropBtn;
    private Button TakeBtn;
    private Button LookAtBtn;
}
