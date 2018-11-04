using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NLogExample.Model
{
    public class ClassSon : ClassBase
    {
        //private static Logger logger = LogManager.GetCurrentClassLogger(); //.GetLogger("NLogExample.Model.ClassSonX"); 

        public override Logger Log { get { return _logger; } }
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public string Ball { get; set; }

        public ClassSon(String name, string ball)
            : base(name)
        {
            this.Ball = ball;

            Log.Info("From ClassSon constructor: {0} - logger.Name: {1}", this.GetType().ToString(), Log.Name);
        }

        public override string GetClassName()
        {
            string className = this.GetType().ToString();
            Log.Debug("In class : {0} , {1}", className, this.Ball);

            return className + "_" + this.Ball;
        }

        public override void ExecuteRequest()
        {
            //throw new NotImplementedException();
            this.Log.Info("Execute() in class: " + this.GetType().ToString());
        }
    }
}