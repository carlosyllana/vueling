﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Vueling.Common.Logic.TipoFichero;
using Serilog;
using System.Reflection;
using Vueling.Common.Logic.Log;
using System.Security;
using Vueling.Common.Logic.Utils;
using Vueling.Business.Logic;

namespace Vueling.Common.Logic
{
    public class DocumentsManager
    {
        public static String PATH;
        private readonly IVuelingLogger _log = new AdpLog4Net(MethodBase.GetCurrentMethod().DeclaringType);
        private System.Object lockThis = new System.Object();
        ConfigManager confManager = null;
        public DocumentsManager()
        {
            confManager = new ConfigManager();
            LoadDocument();
        }

        public void LoadDocument()
        {
            PATH = GetPath();
            try
            {
                lock (lockThis)
                {
                    _log.Info("Inicio DocumentManager " + System.Reflection.MethodBase.GetCurrentMethod().Name);
                    if (!File.Exists(PATH))
                    {
                        File.CreateText(PATH);
                    }
                }

            }
            catch (ArgumentNullException ex)
            {
                _log.Error("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;
            }
            catch (PathTooLongException ex)
            {
                _log.Error("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;
            }
            catch (DirectoryNotFoundException ex)
            {
                _log.Error("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;
            }
            catch (UnauthorizedAccessException ex)
            {
                _log.Error("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;
            }
            catch (NotSupportedException ex)
            {
                _log.Error("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;
            }
            catch (SecurityException ex)
            {
                _log.Error("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;
            }
            catch (IOException ex)
            {
                _log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;
            }
            finally
            {
                _log.Info("Fin de DocumentManager " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

        }

        public String GetPath()
        {
            try
            {
                var fileName = string.Empty;
                switch (confManager.GetActualFormat())
                {
                    case TipoFichero.TXT:
                        fileName = Environment.GetEnvironmentVariable("txtFile", EnvironmentVariableTarget.User);
                        break;
                    case TipoFichero.JSON:
                        fileName = Environment.GetEnvironmentVariable("jsonFile", EnvironmentVariableTarget.User);
                        break;
                    case TipoFichero.XML:
                        fileName = Environment.GetEnvironmentVariable("xmlFile", EnvironmentVariableTarget.User);
                        break;
                }
                return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + " \\" + fileName;
            }
            catch (ArgumentNullException ex)
            {
                _log.Error("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;
            }
            catch (PathTooLongException ex)
            {
                _log.Error("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;
            }
            catch (DirectoryNotFoundException ex)
            {
                _log.Error("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;
            }
            catch (UnauthorizedAccessException ex)
            {
                _log.Error("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;
            }
            catch (NotSupportedException ex)
            {
                _log.Error("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;
            }
            catch (SecurityException ex)
            {
                _log.Error("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;
            }
            catch (IOException ex)
            {
                _log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
                throw;
            }
            finally
            {
                _log.Info("Fin de DocumentManager " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

        }

    }

}
