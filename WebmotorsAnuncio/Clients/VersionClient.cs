using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebmotorsAnuncio.Models.OnlineChallengeResponse;

namespace WebmotorsAnuncio.Clients
{
    public class VersionClient : OnlineChallengeClient
    {
        public MakeOCResponse GetVersionByModelIDAndID(int modelID, int versionID )
        {
            var versions = SendGetRequest<IEnumerable<MakeOCResponse>>("Version?ModelID=" + modelID);

            return versions.FirstOrDefault(x => x.ID == versionID);
        }
    }


}