using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using DynamixPostgreSQLHandler;
using DynamixTestApp.Entities;
using DynamixTestApp.Utilities;

namespace DynamixTestApp
{
    public partial class Master : Form
    {

        SQLHandler sqlHandler = null;
        public Master()
        {
            InitializeComponent();
            sqlHandler = new SQLHandler(AppData.ConnectionString);
            FormatGridView.ChangeGridProperties(dgvResult);

        }
        private void DisplayError(string message)
        {
            MessageBox.Show(message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }


        private void btnExecuteSQLAsDataTable_Click(object sender, EventArgs e)
        {
            try
            {
                lblTitle.Text = "Execute SQL to DataTable : GET ALL COUNTRIES";
                string query = QueryBase.GetAllFrom(eTables.country);

                DataTable dataTable = null;
                Task.Factory.StartNew(() =>
                {
                    dataTable = sqlHandler.ExecuteSQL(query);
                }).Wait();

                dgvResult.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }

        }

        private void btnExecuteAsScalarAsLong_Click(object sender, EventArgs e)
        {
            try
            {
                lblTitle.Text = "Execute As Scalar to long : GET TOTAL ACTORS (COUNT)";
                string functionName = QueryBase.Function_GetActorsCount;

                long actorsCount = 0;
                Task.Factory.StartNew(() =>
                {
                    actorsCount = sqlHandler.ExecuteAsScalar<long>(functionName);
                }).Wait();

                ICollection<ReturnData> lstData = new List<ReturnData>();
                lstData.Add(new ReturnData()
                {
                    Data = actorsCount
                });
                dgvResult.DataSource = lstData;
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }

        }

        private void btnExecuteAsScalarWithParamsAsLong_Click(object sender, EventArgs e)
        {
            try
            {
                lblTitle.Text = "Execute As Scalar Using Function With Parameter to integer : GET INVENTORY HELD BY CUSTOMER";
                string functionName = QueryBase.Function_InventoryHeldByCustomer;

                int sampleInventoryID = 2047;
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("p_inventory_id", sampleInventoryID));

                int customerID = 0;
                Task.Factory.StartNew(() =>
                {
                    customerID = sqlHandler.ExecuteAsScalar<int>(functionName, lstParams);
                }).Wait();

                ICollection<ReturnData> lstData = new List<ReturnData>();
                lstData.Add(new ReturnData()
                {
                    Data = customerID
                });
                dgvResult.DataSource = lstData;
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }
        }



        private void btnExecuteAsListUsingSQLQuery_Click(object sender, EventArgs e)
        {
            try
            {
                lblTitle.Text = "Execute As List Using SQL Query : GET LIST OF CITIES";

                string query = QueryBase.GetAllFrom(eTables.city);

                List<City> lstCities = null;
                Task.Factory.StartNew(() =>
                {
                    lstCities = sqlHandler.ExecuteAsListUsingQuery<City>(query);
                }).Wait();

                dgvResult.DataSource = lstCities;
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }
        }

        private void btnExecuteAsListUsingFunction_Click(object sender, EventArgs e)
        {
            try
            {
                lblTitle.Text = "Execute As List Using Function Name : GET LIST OF ACTORS";

                string fn_GetActors = QueryBase.Function_GetActors;


                List<Actor> lstActors = null;
                Task.Factory.StartNew(() =>
                {
                    lstActors = sqlHandler.ExecuteAsList<Actor>(fn_GetActors);
                }).Wait();

                dgvResult.DataSource = lstActors;
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }
        }

        private void btnExecuteAsListUsingFunctionAndParameters_Click(object sender, EventArgs e)
        {
            try
            {
                lblTitle.Text = "Execute As List Using Function Name And Parameters : GET LIST OF INVENTORIES USING FILM ID AND STORE ID";

                string fn_GetInventories = QueryBase.Function_GetInventories_By_FilmID_And_StoreID;

                int sample_film_ID = 1;
                int sample_store_ID = 1;

                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("p_film_id", sample_film_ID));
                lstParams.Add(new KeyValuePair<string, object>("p_store_id", sample_store_ID));

                List<Inventory> lstInventories = null;
                Task.Factory.StartNew(() =>
                {
                    lstInventories = sqlHandler.ExecuteAsList<Inventory>(fn_GetInventories, lstParams);
                }).Wait();

                dgvResult.DataSource = lstInventories;
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }
        }




        private void btnExecuteAsObjectUsingSqlQuery_Click(object sender, EventArgs e)
        {
            try
            {
                lblTitle.Text = "Execute As Object Using SQL Query : GET FILM BY ID";
                int film_id = 133;
                string query = QueryBase.GetFilmByID(film_id);

                Film film = null;
                Task.Factory.StartNew(() =>
                {
                    film = sqlHandler.ExecuteAsObjectUsingQuery<Film>(query);
                }).Wait();

                ICollection<Film> lstData = new List<Film>();
                lstData.Add(film);
                dgvResult.DataSource = lstData;
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }

        }

        private void btnExecuteAsObjectUsingFunctionName_Click(object sender, EventArgs e)
        {
            try
            {
                lblTitle.Text = "Execute As Object Using Function Name : GET CUSTOMER WHOSE ID IS 1";
                string fn_GetCustomerWithID_1 = QueryBase.Function_GetCustomerWithID_1;

                Customer customer = null;
                Task.Factory.StartNew(() =>
                {
                    customer = sqlHandler.ExecuteAsObject<Customer>(fn_GetCustomerWithID_1);
                }).Wait();

                ICollection<Customer> lstData = new List<Customer>();
                lstData.Add(customer);
                dgvResult.DataSource = lstData;
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }

        }

        private void btnExecuteAsObjectUsingFunctionNameAndParameters_Click(object sender, EventArgs e)
        {
            try
            {
                lblTitle.Text = "Execute As Object Using Function Name And Parameters : GET ACTOR DETAIL BY ID";
                string fn_GetActorDetail = QueryBase.Function_GetActorDetailByID;

                int actor_id = 1;
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("p_actor_id", actor_id));

                Actor actor = null;
                Task.Factory.StartNew(() =>
                {
                    actor = sqlHandler.ExecuteAsObject<Actor>(fn_GetActorDetail, lstParams);
                }).Wait();

                ICollection<Actor> lstData = new List<Actor>();
                lstData.Add(actor);
                dgvResult.DataSource = lstData;
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }

        }


        int count = 0;

        private void btnExecuteNonQueryUsingFunction_Click(object sender, EventArgs e)
        {
            try
            {
                lblTitle.Text = "Execute As Non Query Using Function Name : ADD NEW ACTOR";

                Forms.AddNewActor frmAddNewActor = new Forms.AddNewActor(AddNewUser);
                frmAddNewActor.ShowDialog();

                
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }
        }

        public void AddNewUser(string firstName, string lastName)
        {
            try
            {

                string fn_AddNewActor = QueryBase.Function_AddNewActor;
                count++;
                List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
                lstParams.Add(new KeyValuePair<string, object>("fname", firstName));
                lstParams.Add(new KeyValuePair<string, object>("lname", lastName));

                Actor lastAddedActor = null;
                Task.Factory.StartNew(() =>
                {
                    sqlHandler.ExecuteNonQuery(fn_AddNewActor, lstParams);
                    lastAddedActor = sqlHandler.ExecuteAsObjectUsingQuery<Actor>(QueryBase.query_GetLastActor);
                }).Wait();

                ICollection<Actor> lstData = new List<Actor>();
                lstData.Add(lastAddedActor);
                dgvResult.DataSource = lstData;

                MessageBox.Show("New actor has been added");
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }

        }


    }
}
