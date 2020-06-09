using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimerParcialEjemplo.BLL;
using PrimerParcialEjemplo.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
            empleado.nombre = "Pedro";
            empleado.ocupacion = 2;
            empleado.sueldo = 2500;
            empleado.fecha = DateTime.Now;
            bool saved = EmpleadoBLL.Guardar(empleado);
            Assert.AreEqual(saved, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Assert.Fail();
        }
    }
}