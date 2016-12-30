using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Reflection;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;

namespace TestEF6_SQLite
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Debug.WriteLine(Go());
        }

        public static string Go()
        {
            string aa = "";
            for (int i = 0; i < 100; i++)
            {
                i = i * (i - 1);
                aa = i.ToString();
            }

            return aa;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var exeConfigurationFileMap = new ExeConfigurationFileMap();
            exeConfigurationFileMap.ExeConfigFilename = @"C:\Users\James.Peng\documents\visual studio 2013\Projects\TestEF6_SQLite\TestEF6_SQLite\app.config";
            var config = ConfigurationManager.OpenMappedExeConfiguration(exeConfigurationFileMap, ConfigurationUserLevel.None);


            string ss = config.ConnectionStrings.ConnectionStrings["EsiEntities"].ConnectionString;

            using (EsiEntities db = new EsiEntities(ss))
            {
                dataGridView1.DataSource = db.Table_ObjectType.ToList();
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
          


            string myEntity = "EsiEntities";
            ////Find the app.config path
            var exeConfigurationFileMap = new ExeConfigurationFileMap();
            exeConfigurationFileMap.ExeConfigFilename = @"C:\Users\James.Peng\documents\visual studio 2013\Projects\TestEF6_SQLite\TestEF6_SQLite\app.config";
            var config = ConfigurationManager.OpenMappedExeConfiguration(exeConfigurationFileMap, ConfigurationUserLevel.None);
//            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            EntityConnectionStringBuilder efb = new EntityConnectionStringBuilder(config.ConnectionStrings.ConnectionStrings[myEntity].ConnectionString);


            efb.ProviderConnectionString = @"Data Source=D:\ECAT\Project\EIPBuilder\bin\Release\Database\ECAT\Esi.db;foreign keys=true;";

            // And update... 
            config.ConnectionStrings.ConnectionStrings[myEntity].ConnectionString = efb.ConnectionString;
            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("connectionStrings"); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
      


            string myEntity = "EsiEntities";
            //var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var exeConfigurationFileMap = new ExeConfigurationFileMap();
            exeConfigurationFileMap.ExeConfigFilename = @"C:\Users\James.Peng\documents\visual studio 2013\Projects\TestEF6_SQLite\TestEF6_SQLite\app.config";
            var config = ConfigurationManager.OpenMappedExeConfiguration(exeConfigurationFileMap, ConfigurationUserLevel.None);
            EntityConnectionStringBuilder efb = new EntityConnectionStringBuilder(config.ConnectionStrings.ConnectionStrings[myEntity].ConnectionString);


            efb.ProviderConnectionString = @"Data Source=D:\ECAT\Project\EIPBuilder\bin\Release\Database\ECAT\Esi2.db;foreign keys=true;";

            //update
            config.ConnectionStrings.ConnectionStrings[myEntity].ConnectionString = efb.ConnectionString;
            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("connectionStrings"); 
        }
    }
}
