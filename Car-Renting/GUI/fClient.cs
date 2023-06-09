﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Renting
{
    public partial class fClient : Form
    {
        private Client client;

        ClientDAO clientdao = new ClientDAO();

        public fClient()
        {
            InitializeComponent();
            loadDataClients();
            if (Session.currentclient != null)
            {
                this.client = Session.currentclient;
            }
        }

        private void loadDataClients()
        {
            this.gvClients.DataSource = clientdao.GetAllDataTable();
        }

        private void gvClients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = gvClients.Rows[e.RowIndex];
                //Load data to modal car
                if (!Int32.TryParse(row.Cells["ClientId"].Value.ToString(), out int idclient))
                    return;
                this.client = clientdao.GetById(idclient);

                //Load data to textbox
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value.ToString();
                txtCmnd.Text = row.Cells["CCCD"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtLicence.Text = row.Cells["License"].Value.ToString();
            }
        }

        private void handleAddClient()
        {
            string clientCCCD = txtCmnd.Text;
            if (this.clientdao.FindIDClientByCmnd(clientCCCD) != null)
            {
                MessageBox.Show("Người dùng này đã tồn tại , vui lòng không thêm trùng lặp");
                MessageBox.Show("Hãy làm mới trang và nhập lại thông tin ");
                return;
            }
            else
            {
                string name = txtName.Text;
                string phone = txtPhone.Text;
                string cmnd = txtCmnd.Text;
                string email = txtEmail.Text;
                string license = txtLicence.Text;
                Client newClient = new Client();
                newClient.Name = name;
                newClient.Email = email;
                newClient.Phone = phone;
                newClient.CCCD = cmnd;
                newClient.License = license;

                clientdao.Insert(newClient);
            }

        }

        private void handleUpdateClient()
        {
            int id = this.client.ClientId;
            string name = txtName.Text;
            string phone = txtPhone.Text;
            string cmnd = txtCmnd.Text;
            string email = txtEmail.Text;
            string license = txtLicence.Text;
            Client newClient = new Client();
            newClient.ClientId = id;
            newClient.Name = name;
            newClient.Phone = phone;
            newClient.Email = email;
            newClient.CCCD = cmnd;
            newClient.License = license;
            
            if (clientdao.Update(newClient) != 0)
            {
                MessageBox.Show("cập nhật thành công !");
            }
            else
            {
                MessageBox.Show("cập nhật thất bại !");
            }

        }

        private bool checkEmptyTxt()
        {
            string name = txtName.Text;
            string phone = txtPhone.Text;
            string cmnd = txtCmnd.Text;

            if (String.IsNullOrWhiteSpace(name) || String.IsNullOrWhiteSpace(phone) || String.IsNullOrWhiteSpace(cmnd))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return true;
            }

            this.client = this.clientdao.FindIDClientByCmnd(cmnd);

            return false;
        }

        private void btnRentFromClient_Click(object sender, EventArgs e)
        {
            checkEmptyTxt();

            fNavigation form = fNavigation.getInstance();
            if (form != null)
            {
                this.Close();
                Session.currentclient = this.client;
                form.OpenChildForm(new fRent());
                form.DisableButton();
                form.leftBorderBtn.Visible = false; ;
            }
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            if (checkEmptyTxt()) return;
            handleAddClient();
            loadDataClients();
        }

        private void btnUpdateClient_Click(object sender, EventArgs e)
        {
            if (checkEmptyTxt()) return;
            handleUpdateClient();
            loadDataClients();
        }
    }
}
