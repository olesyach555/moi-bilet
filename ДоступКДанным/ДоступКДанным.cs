using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace УниверсальноеПриложение.ДоступКДанным
{
    public class ДоступКДанным
    {
        private readonly string строкаПодключения;

        public ДоступКДанным()
        {
            строкаПодключения = ConfigurationManager.ConnectionStrings["СтрокаПодключения"].ConnectionString;
        }

        public DataTable ПолучитьВсеОбъекты()
        {
            DataTable таблица = new DataTable();
            using (SqlConnection соединение = new SqlConnection(строкаПодключения))
            {
                соединение.Open();
                using (SqlCommand команда = new SqlCommand("sp_ПолучитьВсеОбъекты", соединение))
                {
                    команда.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter адаптер = new SqlDataAdapter(команда))
                    {
                        адаптер.Fill(таблица);
                    }
                }
            }
            return таблица;
        }

        public DataTable ПолучитьОбъектПоИД(int id)
        {
            DataTable таблица = new DataTable();
            using (SqlConnection соединение = new SqlConnection(строкаПодключения))
            {
                соединение.Open();
                using (SqlCommand команда = new SqlCommand("sp_ПолучитьОбъектПоИД", соединение))
                {
                    команда.CommandType = CommandType.StoredProcedure;
                    команда.Parameters.AddWithValue("@ИДентификатор", id);
                    using (SqlDataAdapter адаптер = new SqlDataAdapter(команда))
                    {
                        адаптер.Fill(таблица);
                    }
                }
            }
            return таблица;
        }

        public void ВставитьОбъект(string наименование, string описание, string статус, string примечания)
        {
            using (SqlConnection соединение = new SqlConnection(строкаПодключения))
            {
                соединение.Open();
                using (SqlCommand команда = new SqlCommand("sp_ВставитьОбъект", соединение))
                {
                    команда.CommandType = CommandType.StoredProcedure;
                    команда.Parameters.AddWithValue("@Наименование", наименование);
                    команда.Parameters.AddWithValue("@Описание", описание);
                    команда.Parameters.AddWithValue("@Статус", статус);
                    команда.Parameters.AddWithValue("@Примечания", примечания);
                    команда.Parameters.Add("@НовыйИД", SqlDbType.Int).Direction = ParameterDirection.Output;
                    команда.ExecuteNonQuery();
                }
            }
        }

        public void ОбновитьОбъект(int id, string наименование, string описание, string статус, string примечания)
        {
            using (SqlConnection соединение = new SqlConnection(строкаПодключения))
            {
                соединение.Open();
                using (SqlCommand команда = new SqlCommand("sp_ОбновитьОбъект", соединение))
                {
                    команда.CommandType = CommandType.StoredProcedure;
                    команда.Parameters.AddWithValue("@ИДентификатор", id);
                    команда.Parameters.AddWithValue("@Наименование", наименование);
                    команда.Parameters.AddWithValue("@Описание", описание);
                    команда.Parameters.AddWithValue("@Статус", статус);
                    команда.Parameters.AddWithValue("@Примечания", примечания);
                    команда.ExecuteNonQuery();
                }
            }
        }

        public void УдалитьОбъект(int id)
        {
            using (SqlConnection соединение = new SqlConnection(строкаПодключения))
            {
                соединение.Open();
                using (SqlCommand команда = new SqlCommand("sp_УдалитьОбъект", соединение))
                {
                    команда.CommandType = CommandType.StoredProcedure;
                    команда.Parameters.AddWithValue("@ИДентификатор", id);
                    команда.ExecuteNonQuery();
                }
            }
        }
    }
}
