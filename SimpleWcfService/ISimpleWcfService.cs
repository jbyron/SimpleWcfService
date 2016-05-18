using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SixthImpulse.SimpleWcf.SimpleWcfService {
    
[ServiceContract]
public interface ISimpleWcfService {

    /// <summary>
    /// Return the current time on the server, expressed in the specified timezone
    /// </summary>
    /// <param name="timezoneName">The timezone ID you want to retrieve.  Leave blank to use server's timezone.</param>
    /// <returns></returns>
    /// <remarks>The timezone IDs are the full names.  An unofficial list can be found here: http://stackoverflow.com/questions/7908343/list-of-timezone-ids-for-use-with-findtimezonebyid-in-c
    /// List of IDs can be found here: https://en.wikipedia.org/wiki/List_of_tz_database_time_zones
    /// </remarks>
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
    string m_tziName;
    int m_tziGmtOffset;

    [DataMember]
    public DateTime TheTime {
        get { return m_time; }
        set { m_time = value; }
    }

    [DataMember]
    public string TimezoneName {
        get { return m_tziName; }
        set { m_tziName = value; }
    }

    [DataMember]
    public int TimezoneGmtOffset {
        get { return m_tziGmtOffset; }
        set { m_tziGmtOffset = value; }
    }

}
}