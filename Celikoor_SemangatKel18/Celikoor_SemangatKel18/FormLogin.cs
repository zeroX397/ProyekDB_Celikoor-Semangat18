﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Celikoor_Library;

namespace Celikoor_Semangat18
{
    public partial class FormLogin: Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        private void FormLogin_Load(object sender, EventArgs e)
        {
            textBoxUsername.Focus();
        }

        private void linkLabelRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            FormMainMenu frm = (FormMainMenu)this.Owner;
            
            if (radioButtonEmployee.Checked)
            {  
                string uid = textBoxUsername.Text;
                string pwd = textBoxPassword.Text;
                try
                {
                    frm.userLogin = Pegawai.Login(uid, pwd);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (radioButtonConsumen.Checked)
            {
                
                string uid = textBoxUsername.Text;
                string pwd = textBoxPassword.Text;
                try
                {
                    frm.konsumLogin = Konsumen.Login(uid, pwd);
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
            if (frm.userLogin != null || frm.konsumLogin != null)
            {
                frm.Visible = true;
                this.Close();
            }
            

            //    Pegawai hasil = Pegawai.Login(textBoxUsername.Text, textBoxPassword.Text);
            //    if (hasil == null)
            //    {
            //        throw new Exception("Data Pegawai tidak ditemukan");
            //    }

            //    Console.WriteLine(hasil.Roles_Pegawai);
            //    if (hasil.Roles_Pegawai == "ADMIN")
            //    {
            //        this.DialogResult = DialogResult.OK;
            //        FormUntukAdmin form = new FormUntukAdmin();
            //        form.MdiParent = this.MdiParent;
            //        form.Show();
            //        this.Close();
            //    }
            //    if (hasil.Roles_Pegawai == "OPERATOR")
            //    {
            //        this.DialogResult = DialogResult.OK;
            //        FormUntukOperator form = new FormUntukOperator();
            //        form.MdiParent = this.MdiParent;
            //        form.Show();
            //        this.Close();
            //    }
            //    if (hasil.Roles_Pegawai == "KASIR")
            //    {
            //        this.DialogResult = DialogResult.OK;
            //        FormUntukKasir form = new FormUntukKasir();
            //        form.MdiParent = this.MdiParent;
            //        form.Show();
            //        this.Close();
            //    }
            //}
            
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
                
    }
}
