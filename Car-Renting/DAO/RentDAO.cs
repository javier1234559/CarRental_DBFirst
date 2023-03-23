﻿using Car_Renting.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Renting
{
    class RentDAO : IBaseDAO<Rent>
    {
        public List<Rent> GetAllList()
        {
            List<Rent> list = new List<Rent>();
            return list;
        }


        public DataTable GetAllDataTable()
        {
            string sqlStr = string.Format("select Rents.RentId,Cars.CarName,Clients.Name,DateStart,DateEnd,State,DateDelayQuantity,HoldingCCCD,Deposit,EstimatedCost,CanceleReason,Cars.CategoryName as CategoryName from Rents, Cars, Clients where Rents.CarId = Cars.CarId and Rents.ClientId = Clients.ClientId ");
            return DbConnection.Instance.getData(sqlStr);
        }
        public Rent GetById(int id)
        {
            string sqlStr = string.Format("SELECT * FROM Rents");
            DataTable dt = DbConnection.Instance.getData(sqlStr);

            DataRow[] result = dt.Select($"RentId = {id}");
            if (result.Length > 0)
            {
                DataRow row = result[0];
                int RentId = (int)row["RentId"];
                int CarId = (int)row["CarId"];
                int ClientId = (int)row["ClientId"];
                DateTime DateStart = (DateTime)row["dateStart"];
                DateTime DateEnd = (DateTime)row["dateEnd"];
                String State = row["state"].ToString();
                bool Giu_cccd = Convert.ToBoolean(row["HoldingCCCD"]);
                int tien_coc = (int)row["Deposit"];
                int EstimatedCost = (int)row["EstimatedCost"];
                string CancellationReason;
                if (row["CanceleReason"] == null)
                {
                    CancellationReason = "";
                }
                else
                {
                    CancellationReason = row["CanceleReason"].ToString();
                }
                int date =(int) row["DateDelayQuantity"];

                Rent Rent = new Rent
                (
                    RentId,
                    CarId,
                    ClientId,
                    DateStart,
                    DateEnd,
                    date,
                    State,
                    Giu_cccd,
                    tien_coc,
                    EstimatedCost, CancellationReason
                );
                return Rent;
            }
            return null;

        }
        public int Insert(Rent entity)
        {
            string sqlStr = string.Format("INSERT INTO Rents (CarId, ClientId, DateStart, DateEnd, DateDelayQuantity, State, HoldingCCCD, Deposit, EstimatedCost) VALUES([0], [1], [2], [3], [4], [5], [6], [7], [8]); ", entity.CarId,entity.ClientId,entity.DateStart, entity.DateEnd, entity.DateDelayQuantity, entity.State, entity.HoldingCCCD, entity.Deposit, entity.EstimatedCost);
            return DbConnection.Instance.ExecuteNonQuery(sqlStr);
        }

        public int Delete(Rent entity)
        {
            string sqlStr = string.Format("delete from Cars where CarId = '{0}'", entity.CarId);
            return DbConnection.Instance.ExecuteNonQuery(sqlStr);
        }

        public int Update(Rent entity)
        {
            string sqlStr = "";
            return DbConnection.Instance.ExecuteNonQuery(sqlStr);
        }


    }
}
