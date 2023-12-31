﻿using Services.Models;
using Services.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatManagementProject
{
    public partial class Login : Form
    {
        List<Account> accounts;
        AccountHelper accountHelper = new AccountHelper();
        public Login()
        {
            InitializeComponent();

            accounts = accountHelper.GetAll();
        }

        public Account checkLogin(List<Account> accounts, String username, String password)
        {

            return accounts.FirstOrDefault(a => a.Username.Equals(username) &&
                                            a.Password.Equals(password));
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String username = txtUsername.Text;
            String password = txtPassword.Text;

            var check = checkLogin(accounts, username, password);

            if (check != null)
            {

                this.Hide();

                if (check.RoleId == 1)
                {
                    Form manager = new Manager();
                    manager.ShowDialog();
                }

                if (check.RoleId == 2)
                {
                    Form home = new Home();
                    home.ShowDialog();
                }

            }
            else
            {
                MessageBox.Show("Invalid Username or Password", "Notification",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Registration registration = new Registration();
            registration.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }
    }
}
