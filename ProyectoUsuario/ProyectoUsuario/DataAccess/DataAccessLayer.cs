using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoUsuario.Models;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ProyectoUsuario.DataAccess
{
	public class DataAccessLayer
	{

        public string InsertData(UserDetailsModel objcust)
        {
            SqlConnection con = null;

            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_User", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@CustomerID", 0);    
                cmd.Parameters.AddWithValue("@Usuario", objcust.Usuario);
                cmd.Parameters.AddWithValue("@Nombre", objcust.Nombre);
                cmd.Parameters.AddWithValue("@Direccion", objcust.Direccion);
                cmd.Parameters.AddWithValue("@IdRol", objcust.IdRol);
                cmd.Parameters.AddWithValue("@Query", 1);
                con.Open();
                result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }
        public string UpdateData(UserDetailsModel objcust)
        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_User", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", objcust.Id);
                cmd.Parameters.AddWithValue("@Usuario", objcust.Usuario);
                cmd.Parameters.AddWithValue("@Nombre", objcust.Nombre);
                cmd.Parameters.AddWithValue("@Direccion", objcust.Direccion);
                cmd.Parameters.AddWithValue("@IdRol", objcust.IdRol);
                cmd.Parameters.AddWithValue("@Query", 2);
                con.Open();
                result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }
        public int DeleteData(String Id)
        {
            SqlConnection con = null;
            int result;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_User", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@Usuario", null);
                cmd.Parameters.AddWithValue("@Nombre", null);
                cmd.Parameters.AddWithValue("@Direccion", null);
                cmd.Parameters.AddWithValue("@IdRol", null);
                cmd.Parameters.AddWithValue("@Query", 3);
                con.Open();
                result = cmd.ExecuteNonQuery();
                return result;
            }
            catch
            {
                return result = 0;
            }
            finally
            {
                con.Close();
            }
        }
        public List<UserDetailsModel> Selectalldata()
        {
            SqlConnection con = null;
            DataSet ds = null;
            List<UserDetailsModel> custlist = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_User", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", null);
                cmd.Parameters.AddWithValue("@Usuario", null);
                cmd.Parameters.AddWithValue("@Nombre", null);
                cmd.Parameters.AddWithValue("@Direccion", null);
                cmd.Parameters.AddWithValue("@IdRol", null);
                cmd.Parameters.AddWithValue("@Query", 4);
                con.Open();
                Console.WriteLine("ServerVersion: {0}", con.ServerVersion);//13.00.5102
                Console.WriteLine("State: {0}", con.State);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                custlist = new List<UserDetailsModel>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    UserDetailsModel cobj = new UserDetailsModel();
                    cobj.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].ToString());
                    cobj.Usuario = ds.Tables[0].Rows[i]["Usuario"].ToString();
                    cobj.Nombre = ds.Tables[0].Rows[i]["Nombre"].ToString();
                    cobj.Direccion = ds.Tables[0].Rows[i]["Direccion"].ToString();
                    cobj.IdRol = Convert.ToInt32(ds.Tables[0].Rows[i]["IdRol"].ToString());

                    custlist.Add(cobj);
                }
                return custlist;
            }
            catch (SqlException odbcEx)
            {
                // Handle more specific SqlException exception here.  
            }
            catch (Exception ex)
            {
                // Handle generic ones here.              
            }                   
            finally
            {
                con.Close();
            }
            return custlist;

        }

        public UserDetailsModel SelectDatabyID(string Id)
        {
            SqlConnection con = null;
            DataSet ds = null;
            UserDetailsModel cobj = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_User", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@Usuario", null);
                cmd.Parameters.AddWithValue("@Nombre", null);
                cmd.Parameters.AddWithValue("@Direccion", null);
                cmd.Parameters.AddWithValue("@IdRol", null);
                cmd.Parameters.AddWithValue("@Query", 5);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    cobj = new UserDetailsModel();
                    cobj.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].ToString());
                    cobj.Usuario = ds.Tables[0].Rows[i]["Usuario"].ToString();
                    cobj.Nombre = ds.Tables[0].Rows[i]["Nombre"].ToString();
                    cobj.Direccion = ds.Tables[0].Rows[i]["Direccion"].ToString();
                    cobj.IdRol = Convert.ToInt32(ds.Tables[0].Rows[i]["IdRol"].ToString());

                }
                return cobj;
            }
            catch
            {
                return cobj;
            }
            finally
            {
                con.Close();
            }
        }
    }
} 