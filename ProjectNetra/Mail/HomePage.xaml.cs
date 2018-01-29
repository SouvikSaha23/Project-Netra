﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ImapX;
using ImapX.Authentication;
using ImapX.Collections;

namespace ProjectNetra.Mail
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public static Frame ContentFrame { get; set; }
        public HomePage()
        {
          
            InitializeComponent();
            ContentFrame = contentFrame;

            foldersList.ItemsSource = ImapService.GetFolders();

            ClearRoom();
        }

        private void ClearRoom()
        {
            StackPanel panel = new StackPanel();
            panel.Children.Add(new TextBlock
            {
                Text = "Navigate anywhere.",
                FontSize = 20,
                Width = 200,
                Height = 50
            });
            
            ContentFrame.Content = panel;
        }

        private void contentFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void foldersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = foldersList.SelectedItem as EmailFolder;

            if (item != null)
            {
                // Load the folder for its messages.
                loadFolder(item.Title);
            }
        }

        private void loadFolder(string name)
        {
            ContentFrame.Content = new FolderMessagePage(name);
        }
    }

    class EmailFolder
    {
        public string Title { get; set; }
    }
}
