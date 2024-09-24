using Emp_Details.Interface;
using Emp_Details.Models;
using Emp_Details.Utility;
using System.Data;

namespace Emp_Details.Repository
{
    public class EmpRepository : IEmpRepository
    {





        IConfiguration _configuration;
        DbAccess _DbAccess;


        public EmpRepository(IConfiguration configuration)
        {

            _configuration = configuration;
            _DbAccess = new DbAccess(_configuration);
        }




        

        public List<EmpModel> GetEmp(int Id)
        {
            try
            {
                string[] ParametersNames = { "@Id" };
                string[] ParametersValues = { Id.ToString() };

                DataSet dataSet = _DbAccess.Ds_Process("SP_GET_Employees", ParametersNames, ParametersValues);
                List<EmpModel> lst = new List<EmpModel>();
                if (dataSet.Tables.Count > 0)
                {

                    DataTable dt = dataSet.Tables[0];

                    if (dt.Rows.Count > 0)
                    {

                        foreach (DataRow row in dt.Rows)
                        {
                            var obj = new EmpModel();
                            obj.Id = Convert.ToInt32(row["Id"]);
                            obj.FirstName = Convert.ToString(row["FirstName"]);
                            obj.LastName = Convert.ToString(row["LastName"]);
                            obj.Email = Convert.ToString(row["Email"]);
                            obj.Salary = Convert.ToInt32(row["Salary"]);
                            lst.Add(obj);
                            
                        }
                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }





        public int SaveEmp(EmpModel model, string REC_TYPE)
        {
            try
            {

                string[] ename = { "@REC_TYPE", "@Id", "@FirstName", "@LastName", "@Email", "@Salary" };

                string[] evalue = { REC_TYPE, model.Id.ToString(), model.FirstName, model.LastName, model.Email, model.Salary.ToString() };
                int result = _DbAccess.int_Process("SP_CRUD_Emp_Details", ename, evalue);
                if (result > 0)
                {

                    return result;
                }
                else
                {
                    return result;
                }



            }
            catch (Exception ex)
            {
                throw;
            }


        }





        public int DeleteEmp(EmpModel model, string REC_TYPE)
        {
            try
            {

                string[] ename = { "@REC_TYPE", "@Id", "@FirstName", "@LastName", "@Email", "@Salary" };
                string[] evalue = { REC_TYPE, model.Id.ToString(), "", "", "", "", };
                int result = _DbAccess.int_Process("SP_CRUD_Emp_Details", ename, evalue);
                if (result > 0)
                {

                    return result;
                }
                else
                {
                    return result;
                }



            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
