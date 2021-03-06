﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory
{
    public partial class LoadJobInformation : Form
    {
        Form_Main parent;
        List<Job> northshorejobs;
        List<Job> northcladjobs;
        List<Job> current;
        List<Job> FacadeSupplyjobs;

        public LoadJobInformation()
        {
            InitializeComponent();
            northshorejobs = new List<Job>();
            northcladjobs = new List<Job>();
            current = new List<Job>();
            FacadeSupplyjobs = new List<Job>();

            statuscmb.Text = "Open";
            LoadNorthshoreJobs();
            LoadNorthcladJobs();
            LoadFacadeSupplyJobs();
        }

        public void init(Form_Main p)
        {
            parent = p;
        }

        private void LoadFacadeSupplyJobs()
        {
            FacadeSupplyjobs.Clear();

            string[] folders = System.IO.Directory.GetDirectories(@"O:\Job file - Facade Supply\", "*", System.IO.SearchOption.TopDirectoryOnly);
            for (int i = 0; i < folders.Length; i++)
            {
                Job job = new Job();
                job.name = folders[i];
                job.open = true;
                FacadeSupplyjobs.Add(job);
            }

            string[] closedfolders;
			try
			{
				string[] closedfolderyears = System.IO.Directory.GetDirectories(@"O:\Job file - Facade Supply\1 - Facade CLOSED jobs\", "*", System.IO.SearchOption.TopDirectoryOnly);
				for (int i = 0; i < closedfolderyears.Length; i++)
				{
					closedfolders = System.IO.Directory.GetDirectories(closedfolderyears[i] + @"\", "*", System.IO.SearchOption.TopDirectoryOnly);
					for (int j = 0; j < closedfolders.Length; j++)
					{
						Job job = new Job();
						job.name = closedfolders[j];
						job.open = false;
						FacadeSupplyjobs.Add(job);
					}
				}
			}
			catch (Exception e) { }


			CleanJobs(FacadeSupplyjobs);
        }

        private void LoadNorthcladJobs()
        {
            northcladjobs.Clear();

            string[] folders = System.IO.Directory.GetDirectories(@"O:\Job file - NORTHCLAD\", "*", System.IO.SearchOption.TopDirectoryOnly);
            for(int i = 0; i < folders.Length; i++)
            {
                Job job = new Job();
                job.name = folders[i];
                job.open = true;
                northcladjobs.Add(job);
            }

            string[] closedfolders;
			try
			{
				string[] closedfolderyears = System.IO.Directory.GetDirectories(@"O:\Job file - NORTHCLAD\1-NorthClad Closed Jobs\2017 NorthClad Closed Jobs\", "*", System.IO.SearchOption.TopDirectoryOnly);
				for (int i = 0; i < closedfolderyears.Length; i++)
				{
					closedfolders = System.IO.Directory.GetDirectories(closedfolderyears[i] + @"\", "*", System.IO.SearchOption.TopDirectoryOnly);
					for (int j = 0; j < closedfolders.Length; j++)
					{
						Job job = new Job();
						job.name = closedfolders[j];
						job.open = false;
						northcladjobs.Add(job);
					}
				}
			}
			catch (Exception e) { }


            CleanJobs(northcladjobs);
        }

        private void LoadNorthshoreJobs()
        {
            northshorejobs.Clear();

            string[] folders = System.IO.Directory.GetDirectories(@"X:\Open Jobs\", "*", System.IO.SearchOption.TopDirectoryOnly);
            for (int i = 0; i < folders.Length; i++)
            {
                Job job = new Job();
                job.name = folders[i];
                job.open = true;
                northshorejobs.Add(job);
            }

            string[] closedfolders;
			try
			{
				string[] closedfolderyears = System.IO.Directory.GetDirectories(@"X:\Closed Jobs\", "*", System.IO.SearchOption.TopDirectoryOnly);
				for (int i = 0; i < closedfolderyears.Length; i++)
				{
					closedfolders = System.IO.Directory.GetDirectories(closedfolderyears[i] + @"\", "*", System.IO.SearchOption.TopDirectoryOnly);
					for (int j = 0; j < closedfolders.Length; j++)
					{
						Job job = new Job();
						job.name = closedfolders[j];
						job.open = false;
						northshorejobs.Add(job);
					}
				}
			}
			catch (Exception e) { }


			/*
            for(int i = 0; i < northshorejobs.Count; i++)
            {
                string[] removepathfromname = northshorejobs[i].name.Split('\\');
                northshorejobs[i].name = removepathfromname[removepathfromname.Length - 1];

                if(northshorejobs[i].name.Contains("(") && northshorejobs[i].name.Contains(")"))
                {
                    string[] removenumberfromname = northshorejobs[i].name.Split('(');
                    string number = removenumberfromname[removenumberfromname.Length - 1];
                    northshorejobs[i].name = removenumberfromname[0];
                    northshorejobs[i].number = number.Replace(")", "");
                }
                else
                {
                    northshorejobs[i].number = null;
                }
            }
            */

			CleanJobs(northshorejobs);
        }

        private void CleanJobs(List<Job> jobs)
        {
            for (int i = 0; i < jobs.Count; i++)
            {
                string[] removepathfromname = jobs[i].name.Split('\\');
                jobs[i].name = removepathfromname[removepathfromname.Length - 1];

                if (jobs[i].name.Contains("(") && jobs[i].name.Contains(")"))
                {
                    string[] removenumberfromname = jobs[i].name.Split('(');
                    string number = removenumberfromname[removenumberfromname.Length - 1];
                    jobs[i].name = removenumberfromname[0];
                    jobs[i].number = number.Replace(")", "");
                }
                else
                {
                    jobs[i].number = null;
                }
            }
        }

        private void companycmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadInit();
        }

        private void statuscmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadInit();
        }

        private void okbtn_Click(object sender, EventArgs e)
        {
            if(resultlistbox.SelectedIndex >= 0)
            {
                parent.SetJobFromLoader(current[resultlistbox.SelectedIndex].name, current[resultlistbox.SelectedIndex].number);
                this.Close();
            }
        }

        private void LoadInit()
        {
            if (companycmb.Text == "Northshore")
            {
                LoadJobs(northshorejobs, statuscmb.Text == "Open");
            }
            else if (companycmb.Text == "Northclad")
            {
                LoadJobs(northcladjobs, statuscmb.Text == "Open");
            }
            else if (companycmb.Text == "Facade Supply")
            {
                LoadJobs(FacadeSupplyjobs, statuscmb.Text == "Open");
            }
        }

        private void LoadJobs(List<Job> jobs, bool open)
        {
            current.Clear();
            resultlistbox.Items.Clear();
            
            int count = 0;
            for (int i = 0; i < jobs.Count; i++)
            {
                if (open == jobs[i].open && jobs[i].number != null)
                {
                    resultlistbox.Items.Add(jobs[i].number + "  -  " + jobs[i].name);
                    count++;
                    current.Add(jobs[i]);
                }
            }
            //resultlistbox.Sorted = true;
            countlbl.Text = "Count: " + count;
        }

        private sealed class Job
        {
            public string name;
            public string number;
            public bool open;
        }

        private void LoadJobInformation_Load(object sender, EventArgs e)
        {

        }
    }
}
