﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Log;
using Vueling.Common.Logic.Model;
using Vueling.DataAccess.Dao;

namespace Vueling.DataAcces.Dao.Test
{
    class AlumnoXmlJson
    {
        private IDAO<Alumno> iAlumnoDao;
        private readonly IVuelingLogger _log = new AdpLog4Net(MethodBase.GetCurrentMethod().DeclaringType);


        [TestInitialize]
        public void TestInit()
        {
            _log.Info("Inicialiazamos Tests");
            _log.Debug("Limpiamos de ficheros existentes");
            DocumentsManager docMan = new DocumentsManager(TipoFichero.JSON);
            String filename = docMan.GetPath(); if (File.Exists(filename)) File.Delete(filename);
            _log.Debug("Obtenemos el alumno DAO con el formato actual.");
            iAlumnoDao = new AlumnoDao<Alumno>(DAOFactory<Alumno>.getFormat());
        }


        [DataRow("1", "cyllana", "gales", "99887766w", "10-01-2018", "23", "1-1-2017")]
        [DataTestMethod]
        public void AddTest(string id, string name, string apellidos, string dni, string fechaNac, string edad, string registro)
        {
            _log.Debug("AlumnoXmlTests inicio " + System.Reflection.MethodBase.GetCurrentMethod().Name);

            Alumno alumno = new Alumno(Guid.NewGuid().ToString(), id, name, apellidos, dni, fechaNac, edad, registro);
            var alumnoObt = iAlumnoDao.Add(alumno);
            Assert.IsTrue(alumno.Equals(alumnoObt));
            _log.Debug("Fin AlumnoXmlTests " + System.Reflection.MethodBase.GetCurrentMethod().Name);

        }

    }
}
