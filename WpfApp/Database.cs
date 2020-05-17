using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace WpfApp
{
   public class Database
   {
        public void InitializeDB()
        {
            const string connection_string_name = "Connection";
            var connection_string = ConfigurationManager.ConnectionStrings[connection_string_name].ConnectionString;
            CreateTable(connection_string);
        }

        public const string __SqlCreateTableEmployee = @"

        if not exists( select * from dbo.sysobjects where id = object_id(N'Employee') and OBJECTPROPERTY(id, N'IsUserTable') = 1  )   CREATE TABLE [dbo].[Employee]
        (
        [Id] INT IDENTITY(1,1) NOT NULL,
        [NAME] NVARCHAR(MAX) NOT NULL,
        [AGE] INT NOT NULL
        CONSTRAINT [PK_Employee] PRIMARY KEY ([Id] ASC)
        );";

        public const string __SqlCreateTableDepartament = @"

        if not exists( select * from dbo.sysobjects where id = object_id(N'Departament') and OBJECTPROPERTY(id, N'IsUserTable') = 1  )   CREATE TABLE [dbo].[Departament]
        (
        [Id] INT IDENTITY(1,1) NOT NULL,
        [NAME] NVARCHAR(MAX) NOT NULL,        
        CONSTRAINT [PK_Departament] PRIMARY KEY ([Id])
        );";

        public  void CreateTable(string ConnectionString) 
        {
            using (var connection = new SqlConnection(ConnectionString))
            {               
                connection.Open();
                var create_table_employee = new SqlCommand(__SqlCreateTableEmployee, connection);
                create_table_employee.ExecuteNonQuery();

                var create_table_departament = new SqlCommand(__SqlCreateTableDepartament, connection);
                create_table_departament.ExecuteNonQuery();
            }
        }
   }
}
