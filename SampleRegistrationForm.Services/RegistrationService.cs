using SampleRegistrationForm.Core.IRepository;
using SampleRegistrationForm.Core.IService;
using SampleRegistrationForm.Core.Model;
using SampleRegistrationForm.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleRegistrationForm.Services
{
    public class RegistrationService:IRegistrationService
    {
        private readonly IRegistrationRepository entry;

        public RegistrationService(IRegistrationRepository UserRepository)
        {
            entry = UserRepository;
        }
        #region Create
        public void CreateMethod(RegistrationModel Registration)
        {
            //business condition
            if (Registration.FirstName != string.Empty && Registration.FirstName != string.Empty)
            {
                entry.CreateMethod(Registration);
            }
        }
        #endregion

        #region Edit
        //public void EditMethod(RegistrationModel model)
        //{
        //    entry.EditMethod(model);
        //}
        public RegistrationModel EditMethod(int id)
        {
            return entry.EditMethod(id);
        }
        #endregion

        #region List
        public List<RegistrationModel> ListMethod()
        {

           return entry.ListMethod();
        }
        #endregion

        #region Delete
        public void DeleteMethod(int id)
        {
            entry.DeleteMethod(id);
        }
        #endregion
    }
}
