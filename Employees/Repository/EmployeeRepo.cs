using DataAccessLayer.DAL;
using Employees.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Employees.Repository
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private EmployeesTestEntities db = new EmployeesTestEntities();


        public ApiResponse Add(Employee item)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                db.Employees.Add(item);
                response.Id = item.Id;
                response.Name = item.Name;
                response.Address = item.Address;
                response.PhoneNo = item.PhoneNo;
                response.JoiningDate = item.JoiningDate;
                response.Skills = item.Skills;
                response.Photo = item.Photo;
                response.responseCode = 3;
                response.responseMessage = "New Employee Added Sucessfully";
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                response.responseCode = 97;
                response.responseMessage = "<Error while addding new Employee> : " + ex.Message;
            }

            return response;

        }

        public ApiResponse Get(int id)
        {
            var empRow = db.Employees.Where(x => x.Id == id).FirstOrDefault();
            ApiResponse response = new ApiResponse();
            try
            {

                response.Id = empRow.Id;
                response.Name = empRow.Name;
                response.Address = empRow.Address;
                response.PhoneNo = empRow.PhoneNo;
                response.JoiningDate = empRow.JoiningDate;
                response.Skills = empRow.Skills;
                response.Photo = empRow.Photo;
                response.responseCode = 1;
                response.responseMessage = "Record for id : " + empRow.Id;
            }
            catch (Exception ex)
            {
                response.responseCode = 99;
                response.responseMessage = "<Error while getting employee> : " + ex.Message;
            }
            return response;
        }

        public IEnumerable<Employee> GetAll()
        {             
            return db.Employees;
        }


        public ApiResponse Remove(int id)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                var remEmp = db.Employees.Find(id);
                db.Employees.Remove(remEmp);
                db.SaveChanges();

                response.responseCode = 2;
                response.responseMessage = "Employee Deleted successfully";
            }
            catch(Exception ex)
            {
                response.responseCode = 98;
                response.responseMessage = "<Error while deleteing Employee> : " + ex.Message;
            }
            return response;
        }

        public ApiResponse Update(Employee item)
        {
            var empRow = db.Employees.Where(x => x.Id == item.Id).FirstOrDefault();
            ApiResponse response = new ApiResponse();
            try
            {
                empRow.Name = item.Name;
                empRow.Address = item.Address;
                empRow.PhoneNo = item.PhoneNo;
                empRow.JoiningDate = item.JoiningDate;
                empRow.Skills = item.Skills;
                empRow.Photo = item.Photo;

                response.Id = item.Id;
                response.Name = item.Name;
                response.Address = item.Address;
                response.PhoneNo = item.PhoneNo;
                response.JoiningDate = item.JoiningDate;
                response.Skills = item.Skills;
                response.Photo = item.Photo;
                response.responseMessage = "Employee information updated successfully.";
                response.responseCode = 4;

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                response.responseCode = 96;
                response.responseMessage = "<Error Updating Employee> : " + ex.Message;
            }
            return response;
        }
    }
}