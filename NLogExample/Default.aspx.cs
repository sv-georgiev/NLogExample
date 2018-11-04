using NLog;
using NLogExample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NLogExample
{
    public partial class _Default : Page
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        protected void Page_Load(object sender, EventArgs e)
        {

            logger.Info("START MAIN PROGRAM");

            Request rd = new Request(new ClassDaughter("Girl", "Daughter in Request"));
            rd.Execute();

            Request rs = new Request(new ClassSon("Boy", "Son in Request"));
            rs.Execute();

            //CallSon();

            //CallDaughter();

            logger.Info("END MAIN PROGRAM");
        }

        public void CallDaughter()
        {
            ClassDaughter daughter = new ClassDaughter("Girl", "Ring");

            logger = daughter.Log;
            logger.Info("In CallDaughter");

            daughter.GetClassName();
            daughter.LogFromClassBase();
            daughter.ExecuteRequest();

            logger.Info("From the main procedure in the context of ClassDaughter - logger.Name: {0}", logger.Name);

        }

        public void CallSon()
        {
            ClassSon son = new ClassSon("Boy", "Ball");

            logger = son.Log;
            logger.Info("In CallSon");

            son.GetClassName();
            son.LogFromClassBase();
            son.ExecuteRequest();
            logger.Info("From the main procedure in the context of ClassSon - logger.Name: {0}", logger.Name);
        }

    }
}