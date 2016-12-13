using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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

        public class ListUsersWithRolesViewModel
        {
           
            public string Userid { get; set; }
            public string Username { get; set; }
            public List<SelectRolesEditorViewModel> roles { get; set; }
           // public ListUsersWithRolesViewModel() { }

            //public ListUsersWithRolesViewModel(IdentityRole role)
            //{
            //    this.RoleName = role.Name;
            //}

            public ListUsersWithRolesViewModel(ApplicationUser user)
            {
                this.Userid = user.Id;
                this.Username = user.UserName;
                this.roles = new List<SelectRolesEditorViewModel>();
            }
            //public ApplicationUser Users { get; set; }          
            //public virtual IEnumerable<ApplicationUser>users { get; set; }

            
        }

        public class SelectRolesEditorViewModel
        {
           
            [Display(Name = "Roles")]
            public string RoleName { get; set; }

            public SelectRolesEditorViewModel()
            {
                
            }

            public SelectRolesEditorViewModel(IdentityRole role)
            {
                this.RoleName = role.Name;
            }
        }
}