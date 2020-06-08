using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimerParcialEjemplo.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using PrimerParcialEjemplo.Models;


namespace PrimerParcialEjemplo.BLL.Tests
{
    [TestClass()]
    public class EmpleadoBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Empleado empleado = new Empleado();
            empleado.empleadoId = 0;
            empleado.nombre = "Juan";
            empleado.ocupacion = 1;
            empleado.fecha = DateTime.Now;
            empleado.sueldo = 1200;

            bool guardado = EmpleadoBLL.Guardar(empleado);
            Assert.AreEqual(guardado, true);
        }
    }
}