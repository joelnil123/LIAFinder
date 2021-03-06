﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiaFinder;
using Xamarin.Forms;

namespace LiaFinder
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetStudentAsync();
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameEntry.Text) && !string.IsNullOrWhiteSpace(ageEntry.Text))
            {
                await App.Database.SaveStudentAsync(new Student
                {
                    FirstName = nameEntry.Text,
                    LastName = nameEntry.Text,
                    StudentEmail = nameEntry.Text,
                    Age = int.Parse(ageEntry.Text)
                }) ;

                nameEntry.Text = ageEntry.Text = string.Empty;
                listView.ItemsSource = await App.Database.GetStudentAsync();
            }
        }
    }
}
