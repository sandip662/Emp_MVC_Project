using Emp_Details.Models;

 namespace Emp_Details.Interface
{
    public interface IEmpRepository
    {
        public List<EmpModel> GetEmp(int Id);
        public int SaveEmp(EmpModel model, string REC_TYPE);
        public int DeleteEmp(EmpModel model, string REC_TYPE);


    }
}
