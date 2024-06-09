using Microsoft.AspNetCore.Mvc;
using AdoptPet.Application.Interfaces.IService;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using AdoptPet.Domain.Entities;
using AdoptPet.Infrastructure.Services;

[Route("api/[controller]")]
[ApiController]
public class AdoptMapController : ControllerBase
{
    private readonly IPetService _petService;
    private readonly IGenericService<Owner> _ownerService;

    public AdoptMapController(IPetService petService, IGenericService<Owner> ownerService)
    {
        _petService = petService;
        _ownerService = ownerService;
    }

    [HttpGet("geojson")]
    public async Task<IActionResult> GetGeoJson()
    {
        var petResult = await _petService.GetAllAsync(1, int.MaxValue); // Get all pets
        var ownerResult = await _ownerService.GetAllAsync(1, int.MaxValue); // Get all owners

        var petFeatures = petResult.Items.Select(p => new
        {
            type = "Feature",
            geometry = new
            {
                type = "Point",
                coordinates = new[] { p.Longitude, p.Latitude }
            },
            properties = new
            {
                id = p.Id,
                name = p.PetName,
                owner = p.OwnerId.HasValue ? ownerResult.Items.FirstOrDefault(o => o.Id == p.OwnerId)?.Name : null,

                avatarUrl = p.PetImages.FirstOrDefault()!.ImgPath,
                entityType = "pet",
                description = p.PetDescription,
                weight = p.PetWeight,
                age = p.PetAge,
                gender = p.PetGender,
                desexed = p.PetDesexed,
                wormed = p.PetWormed,
                vaccined = p.PetVaccined,
                microchipped = p.PetMicrochipped,
                entryDate = p.PetEntryDate
            }
        });

        var ownerFeatures = ownerResult.Items.Select(o => new
        {
            type = "Feature",
            geometry = new
            {
                type = "Point",
                coordinates = new[] { o.Longitude, o.Latitude }
            },
            properties = new
            {
                id = o.Id,
                name = o.Name,
                avatarUrl = "/pets/c584cca9e274088f9117155052758c17c6254d47e261e7f46d7e988326ed4385.png",
                entityType = "owner"
            }
        });

        var features = petFeatures.Cast<object>().Concat(ownerFeatures.Cast<object>());

        var geoJson = new
        {
            type = "FeatureCollection",
            features
        };

        return Ok(geoJson);
    }

}
