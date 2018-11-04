using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NLogExample.Model
{
    public abstract class ClassBase : IPerson
    {
        public virtual Logger Log { get { return _logger; } }
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public string Name { get; set; }

        public ClassBase(String name)
        {
            this.Name = name;

            Log.Info("From ClassBase constructor: {0} - logger.Name: {1}", this.GetType().ToString(), Log.Name);

        }

        public void LogFromClassBase()
        {
            Log.Info("LogFromClassBase(): {0}", Log.Name);
        }

        public virtual string GetClassName()
        {
            string className = this.GetType().ToString();
            Log.Debug("In class : {0}", className);

            return className;
        }

        public abstract void ExecuteRequest();
    }
}