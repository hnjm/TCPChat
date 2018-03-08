﻿using Engine.Model.Common.Entities;
using System.Windows;

namespace UI.Dialogs
{
  public partial class CreateRoomDialog : Window
  {
    public new string Name { get; set; }
    public RoomType Type { get; set; }

    public CreateRoomDialog()
    {
      InitializeComponent();
    }

    private void Accept_Click(object sender, RoutedEventArgs e)
    {
      Name = RoomNameTextBox.Text;
      Type = VoiceRoomCheckBox.IsChecked == true ? RoomType.Voice : RoomType.Chat;

      if (string.IsNullOrEmpty(Name))
      {
        MessageBox.Show(this, "Проверьте правильность заполнения всех полей.", "TCP Chat");
        return;
      }

      DialogResult = true;
    }

    private void Cancel_Click(object sender, RoutedEventArgs e)
    {
      DialogResult = false;
    }
  }
}
