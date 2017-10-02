using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TestParcial.Entities;
using TestParcial.Data;


namespace TestParcial.Business
{
    /// <summary>
    /// Student business component.
    /// </summary>
    public partial class StudentBusiness
    {

        public List<Student> All()
        {
            var studentDac = new StudentDAC();
            var result = studentDac.Select();
            return result;

        }
        public Student Add(Student student)
        {
            var studentDac = new StudentDAC();
            return studentDac.Create(student);

        }
    }
}
