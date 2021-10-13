using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebmotorsAnuncio.Models.OnlineChallengeResponse;

namespace WebmotorsAnuncio.Clients
{
    public class MakeClient : OnlineChallengeClient
    {
        public MakeOCResponse GetMakeByID(int makeID)
        {
            var makes = SendGetRequest<IEnumerable<MakeOCResponse>>("Make");

            return makes.FirstOrDefault(x => x.ID == makeID);
        }
    }
}