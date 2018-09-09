using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.ServiceModel.Channels;

namespace OrderManagementAPI.BLL
{
    public class SessionManagement : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="ipAddress"></param>
        /// <param name="machineName"></param>
        /// <returns></returns>
        public bool CreateSession(string userName)
        {


            using (Models.Entities entity = new Models.Entities())
            {
                try
                {
                    Models.SessionManagement sessionManagement = new Models.SessionManagement();

                    sessionManagement.SessionGuiId = Guid.NewGuid();
                    sessionManagement.CreatedDate = DateTime.Now;
                    sessionManagement.EndDate = DateTime.Now.AddHours(1);
                    sessionManagement.IpAddress = GetIp();
                    sessionManagement.MachineName = null;

                    entity.SessionManagements.Add(sessionManagement);
                    entity.SaveChanges();
                    return true;

                }
                catch (Exception ex)
                {
                    entity.Dispose();
                    throw;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sessionGuiId"></param>
        /// <returns></returns>
        public bool UpdateSession(Guid sessionGuiId)
        {

            using (Models.Entities entity = new Models.Entities())
            {
                try
                {
                    Models.SessionManagement sessionManagement = new Models.SessionManagement();
                    var result = entity.SessionManagements.SingleOrDefault(w => w.SessionGuiId == sessionGuiId);
                    if (result != null)
                    {
                        result.EndDate = DateTime.Now.AddHours(1);
                        entity.SaveChanges();
                        return true;
                    }
                    else
                        return false;

                }
                catch (Exception ex)
                {
                    entity.Dispose();
                    throw;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sessionGuiId"></param>
        /// <returns></returns>
        public bool CheckSession(Guid sessionGuiId)
        {

            using (Models.Entities entity = new Models.Entities())
            {
                try
                {
                    Models.SessionManagement sessionManagement = new Models.SessionManagement();

                    var result = entity.SessionManagements.SingleOrDefault(w => w.SessionGuiId == sessionGuiId);
                    if (result != null && result.EndDate > DateTime.Now)
                    {
                        if (result.IpAddress != null)
                        {
                            if (result.IpAddress != GetIp())
                                return false;
                        }
                        return true;
                    }
                    else
                        return false;

                }
                catch (Exception ex)
                {
                    entity.Dispose();
                    throw;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetIp()
        {
            return GetClientIp();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private string GetClientIp(HttpRequestMessage request = null)
        {
            request = request ?? Request;

            if (request.Properties.ContainsKey("MS_HttpContext"))
            {
                return ((HttpContextWrapper)request.Properties["MS_HttpContext"]).Request.UserHostAddress;
            }
            else if (request.Properties.ContainsKey(RemoteEndpointMessageProperty.Name))
            {
                RemoteEndpointMessageProperty prop = (RemoteEndpointMessageProperty)request.Properties[RemoteEndpointMessageProperty.Name];
                return prop.Address;
            }
            else if (HttpContext.Current != null)
            {
                return HttpContext.Current.Request.UserHostAddress;
            }
            else
            {
                return null;
            }
        }

    }
}