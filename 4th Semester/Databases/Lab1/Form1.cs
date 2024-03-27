using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace l1WindowsForms
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        SqlDataAdapter daEmployer;
        SqlDataAdapter daJob;
        DataSet dset;
        BindingSource bsEmployer;
        BindingSource bsJob;
        DataRelation EmployerJob;

        SqlCommandBuilder cmdBuilder;

        string queryEmployer;
        string queryJob;

        public Form1()
        {
            InitializeComponent();
            FillData();
        }

        /*void ReloadJobTableView()
        {
            if (dset.Tables["Job"] != null)
            {
                dset.Tables["Job"].Clear();
            }
            daJob.Fill(dset, "Job");
            JobView.DataSource = bsJob;
        }*/

        void FillData()
        {
            connection = new SqlConnection(getConnectionString());
            queryEmployer = "SELECT * FROM Employer";
            queryJob = "SELECT * FROM Job";

            //creating data adapters
            daEmployer = new SqlDataAdapter(queryEmployer, connection);
            daJob = new SqlDataAdapter(queryJob, connection);
            dset = new DataSet();

            daEmployer.Fill(dset, "Employer");
            daJob.Fill(dset, "Job");

            cmdBuilder = new SqlCommandBuilder(daJob);
            //adding parent-child relationship
            dset.Relations.Add("EmployerJob", dset.Tables["Employer"].Columns["companyID"],
                dset.Tables["Job"].Columns["companyID"]);

            //filling data into grid view using data binding
            this.EmployerView.DataSource = dset.Tables["Employer"];
            this.JobView.DataSource = this.EmployerView.DataSource;
            this.JobView.DataMember = "EmployerJob";
            /*bsEmployer = new BindingSource();
            bsEmployer.DataSource = dset.Tables["Employer"];
            bsJob = new BindingSource(bsEmployer, "EmployerJob");

            this.EmployerView.DataSource = bsEmployer;
            this.JobView.DataSource = bsJob;*/

            cmdBuilder.GetUpdateCommand();
        }

        //implemented by me
        string getConnectionString()
        {
            return "Data Source=DESKTOP-56RUGQC\\SQLEXPRESS;Initial Catalog=RecruitingPlatform;"+ "Integrated Security=true;";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                daEmployer.Update(dset, "Employer");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Database update did not work\n" + exception.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(exception.ToString());
            }

            /*connection = new SqlConnection("Data Source=DESKTOP-56RUGQC\\SQLEXPRESS;Initial Catalog=RecruitingPlatform;" + "Integrated Security=true;");
            connection.Open();
            daEmployer = new SqlDataAdapter("SELECT * FROM Employer", connection);
            dset = new DataSet();
            daEmployer.Fill(dset, "Employer");
            EmployerView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            daJob = new SqlDataAdapter("SELECT * FROM Job", connection);
            dset = new DataSet();
            daJob.Fill(dset, "Job");
            JobView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            DataColumn companyIDJob = dset.Tables["Job"].Columns["companyID"];
            DataColumn companyIDEmployer = dset.Tables["Employer"].Columns["companyID"];
            //EmployerJob = new DataRelation();
            dset.Relations.Add("EmployerJob",
                dset.Tables["Employer"].Columns["companyID"],
                dset.Tables["Job"].Columns["companyID"]);

            bsEmployer = new BindingSource();
            bsEmployer.DataSource = dset;
            bsEmployer.DataMember = "Employer";

            bsJob = new BindingSource();
            bsJob.DataSource = bsEmployer;
            bsJob.DataMember = "EmployerJob";
            EmployerView.DataSource = bsEmployer;*/
        }

        /*private void label1_Click(object sender, EventArgs e)
        {
            daJob.Update(dset, "Job");
        }

        private void Table2_Click(object sender, EventArgs e)
        {

        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            daJob.Update(dset, "Job");
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand(
            "INSERT INTO Job(jobID, job_title, job_description, companyID, job_location, required_skills, application_deadline, salary_range, job_category)" +
            "VALUES (@JobID, @JobTitle, @JobDescription, @CompanyID, @JobLocation, @RequiredSkills, @ApplicationDeadline, @SalaryRange, @JobCategory)", connection);
            *//*if (jobIDText.Text.Length != 0)
            {
                try
                {
                    int job_id = Int32.Parse(jobIDText.Text);
                    if (jobCompanyIDText.Text.Length != 0)
                    {
                        int company_id = Int32.Parse(jobCompanyIDText.Text);
                        cmd.Parameters.Add("@JobID", SqlDbType.Int);
                        cmd.Parameters["@JobID"].Value = job_id;

                        cmd.Parameters.Add("@JobTitle", SqlDbType.VarChar, 50);
                        cmd.Parameters["@JobTitle"].Value = jobTitleText.Text;

                        cmd.Parameters.Add("@JobDescription", SqlDbType.VarChar, 50);
                        cmd.Parameters["@JobDescription"].Value = jobDescText.Text;

                        cmd.Parameters.Add("@CompanyID", SqlDbType.Int);
                        cmd.Parameters["@CompanyID"].Value = company_id;

                        cmd.Parameters.Add("@JobLocation", SqlDbType.VarChar, 50);
                        cmd.Parameters["@JobLocation"].Value = jobLocationText.Text;

                        cmd.Parameters.Add("@RequiredSkills", SqlDbType.VarChar, 50);
                        cmd.Parameters["@RequiredSkills"].Value = recSkillsText.Text;

                        cmd.Parameters.Add("@ApplicationDeadline", SqlDbType.Date);
                        cmd.Parameters["@ApplicationDeadline"].Value = appDeadlineText.Text;

                        cmd.Parameters.Add("@SalaryRange", SqlDbType.VarChar, 50);
                        cmd.Parameters["@SalaryRange"].Value = salaryRangeText.Text;

                        cmd.Parameters.Add("@JobCategory", SqlDbType.VarChar, 50);
                        cmd.Parameters["@JobCategory"].Value = jobCatText.Text;
                        daJob.InsertCommand = cmd;
                        daJob.InsertCommand.ExecuteNonQuery();
                        ReloadJobTableView();
                    }
                    else
                    {
                        MessageBox.Show("give a company id");
                    }
                }
                catch(FormatException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("enter a job id");
            }*//*
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Job WHERE jobID=@JobID", connection);
            *//*if (jobIDText.Text.Length != 0)
            {
                int job_id = Int32.Parse(jobCompanyIDText.Text);
                command.Parameters.Add("@JobID", SqlDbType.Int);
                command.Parameters["@JobID"].Value = job_id;
                daEmployer.DeleteCommand = command;
                int noDeletedJobs = daJob.DeleteCommand.ExecuteNonQuery();
                if (noDeletedJobs == 0)
                {
                    MessageBox.Show("no job with this id");
                }
                else
                {
                    ReloadJobTableView();
                }
            }*//*
        }

        private void JobView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void JobView_SelectionChanged(object sender, EventArgs e)
        {
            *//*if (JobView.SelectedRows.Count != 0)
            {
                DataGridViewRow selectedRow = JobView.SelectedRows[0];
                jobIDText.Text = selectedRow.Cells[0].Value.ToString();
                jobTitleText.Text = selectedRow.Cells[1].Value.ToString();
                jobDescText.Text = selectedRow.Cells[2].Value.ToString();
                recSkillsText.Text = selectedRow.Cells[3].Value.ToString();
                appDeadlineText.Text = selectedRow.Cells[4].Value.ToString();
                salaryRangeText.Text = selectedRow.Cells[5].Value.ToString();
                jobCatText.Text = selectedRow.Cells[6].Value.ToString();
            }*//*
        }

        private void EmployerView_SelectionChanged(object sender, EventArgs e)
        {
            if (EmployerView.SelectedRows.Count != 0)
            {
                DataGridViewRow selectedRow = EmployerView.SelectedRows[0];
                daEmployer.SelectCommand = new SqlCommand("SELECT * FROM Job WHERE companyID=" + selectedRow.Cells[0].Value, connection);
                //ReloadJobTableView();
            }
        }*/
    }
}
