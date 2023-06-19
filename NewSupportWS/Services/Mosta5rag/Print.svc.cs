using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NewSupportWS.Services.Mosta5rag
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Print" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Print.svc or Print.svc.cs at the Solution Explorer and start debugging.
    public class Print : IPrint
    {
        public void PrintDOC()
        {
            DllPrntCra.CraPrnt tt = new DllPrntCra.CraPrnt();
            

            tt.DoRequestPramatr(",R=0,T=1 ,U=60000001,O=7,C=530182316,B=0,D=00000000,G=0,Q=1,V=0,N=toto new ,C1=1,C2=5,i=0,UN=1,UD=1,ITD=10.6.1.91:Cra00:sa:P@ssw0rd,");
        }
    }
}
