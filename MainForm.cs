using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Reflection;

namespace lnkMenu;

public partial class MainForm : Form
{
    private string? path;
    private int x = System.Windows.Forms.Cursor.Position.X;
    private int y = System.Windows.Forms.Cursor.Position.Y;
    private System.Windows.Forms.Timer timer = new();
    public MainForm()
    {
        InitializeComponent();
        var asm = Assembly.GetEntryAssembly();
        using var stream = asm!.GetManifestResourceStream("icon.ico");
        this.Icon = new Icon(stream!);

        this.FormBorderStyle = FormBorderStyle.None;
        this.timer.Interval = 1000;
        this.timer.Tick += new EventHandler(TimerEvent);

        ImageList? imageList1 = new();
        ListView0.SmallImageList = imageList1;
        ListViewItem item;

        path = GetFolderPath();
        if (path == "") { return; }

        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(path);

        foreach (System.IO.FileInfo file in dir.GetFiles())
        {
            string extension = Path.GetExtension(file.Name);

            if (".lnk" == extension && !imageList1.Images.ContainsKey(file.Extension))
            {
                Icon iconForFile = SystemIcons.WinLogo;
                item = new ListViewItem(file.Name.Replace(".lnk", ""), 1);
                string targetPath = GetTargetPath(file.FullName);
                iconForFile = System.Drawing.Icon.ExtractAssociatedIcon(targetPath)!;
                imageList1.Images.Add(file.Name, iconForFile);

                item.ImageKey = file.Name;
                ListView0.Items.Add(item);
            }
        }
    }
    private void TimerEvent(Object? Object, EventArgs e)
    {
        timer.Stop();
        this.Close();
    }
    private static string GetTargetPath(string fullPath)
    {
        dynamic? shell = null;
        dynamic? lnk = null;
        try
        {
            Type? type = Type.GetTypeFromProgID("WScript.Shell");
            shell = Activator.CreateInstance(type!);
            lnk = shell!.CreateShortcut(fullPath);
            return lnk.TargetPath;
        }
        finally
        {
            if (lnk != null) Marshal.ReleaseComObject(lnk);
            if (shell != null) Marshal.ReleaseComObject(shell);
        }
    }
    private void MainForm_Load(System.Object? sender, System.EventArgs e)
    {
        Size size = this.ClientSize;
        int cx = size.Width;
        int cy = size.Height;
        this.Location = new Point(x - cx / 2, y - cy - 50);
    }
    private void ListView0_SelectedIndexChanged(System.Object? sender, System.EventArgs e)
    {
        if (ListView0.SelectedItems.Count == 0) { return; }
        if ((Control.MouseButtons & MouseButtons.Right) == MouseButtons.Right) { return; }

        ListViewItem item = ListView0.SelectedItems[0];
        string filePath = path + "/" + item.SubItems[0].Text + ".lnk";
        string targetPath = GetTargetPath(filePath);
        string extension = Path.GetExtension(targetPath);

        Process p = new Process();
        p.StartInfo.FileName = targetPath;
        p.StartInfo.Verb = "RunAs";
        p.StartInfo.UseShellExecute = true;
        p.Start();

        timer.Start();
    }
    private void MainForm_KeyDown(System.Object? sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Escape)
        {
            this.Close();
        }
    }
    private void ListView0_MouseDown(System.Object? sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            this.Visible = false;
            timer.Start();
        }
    }
    private string GetFolderPath()
    {
        StreamReader sr = new StreamReader("./lnkMenu.ini");
        string? line = sr.ReadLine();
        sr.Close();
        return line!;
    }
    private void ListView0_MouseLeave(System.Object? sender, System.EventArgs e)
    {
        this.Visible = false;
        timer.Start();
    }
}
