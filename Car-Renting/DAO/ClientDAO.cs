using Car_Renting.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Car_Renting
{
    class ClientDAO : IBaseDAO<Client>
    {

        public DataTable GetAllDataTable()
        {

            DataTable result = null;

            using (var db = new QLThueXe_DBEntityEntities1())
            {
                var list = db.Clients.ToList();
                result = CommonDB.ConvertListToDataTable<Client>(list);
            }
            return result;
        }

        public Client GetById(int id)
        {
            using (var db = new QLThueXe_DBEntityEntities1())
            {
                Client client = db.Clients.Find(id);
                if (client != null)
                    return client;
                else
                    return null;
            }
        }

        public Client FindIDClientByCmnd(string CMND)
        {
            using (var db = new QLThueXe_DBEntityEntities1())
            {
                var client = db.Clients.FirstOrDefault(c => c.CCCD == CMND);
                if (client != null)
                    return (Client)client;
                else
                    return null;
            }
        }

        public int Insert(Client entity)
        {
            using (var db = new QLThueXe_DBEntityEntities1())
            {
                try
                {
                    Client newClient = db.Clients.Add(entity);
                    db.SaveChanges();
                    return newClient.ClientId;
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                    return 0;
                }

            }
        }

        public int Update(Client entity)
        {
            using (var db = new QLThueXe_DBEntityEntities1())
            {
                var entry = db.Entry(entity);
                entry.State = EntityState.Modified;
                db.SaveChanges();
                return entry.Entity.ClientId;
            }
        }

        public int Delete(Client entity)
        {
            using (var db = new QLThueXe_DBEntityEntities1())
            {
                int result = 0;
                var clientToDelete = db.Clients.Find(entity.ClientId);
                if (clientToDelete != null)
                {
                    db.Clients.Remove(clientToDelete);
                    db.SaveChanges();
                    result = 1;
                }
                return result;
            }
        }
    }
}
