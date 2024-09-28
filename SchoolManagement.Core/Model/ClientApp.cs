using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Model
{
    /// <summary>
    /// Cette classe represente une application cliente
    /// Exemple Client web, client Winform
    /// </summary>
    public class ClientApp
    {
        private string? _connectionString { get; set; }
        public string? Name { get; set; }
        public string Code {  get; set; }
        public string Phone {  get; set; }
        public string Contact { get; set; }
        public string WebSite { get; set; }
        public string LogoUrl {  get; set; }
        public string? Type { get; set; } //type de client Web, WinForm, API
        public string? IpAddress { get; set; }
        public string ConnectionString
        {
            get
            {
                return _connectionString ?? "";
            }
            set
            {
                _connectionString = value;
            }
        }
       public string StudentPitureFolder { get; set; }
        public string EmployeePitureFolder { get; set; }
        public virtual User? UserConnected { get; set; }
        public string Address { get; set; }
    }
}
