﻿using System;
using System.Linq;
using Chat.Client.ViewModels;

namespace Chat.Client.Components;

public partial class Message : UserControl
{
    public Message()
    {
        InitializeComponent();
        
        DataContextChanged += ((sender, args) =>
        {
            if (DataContext is not MessageListViewModel viewModel) return;

            for (int i = 0; i < 100; i++)
            {
                viewModel.MessageLists.Add(new MessageList()
                {
                    Avatar = "",
                    Description = "",
                    Id = Guid.NewGuid(),
                    Name = "测试",
                });
            }

            UserListBox.SelectedItem = viewModel.MessageLists.First();
        });
    }
    
    private MessageListViewModel ViewModel => (MessageListViewModel) DataContext;
    
}