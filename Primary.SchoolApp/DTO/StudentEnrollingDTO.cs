

using MediaFoundation;
using SchoolManagement.Core.Model;
using System.Threading;
using System;
using Telerik.Reporting;
using System.Collections.Generic;
using System.Linq;

namespace Primary.SchoolApp.DTO
{
    internal class StudentEnrollingDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int StudentId { get; set; }
        public int SchoolYearId { get; set; }
        public int ClassId { get; set; }
        public string OldSchool { get; set; }
        public bool IsRepeater { get; set; }
        public bool IsActive { get; set; }
        public string ReasonLeft { get; set; }
        public virtual string StateRepeater
        {
            get
            {
                if (IsRepeater) return Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "Oui" : "Yes";
                else return Thread.CurrentThread.CurrentUICulture.Name != "en-GB" ? "Non" : "No";
            }
        }
        public string? PictureUrl { get; set; }

        public virtual SchoolClass SchoolClass { get; set; }
        public virtual SchoolYear SchoolYear { get; set; }
        public virtual Student Student { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj is not StudentEnrolling other) return false;
            return (this.Id == other.Id);
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode(); ;
        }
        public System.Drawing.Image HealthImage
        {
            get
            {
                if (this.Student.Health == 0)
                {
                    return Resources.heartbeat_green;
                }
                else
                {
                    if (this.Student.Health == 1)
                    {
                        return Resources.heartbeat_orange;
                    }
                    else
                    {
                        return Resources.heartbeat_red;
                    }
                }
            }
          
        }
        public double Balance { get; set; }
        public double InsolvencyAmount {
            get => InsolvencyStateList.Sum(x => x.Amount);
        }
        public string ClassName
        {
            get
            {
                return SchoolClass!=null?SchoolClass.Name:"";
            }
        }
        public string ClassGroupName
        {
            get
            {
                return SchoolClass.Group != null ? SchoolClass.Group.Name : "";
            }
        }
        
        public List<InsolvencyState> InsolvencyStateList { get; set; }=new List<InsolvencyState>();
        public List<TuitionDiscount> DiscountList { get;set; }=new List<TuitionDiscount>();
        public List<TuitionPayment> PaymentPayableList { get; set; } =new List<TuitionPayment>();
        public List<TuitionPayment> PaymentList { get; set; } = new List<TuitionPayment>();

    }
}
