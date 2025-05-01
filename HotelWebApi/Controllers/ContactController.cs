using AutoMapper;
using HotelBusinessLayer.Abstract;
using HotelDtoLayer.ContactDto;
using HotelEntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ListContact()
        {
            var values = _mapper.Map<List<ResultContactDto>>(_contactService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            _contactService.TInsert(new Contact()
            {
                ContactAdress = createContactDto.ContactAdress,
                ContactDescription = createContactDto.ContactDescription,
                ContactEmail = createContactDto.ContactEmail,
                ContactMap = createContactDto.ContactMap,
                ContactNumber = createContactDto.ContactNumber
            });

            //Bu kısımda yeni bir iletişim bilgisi eklenirken, var olan iletişim bilgileri silinmektedir.
            //Bu, sistemde yalnızca bir iletişim bilgisinin bulunmasını sağlamak için yapılmaktadır.

            var existingAbout = _contactService.TGetListAll().FirstOrDefault();
            if (existingAbout != null)
            {
                _contactService.TDelete(existingAbout);
            }
            return Ok("İletişim başarılı bir şekilde eklendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var values = _contactService.TGetById(id);
            _contactService.TDelete(values);
            return Ok("Seçili iletişim başarılı bir şekilde silindi.");
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            _contactService.TUpdate(new Contact()
            {
                ContactId = updateContactDto.ContactId,
                ContactAdress = updateContactDto.ContactAdress,
                ContactDescription = updateContactDto.ContactDescription,
                ContactEmail = updateContactDto.ContactEmail,
                ContactMap = updateContactDto.ContactMap,
                ContactNumber = updateContactDto.ContactNumber

            });
            return Ok("Seçili iletişim başarılı bir şekilde güncellendi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var values = _contactService.TGetById(id);
            if (values == null)
            {
                return NotFound("İletişim bilgisi bulunamadı.");
            }
            return Ok(values);
        }
    }
}
