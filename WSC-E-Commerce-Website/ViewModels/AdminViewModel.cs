using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WSC_E_Commerce_Website.DAL;
using WSC_E_Commerce_Website.Models;
using Roles = WSC_E_Commerce_Website.Models.Roles;

namespace WSC_E_Commerce_Website.ViewModels
{
    public class RoleViewModel
    {
        public string Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "RoleName")]
        public string Name { get; set; }
    }

    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        public IEnumerable<SelectListItem> RolesList { get; set; }
    }

    public class AddRoleToUserViewModel
    {
        public RegisterViewModel RegisterViewModel { get; set; }
        public Roles Roles { get; set; }
    }


    public class GroupedUserViewModel
    {
        public List<UserViewModel> OperationsManager { get; set; }
        public List<UserViewModel> Admin { get; set; }
        public List<UserViewModel> SaleClerk { get; set; }
    }
    public class UserViewModel
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
    }

}