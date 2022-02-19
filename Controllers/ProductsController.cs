using LabExam.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabExam.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LabExam;Integrated Security=True;";
            conn.Open();

            SqlCommand cmdShow = new SqlCommand();
            cmdShow.Connection = conn;
            cmdShow.CommandType = System.Data.CommandType.StoredProcedure;
            cmdShow.CommandText = "ShowProducts";


            List<Product> prdList = new List<Product>();
            try
            {
                SqlDataReader sdr = cmdShow.ExecuteReader();
                while (sdr.Read())
                {
                    prdList.Add(new Product { ProductId = (int)sdr["ProductId"], ProductName = sdr["ProductName"].ToString(), Rate = (int)(decimal)sdr["Rate"] ,Description = sdr["Description"].ToString(), Category = sdr["Category"].ToString() });

                }
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }
            return View(prdList);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LabExam;Integrated Security=True";
            conn.Open();

            SqlCommand cmdEdit = new SqlCommand();
            cmdEdit.Connection = conn;
            cmdEdit.CommandType = System.Data.CommandType.Text;
            cmdEdit.CommandText = "select * from Products where ProductId=@id";
            cmdEdit.Parameters.AddWithValue("@Id", id);

            Product pd = null;
            try
            {
                SqlDataReader sdr = cmdEdit.ExecuteReader();
                while (sdr.Read())
                {
                    pd = new Product
                       { ProductId = (int)sdr["ProductId"], ProductName = sdr["ProductName"].ToString(), Rate = (int)(decimal)sdr["Rate"], Description = sdr["Description"].ToString(), Category = sdr["Category"].ToString() };
                
                }
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }
            return View(pd);

        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product pd)
        {
            
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LabExam;Integrated Security=True";
                conn.Open();

                SqlCommand cmdEdit = new SqlCommand();
                cmdEdit.Connection = conn;
                cmdEdit.CommandType = System.Data.CommandType.StoredProcedure;
                cmdEdit.CommandText = "UpdateDetails";

                cmdEdit.Parameters.AddWithValue("@ProductId", pd.ProductId);
                cmdEdit.Parameters.AddWithValue("@ProductName", pd.ProductName);

                cmdEdit.Parameters.AddWithValue("@Rate", pd.Rate);

                cmdEdit.Parameters.AddWithValue("@Description", pd.Description);

                cmdEdit.Parameters.AddWithValue("@Category", pd.Category);
            try
            {
                cmdEdit.ExecuteNonQuery();
               
            }
            catch
            {
                conn.Close();
            }
            return RedirectToAction("Index");
        }

        

       
    }
}
