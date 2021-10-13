using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebmotorsAnuncio.Models.OnlineChallengeResponse;

namespace WebmotorsAnuncio.Clients
{
    public class ModelClient : OnlineChallengeClient
    {
        public MakeOCResponse GetModelByMakeIDAndID(int makeID, int modelID)
        {
            var models = SendGetRequest<IEnumerable<MakeOCResponse>>("Model?MakeID=" + makeID);

            return models.FirstOrDefault(x => x.ID == modelID);
        }
    }


}