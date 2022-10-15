using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SampleRegistrationForm.Core.IRepository;
using SampleRegistrationForm.Core.Model;
using SampleRegistrationForm.Entity;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace SampleRegistrationForm.Repository
{
    public class RegistrationRepository : IRegistrationRepository
    {
        public RegistrationFormContext entity;
        public RegistrationRepository(RegistrationFormContext context)
        {
            entity = context;
        }
        #region Assign
        public RegistrationModel EditMethod(int id)
        {
            RegistrationModel registrationModel = new RegistrationModel();
            var data = entity.FormModel.Where(x => x.User_Id == id).SingleOrDefault();
            registrationModel.UserId = data.User_Id;
            registrationModel.FirstName = data.First_Name;
            registrationModel.LastName = data.Last_Name;
            registrationModel.UserGender = data.User_Gender;
            registrationModel.UserQualification = data.User_Qualification;
            registrationModel.PhoneNo = data.Phone_No;
            registrationModel.UserAddress = data.User_Address;
            registrationModel.UserEmail = data.User_Email;
            registrationModel.UserPassword = data.User_Password;
            registrationModel.RetypePassword = data.Retype_Password;
            entity.SaveChanges();
            return registrationModel;
        }
        #endregion


        #region CreateMethod
        public void CreateMethod(RegistrationModel registration)
        {
            if (registration != null)
            {
                if (registration.UserId==0)
                {
                    //database model
                    FormModel info = new FormModel();
                    //info.User_Id = Registration.UserId;
                    info.First_Name = registration.FirstName;
                    info.Last_Name = registration.LastName;
                    info.User_Qualification = registration.UserQualification;
                    info.User_Gender = registration.UserGender;
                    info.User_Address = registration.UserAddress;
                    info.Phone_No = registration.PhoneNo;
                    info.User_Email = registration.UserEmail;
                    info.User_Password = registration.UserPassword;
                    info.Retype_Password = registration.RetypePassword;
                    entity.Add(info);
                    entity.SaveChanges();
                }
                else
                {
                    var value = entity.FormModel.Where(x => x.User_Id == registration.UserId).SingleOrDefault();
                    if (value != null)
                    {
                        value.First_Name = registration.FirstName;
                        value.Last_Name = registration.LastName;
                        value.User_Gender = registration.UserGender;
                        value.Phone_No = registration.PhoneNo;
                        value.User_Address = registration.UserAddress;
                        value.User_Email = registration.UserEmail;
                        value.User_Qualification = registration.UserQualification;
                        value.User_Password = registration.UserPassword;
                        value.Retype_Password = registration.RetypePassword;
                        value.Updated_TimeStamp = DateTime.Now;
                        entity.SaveChanges();
                    }
                }
            }
        }
            #endregion


           
        #region EditMethod
            //public void EditMethod(RegistrationModel model)
            //{

            //    var value = entity.FormModel.Where(x => x.User_Id == model.UserId).SingleOrDefault();
            //    if (value != null)
            //    {

            //        value.First_Name = model.FirstName;
            //        value.Last_Name = model.LastName;
            //        value.User_Gender = model.UserGender;
            //        value.Phone_No = model.PhoneNo;
            //        value.User_Address = model.UserAddress;
            //        value.User_Email = model.UserEmail;
            //        value.User_Qualification = model.UserQualification;
            //        value.User_Password = model.UserPassword;
            //        value.Retype_Password = model.RetypePassword;
            //        value.Updated_TimeStamp = DateTime.Now;
            //        entity.SaveChanges();
            //    }
            //}
            #endregion


            
        #region ListMethod
            public List<RegistrationModel> ListMethod()
            {
                List<RegistrationModel> model = new List<RegistrationModel>();
                var data = entity.FormModel.Where(x => x.Is_Deleted == false).ToList();

                foreach (var item in data)
                {
                    RegistrationModel registrationModel = new RegistrationModel();
                    registrationModel.UserId = item.User_Id;
                    registrationModel.FirstName = item.First_Name;
                    registrationModel.LastName = item.Last_Name;
                    registrationModel.UserGender = item.User_Gender;
                    registrationModel.UserQualification = item.User_Qualification;
                    registrationModel.PhoneNo = item.Phone_No;
                    registrationModel.UserAddress = item.User_Address;
                    registrationModel.UserEmail = item.User_Email;
                    registrationModel.UserPassword = item.User_Password;
                    registrationModel.RetypePassword = item.Retype_Password;
                    model.Add(registrationModel);

                }
                return model;
            }
            #endregion


           
        #region DeleteMethod
            public void DeleteMethod(int id)
            {
                var value = entity.FormModel.Where(x => x.User_Id == id).SingleOrDefault();
                if (value != null)
                {
                    value.Is_Deleted = true;
                    entity.SaveChanges();
                }

            }
            #endregion
        }
    }
