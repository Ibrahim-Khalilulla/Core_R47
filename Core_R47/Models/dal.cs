using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core_R47.Models
{
    public class students
    {
        [Key]
        public int studentid { get; set; }
        public string name { get; set; }
        public virtual ICollection<results> results { get; set; }
    }
    public class results
    {
        [Key]
        public int ResultId { get; set; }
        public string subject { get; set; }
        public int mark { get; set; }
        [ForeignKey("students")]
        public int studentid { get; set; }
        public virtual students students { get; set; }
    }
    public class teachers
    {
        [Key]
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
    }

    public class MyClass
    {
        public string content;
    }
    public class RepeatText
    {
        public string Text { get; set; }
        public int Number { get; set; }
    }



    public class dept2
    {
        [Key]
        public string deptid { get; set; }
        public string deptname { get; set; }
        public string location { get; set; }
        public IList<items2> items2 { get; set; }
    }
    public partial class items2
    {
        [Key]
        public string itemcode { get; set; }
        public string itemname { get; set; }
        [ForeignKey("dept2")]
        public string deptid { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public Nullable<decimal> cost { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public Nullable<decimal> rate { get; set; }
        public DateTime date { get; set; }
        public string picture { get; set; }
        public dept2 dept2 { get; set; }
    }
    public class Dept_Items
    {

        public string DeptId { get; set; }
        [Required(ErrorMessage = "Please enter Dept Name")]
        [Display(Name = "DeptName")]
        [MaxLength(50)]
        public string DeptName { get; set; }
        public string Location { get; set; }
        public string ItemCode { get; set; }//primary key and foreign Foreign Key
        public string ItemName { get; set; }
        public double Cost { get; set; }
        public double Rate { get; set; }
        public DateTime date { get; set; }
        public string picture { get; set; }
        public string sid { get; set; }
    }
    public class ItemCount
    {
        public string deptid { get; set; }
        public string deptname { get; set; }
        public int count { get; set; }
    }
}
