using dip.common.Models;
using dip.web.Data.Entities;

namespace dip.web.Helpers
{
    public interface IConverterHelper
    {
        DipResponse ToDipResponse(DipEntity DipEntity);
    }
}
