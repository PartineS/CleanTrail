protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
{
    this.Hide();
    e.Cancel = true;
}