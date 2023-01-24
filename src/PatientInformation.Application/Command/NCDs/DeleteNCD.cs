using MediatR;
using PatientInformation.Application.Model;
using PatientInformation.Application.Services.GenericRepository;
using PatientInformation.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientInformation.Application.Command.Allergies
{
    public record DeleteNCD(long Id) : IRequest<OperationResult<bool>>;
    public class DeleteNCDHandler : IRequestHandler<DeleteNCD, OperationResult<bool>>
    {
        private readonly IRepositoryBase<NonCommunicableDisease> _ncdrepository;
        public DeleteNCDHandler(IRepositoryBase<NonCommunicableDisease> ncdrepository) => _ncdrepository = ncdrepository;
        public async Task<OperationResult<bool>> Handle(DeleteNCD request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<bool>();
            var ncd = await _ncdrepository.FindAsync(request.Id);
            ncd.Delete();
            _ncdrepository.Update(ncd);
            result.Payload = true;
            return result;
        }
    }
}
