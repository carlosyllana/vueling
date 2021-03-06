﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Log;
using Vueling.Common.Logic.Model;

namespace Vueling.Business.Logic
{
    public class ConfigManager
    {

        private readonly IVuelingLogger _log = new AdpLog4Net(MethodBase.GetCurrentMethod().DeclaringType);
        private System.Object lockThis = new System.Object();
        public ConfigManager()
        {
        }

        public void Formater(TipoFichero tipoFichero)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                _log.Info("Inicio AlumnoBl " + System.Reflection.MethodBase.GetCurrentMethod().Name);
                var value = (int)tipoFichero;
                config.AppSettings.Settings["tipoFichero"].Value = value.ToString();
                config.Save(ConfigurationSaveMode.Modified);

            }
            catch (ConfigurationErrorsException ex)
            {
                _log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Error al Escribir en  AppSettings--> " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;

            }
            finally
            {
                _log.Info("Fin de AlumnoBl " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        public TipoFichero GetActualFormat()
        {
            try
            {
                _log.Info("Inicio AlumnoBl " + System.Reflection.MethodBase.GetCurrentMethod().Name);
                //Obtener Formato.
                ConfigurationManager.RefreshSection("appSettings");
                var tipo = Int32.Parse(ConfigurationManager.AppSettings["tipoFichero"]);
                return (TipoFichero)tipo;
            }
            catch (ConfigurationErrorsException ex)
            {
                _log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Error al Escribir en  AppSettings--> " + ex.Message);
                throw;

            }
            catch (Exception ex)
            {
                _log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Error al leer  en AppSettings--> " + ex.Message);
                throw;
            }
            finally
            {
                _log.Info("Fin de AlumnoBl " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

      

        public Idioma GetActualLanguage()
        {
            try
            {
                _log.Info("Inicio AlumnoBl " + System.Reflection.MethodBase.GetCurrentMethod().Name);
                //Obtener Formato.
                ConfigurationManager.RefreshSection("appSettings");
                var tipo = Int32.Parse(ConfigurationManager.AppSettings["idioma"]);
                return (Idioma)tipo;
            }
            catch (ConfigurationErrorsException ex)
            {
                _log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Error al Escribir en  AppSettings--> " + ex.Message);
                throw;

            }
            catch (Exception ex)
            {
                _log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Error al leer  en AppSettings--> " + ex.Message);
                throw;
            }
            finally
            {
                _log.Info("Fin de AlumnoBl " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        public void GrabarIdioma(Idioma idioma)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                _log.Info("Inicio AlumnoBl " + System.Reflection.MethodBase.GetCurrentMethod().Name);
                var value = (int)idioma;
                config.AppSettings.Settings["idioma"].Value = value.ToString();
                config.Save(ConfigurationSaveMode.Modified);
            }
            catch (ConfigurationErrorsException ex)
            {
                _log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Error al Escribir en  AppSettings--> " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;

            }
            finally
            {
                _log.Info("Fin de AlumnoBl " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        public String GetStringConnexion()
        {
            try
            {
                _log.Info("Inicio AlumnoBl " + System.Reflection.MethodBase.GetCurrentMethod().Name);
                //Obtener Formato.
                ConfigurationManager.RefreshSection("appSettings");
                return (ConfigurationManager.AppSettings["SQLStringCon"]);
            }
            catch (ConfigurationErrorsException ex)
            {
                _log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Error al Escribir en  AppSettings--> " + ex.Message);
                throw;

            }
            catch (Exception ex)
            {
                _log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Error al leer  en AppSettings--> " + ex.Message);
                throw;
            }
            finally
            {
                _log.Info("Fin de AlumnoBl " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        public TipoSQL GetActualSQLFormat()
        {
            try
            {
                _log.Info("Inicio AlumnoBl " + System.Reflection.MethodBase.GetCurrentMethod().Name);
                //Obtener Formato.
                ConfigurationManager.RefreshSection("appSettings");
                var tipo = Int32.Parse(ConfigurationManager.AppSettings["tipoSQL"]);
                return (TipoSQL)tipo;
            }
            catch (ConfigurationErrorsException ex)
            {
                _log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Error al Escribir en  AppSettings--> " + ex.Message);
                throw;

            }
            catch (Exception ex)
            {
                _log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Error al leer  en AppSettings--> " + ex.Message);
                throw;
            }
            finally
            {
                _log.Info("Fin de AlumnoBl " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        public void SetActualSQLFormat(TipoSQL sqlFormat)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                _log.Info("Inicio AlumnoBl " + System.Reflection.MethodBase.GetCurrentMethod().Name);
                var value = (int)sqlFormat;
                config.AppSettings.Settings["tipoSQL"].Value = value.ToString();
                config.Save(ConfigurationSaveMode.Modified);
            }
            catch (ConfigurationErrorsException ex)
            {
                _log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + " Error al Escribir en  AppSettings--> " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;

            }
            finally
            {
                _log.Info("Fin de AlumnoBl " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
    }
}
