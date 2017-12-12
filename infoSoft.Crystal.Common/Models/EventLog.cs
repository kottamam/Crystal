#region Copyright

// ©Copyright 2015, tv Software Private Limited, All rights reserved.

#endregion

#region Code history

// Created On  : 14.06.2015
// Created By  : Noble
// Description : This class includes member and accessor methods for event log.
//-----------------------------------------------------------------------------------------------------------------------------------------------------//
// Last Modified On         : 
// Last Modified By         : 
// Modification Description : 

#endregion

#region Using directives

using tv.Crystal.Common.Constants;
using System;

#endregion

namespace tv.Crystal.Common.Models
{
    public class EventLog
    {
        #region Public methods

        public int EventId
        {
            get;
            set;
        } = 0;

        public DateTime EventDate
        {
            get;
            set;
        } = ActiveUserSession.ServerDateTime;

        public string EventDescription
        {
            get;
            set;
        } = string.Empty;

        public EventLogType EventTypeId
        {
            get;
            set;
        } = EventLogType.Login;

        public EventLogMode EventMode
        {
            get;
            set;
        } = EventLogMode.General;

        public int UserId
        {
            get;
            set;
        } = 0;

        public int CounterId
        {
            get;
            set;
        } = 0;

        public int? Extra1
        {
            get;
            set;
        } = null;

        #endregion
    }
}
