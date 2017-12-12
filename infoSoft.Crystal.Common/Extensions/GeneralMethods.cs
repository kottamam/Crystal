#region Copyright

// ©Copyright 2015, tv Software Private Limited, All rights reserved.

#endregion

#region Code history

// Created On  : 14.06.2015
// Created By  : Noble
// Description : Class for define general methods
//-----------------------------------------------------------------------------------------------------------------------------------------------------//
// Last Modified On         : 
// Last Modified By         : 
// Modification Description : 

#endregion

#region Using directives

using tv.Crystal.Common.Constants;
using tv.Crystal.Common.Models;
using System;
using System.Windows.Forms;

#endregion

namespace tv.Crystal.Common.Constants
{
    public class GeneralMethods
    {
        /// <summary>
        /// Create eventlog instance and sets values
        /// </summary>
        /// <param name="eventDescription">Event descripeion</param>
        /// <param name="eventDateTime">Event date time</param>
        /// <param name="eventType">Event type id</param>
        /// <param name="eventMode">Event mode</param>
        /// <param name="extra1">Extra values if any</param>
        /// <returns>Event log instance</returns>
        public static EventLog SetEventLog(string eventDescription, DateTime eventDateTime, EventLogType eventType, EventLogMode eventMode, int? extra1)
        {
            EventLog currentEvent = new EventLog();
            currentEvent.EventDate = eventDateTime;
            currentEvent.EventDescription = eventDescription;
            currentEvent.EventTypeId = eventType;
            currentEvent.EventMode = eventMode;
            currentEvent.UserId = ActiveUserSession.UserId;
            currentEvent.CounterId = ActiveUserSession.CounterId;
            currentEvent.Extra1 = extra1;
            return currentEvent;
        }


        /// <summary>
        /// Resize the form as per height and width constant values
        /// </summary>
        /// <param name="form"></param>
        public static void ResizeForm(Form form)
        {
            FormResizer objFormResizer = new FormResizer();
            objFormResizer.ResizeForm(form, CrystalConstants.FORM_HEIGHT, CrystalConstants.FORM_WIDTH);
        }
    }
}
