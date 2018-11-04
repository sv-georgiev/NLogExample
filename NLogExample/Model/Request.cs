using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NLogExample.Model
{
    public class Request
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public IPerson Person { get; private set; }

        public Request(IPerson person)
        {
            this.Person = person;
        }

        public void Execute()
        {
            logger = this.Person.Log;

            logger.Info("Starting Request.Execute - class: {0}", this.GetType().ToString());

            this.Person.ExecuteRequest();

            logger.Info("Ending Request.Execute - class: {0}", this.GetType().ToString());
        }
    }
}