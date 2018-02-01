using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfRestService.Response;
using WcfRestService.Request;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace WcfRestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RestService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RestService.svc or RestService.svc.cs at the Solution Explorer and start debugging.
    public class RestService : IRestService
    {


        public string XMLData(string id)
        {
            return "You requested product whose id is " + id;
        }
        public string JSONData(string id)
        {
            return "You requested Product whose id is " + id;
        }

        public DataInXml XmlDetails()
        {
            DataInXml xml = new DataInXml() { id = 10, Name = "Nitesh" };
            return xml;
        }
        public DataInJson JsonDetails()
        {
            DataInJson json = new DataInJson() { id = 10, Name = "Nitesh" };
            return json;

        }

        public List<UserDetail> GetAllUser()
        {
            RestdbEntities db = new RestdbEntities();
            return db.UserDetails.ToList();
            //List<UserDetail> userList = new List<UserDetail>();
            //RestdbEntities db = new RestdbEntities();
            //var lstuser = from s in db.UserDetails select s;

            //foreach (var item in lstuser)
            //{
            //    UserDetail usr = new UserDetail();
            //    usr.id = item.id;
            //    usr.Name = item.Name;
            //    usr.City = item.City;
            //    userList.Add(usr);


            //}
            //return userList;
        }

        public UserDetail GetUserById(string Id)
        {
            var id = int.Parse(Id);
            RestdbEntities db = new RestdbEntities();
            var lstuser = from s in db.UserDetails where s.Id == id select s;
            UserDetail usr = new UserDetail();
            foreach (var item in lstuser)
            {
                usr.Id = item.Id;
                usr.Name = item.Name;
                usr.City = item.City;
            }
            return usr;

        }

        public UserResponse Create(UserDetail user)
        {
            UserResponse response = new UserResponse();
            try
            {
                RestdbEntities db = new RestdbEntities();

                UserDetail udtl = new UserDetail();


                udtl.Name = user.Name;
                udtl.City = user.City;

                db.UserDetails.Add(udtl);


                try
                {
                    int retval = db.SaveChanges();
                    if (retval > 0)
                    {
                        response.IsSuccess = true;
                        response.Message = "Success";
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.Message = "Sorry";

                    }
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                                ve.PropertyName,
                                eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                                ve.ErrorMessage);
                        }

                    }

                }

            }
            catch (Exception ex)
            {

            }

            return response;


        }

        public UserResponse Update(string id,UserDetail user)
        {
            UserResponse response = new UserResponse();
            try
            {
                RestdbEntities db = new RestdbEntities();

                UserDetail udtl = db.UserDetails.Find(Convert.ToInt32(id));
                udtl.Name = user.Name;
                udtl.City = user.City;
                db.Entry(udtl).State = EntityState.Modified;

                try
                {
                    int retval = db.SaveChanges();
                    if (retval > 0)
                    {
                        response.IsSuccess = true;
                        response.Message = "Success";
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.Message = "Sorry";

                    }
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                                ve.PropertyName,
                                eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                                ve.ErrorMessage);
                        }

                    }

                }

            }
            catch (Exception ex)
            {

            }

            return response;


        }

        public UserResponse Delete(string id,UserDetail user)
        {
            UserResponse response = new UserResponse();
            try
            {
                RestdbEntities db = new RestdbEntities();

                UserDetail udtl = db.UserDetails.Find(Convert.ToInt32(id));
              
                db.Entry(udtl).State = EntityState.Deleted;
                
                try
                {
                    int retval = db.SaveChanges();
                    if (retval > 0)
                    {
                        response.IsSuccess = true;
                        response.Message = "Success";
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.Message = "Sorry";

                    }
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                                ve.PropertyName,
                                eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                                ve.ErrorMessage);
                        }

                    }

                }

            }
            catch (Exception ex)
            {

            }

            return response;
        }
    }
}
