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
    public record DeleteAllergy(long Id) : IRequest<OperationResult<bool>>;
    public class DeleteAllergyHandler : IRequestHandler<DeleteAllergy, OperationResult<bool>>
    {
        private readonly IRepositoryBase<Allergy> _allergyrepository;
        public DeleteAllergyHandler(IRepositoryBase<Allergy> allergyrepository) => _allergyrepository = allergyrepository;
        public async Task<OperationResult<bool>> Handle(DeleteAllergy request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<bool>();
            var allergy = await _allergyrepository.FindAsync(request.Id);
            allergy.Delete();
            _allergyrepository.Update(allergy);
            result.Payload = true;
            return result;
        }
    }
}
