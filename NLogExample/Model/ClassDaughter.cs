using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NLogExample.Model
{
    public class ClassDaughter : ClassBase
    {
        public override Logger Log { get { return _logger; } }
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public string Ring { get; set; }

        public ClassDaughter(String name, string ring)
            : base(name)
        {
            this.Ring = ring;

            Log.Info("From ClassDaughter constructor: {0} - logger.Name: {1}", this.GetType().ToString(), Log.Name);
        }

        public override string GetClassName()
        {
            string className = this.GetType().ToString();
            Log.Debug("In class : {0} , {1}", className, this.Ring);

            return className + "_" + this.Ring;
        }

        public override void ExecuteRequest()
        {
            //throw new NotImplementedException();
            this.Log.Info("Execute() in class: " + this.GetType().ToString());
        }
    }
}