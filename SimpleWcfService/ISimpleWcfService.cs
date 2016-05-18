using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SimpleWcfService {
    
[ServiceContract]
public interface ISimpleWcfService {

    /// <summary>
    /// Return the current time on the server, expressed in the specified timezone
    /// </summary>
    /// <param name="timezoneName">The timezone ID you want to retrieve.  Leave blank to use server's timezone.  List of IDs can be found here: https://en.wikipedia.org/wiki/List_of_tz_database_time_zones </param>
    /// <returns></returns>
    [OperationContract]
    DateTime GetServerDate(string timezoneName);

    /// <summary>
    /// Similar to GetServerDate, except this function returns details on the requested timezone
    /// </summary>
    /// <param name="timezoneName"></param>
    /// <returns></returns>
    [OperationContract]
    TimeWithTimezone GetServerDateWithTzInfo(string timezoneName);

    // TODO: Add your service operations here
}


[DataContract]
public class TimeWithTimezone {
    DateTime m_time;
    TimeZoneInfo m_tzi;

    [DataMember]
    public DateTime TheTime {
        get { return m_time; }
        set { m_time = value; }
    }

    [DataMember]
    public TimeZoneInfo TimezoneDetails {
        get { return m_tzi; }
        set { m_tzi = value; }
    }
}
}