using AutoMapper;
using DataModels = StudentInformationSystem.API.DataModels;
using StudentInformationSystem.API.DomainModels;

namespace StudentInformationSystem.API.Profiles.AfterMaps
{
    public class UpdateStudentRequestAfterMap : IMappingAction<UpdateStudentRequest, DataModels.Student>
    {

        public void Process(UpdateStudentRequest source, DataModels.Student destination, ResolutionContext context)
        {
            destination.Address = new DataModels.Address()
            {
                PhysicalAddress = source.PhysicalAddress,
                PostalAddress = source.PostalAddress
            };
        }
    }
}
