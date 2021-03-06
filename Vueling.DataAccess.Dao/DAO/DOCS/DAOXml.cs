﻿using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Log;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic.Utils;

namespace Vueling.DataAccess.Dao
{
    public class DAOXml<T> : IDAO<T> where T: VuelingObject
    {

        private readonly IVuelingLogger _log = new AdpLog4Net(MethodBase.GetCurrentMethod().DeclaringType);
        private DocumentsManager docManager = null;

        public DAOXml()
        {
            docManager =new DocumentsManager();
            docManager.LoadDocument();
        }

        public IVuelingLogger Log => _log;

        public T Insert(T entity)
        {
            try
            {
                Log.Info("Inicio XML " + System.Reflection.MethodBase.GetCurrentMethod().Name);
                _log.Info("Inicio XML " + System.Reflection.MethodBase.GetCurrentMethod().Name);
                List<T> entityList = SelectAll();
                XmlSerializer xSeriz = new XmlSerializer(typeof(List<Alumno>));

                if (entityList == null)
                {
                    entityList = new List<T>();
                }

                using (FileStream fs1 = new FileStream(docManager.GetPath(), FileMode.Create))
                {
                    entityList.Add(entity);
                    xSeriz.Serialize(fs1, entityList);
                }

                return (Select(entity.Guid));
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
                _log.Info("Fin de XML " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }



        public List<T> SelectAll()
        {
            try
            {

                _log.Info("Inicio XML " + System.Reflection.MethodBase.GetCurrentMethod().Name);
                List<T> entityList =null;
                XmlSerializer xSeriz = new XmlSerializer(typeof(List<T>));
                using (StreamReader r = new StreamReader(docManager.GetPath()))
                {
                    String xml = r.ReadToEnd();
                    if (xml==String.Empty){
                        entityList = new List<T>();
                    }
                    else
                    {
                        StringReader stringReader = new StringReader(xml);
                        entityList = (List<T>)xSeriz.Deserialize(stringReader);
                    }
                
                }
                return entityList;
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
                _log.Info("Fin de XML " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        public T Select(Guid guid)
        {
            try
            {

                _log.Info("Inicio XML " + System.Reflection.MethodBase.GetCurrentMethod().Name);
                T entityFound = null;
                List<T> entityList = SelectAll();
                 foreach (var item in entityList)
                {

                    if (item.Guid.Equals(guid))
                    {
                        entityFound = item;
                        break;
                    }
                }


                return entityFound;
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
                _log.Info("Fin de XML " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
    }
}
