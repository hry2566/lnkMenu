namespace lnkMenu;

partial class MainForm
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
        this.ListView0 = new System.Windows.Forms.ListView();
        this.SuspendLayout();
        //
        // ListView0
        //
        this.ListView0.MultiSelect =  false;
        this.ListView0.Text =  "ListView0";
        this.ListView0.View = System.Windows.Forms.View.SmallIcon;
        this.ListView0.Location = new System.Drawing.Point(8,8);
        this.ListView0.Name =  "ListView0";
        this.ListView0.Size = new System.Drawing.Size(192,352);
        this.ListView0.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
        this.ListView0.SelectedIndexChanged += new System.EventHandler(ListView0_SelectedIndexChanged);
        this.ListView0.MouseDown += new System.Windows.Forms.MouseEventHandler(ListView0_MouseDown);
        this.ListView0.MouseLeave += new System.EventHandler(ListView0_MouseLeave);
        //
        // form
        //
        this.KeyPreview =  true;
        this.Location = new System.Drawing.Point(16,16);
        this.Size = new System.Drawing.Size(226,415);
        this.Text =  "MainForm";
        this.Name =  "MainForm";
        this.Load += new System.EventHandler(MainForm_Load);
        this.KeyDown += new System.Windows.Forms.KeyEventHandler(MainForm_KeyDown);
        this.Controls.Add(this.ListView0);
        this.ResumeLayout(false);
    }

    #endregion

    private ListView ListView0;
}

//private void ListView0_SelectedIndexChanged(System.Object? sender, System.EventArgs e)
//{
//
//}

//private void ListView0_MouseDown(System.Object? sender, System.Windows.Forms.MouseEventArgs e)
//{
//
//}

//private void ListView0_MouseLeave(System.Object? sender, System.EventArgs e)
//{
//
//}

//private void MainForm_Load(System.Object? sender, System.EventArgs e)
//{
//
//}

//private void MainForm_KeyDown(System.Object? sender, System.Windows.Forms.KeyEventArgs e)
//{
//
//}

