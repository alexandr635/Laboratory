using DataBase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Logic
{
    /// <summary>
    /// Класс для обращения к базе данных
    /// </summary>
    public class DBQuery
    {
        /// <summary>
        /// Метод для авторизации пользователя
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns>Возвращает объект типа User, если пользователь найден, объект new User(), если данные авторизации не найдены в таблице
        /// и null, если обращение к базе данных невозможно</returns>
        public static User Authorization(string login, string password)
        {
            using(LaboratoryEntities db = new LaboratoryEntities())
            {
                try
                {
                    var result = db.Users.Where(u => u.Login == login).FirstOrDefault();
                    if (result == null)
                        return new User();
                    else if (result.Password == password)
                        return result;
                    else
                        return new User();
                }
                catch
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Метод для добавления записей входа в систему. Записи заносятся в таблицу LoginHistory
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Возвращает null, если запись добавлена и Exception, если что-то пошло не так</returns>
        public static Exception AddLoginHistory(int id)
        {
            using (LaboratoryEntities db = new LaboratoryEntities())
            {
                try
                {
                    LoginHistory history = new LoginHistory() { IdUser = id, LoginDate = DateTime.Now};
                    var result = db.LoginHistories.Add(history);
                    db.SaveChanges();
                    return null;
                }
                catch (Exception ex)
                {
                    return ex;
                }
            }
        }

        /// <summary>
        /// Метод для получения списка истории входа
        /// </summary>
        /// <returns>Возвращает List<LoginHistory>, если данные были найдены и null, если обращение к базе данных невозможно</returns>
        public static List<LoginHistory> GetListOfHistory()
        {
            using (LaboratoryEntities db = new LaboratoryEntities())
            {
                try
                {
                    var result = db.LoginHistories.Include(h => h.User).ToList();                   
                    return result;
                }
                catch
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Метод для получения списка страховых компаний
        /// </summary>
        /// <returns>Возвращает List<InsuranceCompany>, если данные найдены и null, если обращение к базе данных невозможно</returns>
        public static List<InsuranceCompany> GetListInsuranceCompany()
        {
            using (LaboratoryEntities db = new LaboratoryEntities())
            {
                try
                {
                    var result = db.InsuranceCompanies.ToList();
                    return result;
                }
                catch
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Метод для получения списка типов страхового полиса
        /// </summary>
        /// <returns>Возвращает List<TypeOfInsurancePolicy>, если данные найдены и null, если обращение к базе данных невозможно</returns>
        public static List<TypeOfInsurancePolicy> GetListTypeOfInsurancePolicy()
        {
            using (LaboratoryEntities db = new LaboratoryEntities())
            {
                try
                {
                    var result = db.TypeOfInsurancePolicies.ToList();
                    return result;
                }
                catch
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Метод для добавления пациента в базу данных
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns>Возвращает null, если пациент добавлен и Exception, если обращение к базе данных невозможно</returns>
        public static Exception AddPatient(User newUser)
        {
            using (LaboratoryEntities db = new LaboratoryEntities())
            {
                try
                {
                    db.Users.Add(newUser);
                    db.SaveChanges();
                    return null;
                }
                catch (Exception ex)
                {
                    return ex;
                }
            }
        }

        /// <summary>
        /// Метод для получения последнего идентификатора из таблицы Order
        /// </summary>
        /// <returns>Возвращает int, если запрос выполнился и -1, если обращение к базе данных невозможно</returns>
        public static int GetUniqIdOrder()
        {
            using (LaboratoryEntities db = new LaboratoryEntities())
            {
                try
                {
                    var result = db.Orders.Last().Id;
                    return result;
                }
                catch
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// Метод для получения списка услуг
        /// </summary>
        /// <returns>Возвращает List<Service>, если запрос выполнился и null, если обращение к базе данных невозможно</returns>
        public static List<Service> GetListOfSerivces()
        {
            using (LaboratoryEntities db = new LaboratoryEntities())
            {
                try
                {
                    var result = db.Services.ToList();
                    return result;
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
