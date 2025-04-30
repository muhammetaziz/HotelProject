using HotelBusinessLayer.Abstract;
using HotelDtoLayer.AboutDto;
using HotelEntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using AutoMapper;


namespace HotelWebApi.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]

    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ListAbout()
        {
            var values = _mapper.Map<List<ResultAboutDto>>(_aboutService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAbout([FromForm] CreateAboutDto createAboutDto)
        {
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/AboutImages/");

            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            string image1Path = null;
            if (createAboutDto.ImageFile1 != null)
            {
                var uniqueName1 = Guid.NewGuid().ToString() + Path.GetExtension(createAboutDto.ImageFile1.FileName);
                var filePath1 = Path.Combine(uploadsFolder, uniqueName1);

                using (var stream = new FileStream(filePath1, FileMode.Create))
                {
                    await createAboutDto.ImageFile1.CopyToAsync(stream);
                }
                image1Path = "/Images/AboutImages/" + uniqueName1;
            }

            string image2Path = null;
            if (createAboutDto.ImageFile2 != null)
            {
                var uniqueName1 = Guid.NewGuid().ToString() + Path.GetExtension(createAboutDto.ImageFile2.FileName);
                var filePath2 = Path.Combine(uploadsFolder, uniqueName1);

                using (var stream = new FileStream(filePath2, FileMode.Create))
                {
                    await createAboutDto.ImageFile2.CopyToAsync(stream);
                }
                image2Path = "/Images/AboutImages/" + uniqueName1;
            }


            string image3Path = null;
            if (createAboutDto.ImageFile3 != null)
            {
                var uniqueName1 = Guid.NewGuid().ToString() + Path.GetExtension(createAboutDto.ImageFile3.FileName);
                var filePath3 = Path.Combine(uploadsFolder, uniqueName1);

                using (var stream = new FileStream(filePath3, FileMode.Create))
                {
                    await createAboutDto.ImageFile3.CopyToAsync(stream);
                }
                image3Path = "/Images/AboutImages/" + uniqueName1;
            }



            var about = new About
            {
                AboutDescription = createAboutDto.AboutDescription,
                Image1 = image1Path,
                Image2 = image2Path,
                Image3 = image3Path
            };

            // Eğer veritabanında zaten bir kayıt varsa, onu silip yeni kaydı ekleyin
            var existingAbout = _aboutService.TGetListAll().FirstOrDefault();
            if (existingAbout != null)
            {
                _aboutService.TDelete(existingAbout);
            }

            _aboutService.TInsert(about);
            return Ok("Hakkımızda başarılı bir şekilde eklendi.");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateAbout([FromForm] CreateAboutDto createAboutDto)
        {
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/AboutImages/");

            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            // İlk başta mevcut About verisini alıyoruz
            var existingAbout = _aboutService.TGetListAll().FirstOrDefault();
            if (existingAbout == null)
            {
                return NotFound("Hakkımızda verisi bulunamadı.");
            }

            // Yeni resimlerin path'lerini hazırlıyoruz
            string image1Path = existingAbout.Image1;
            if (createAboutDto.ImageFile1 != null)
            {
                var uniqueName1 = Guid.NewGuid().ToString() + Path.GetExtension(createAboutDto.ImageFile1.FileName);
                var filePath1 = Path.Combine(uploadsFolder, uniqueName1);

                using (var stream = new FileStream(filePath1, FileMode.Create))
                {
                    await createAboutDto.ImageFile1.CopyToAsync(stream);
                }
                image1Path = "/Images/AboutImages/" + uniqueName1;
            }

            string image2Path = existingAbout.Image2;
            if (createAboutDto.ImageFile2 != null)
            {
                var uniqueName2 = Guid.NewGuid().ToString() + Path.GetExtension(createAboutDto.ImageFile2.FileName);
                var filePath2 = Path.Combine(uploadsFolder, uniqueName2);

                using (var stream = new FileStream(filePath2, FileMode.Create))
                {
                    await createAboutDto.ImageFile2.CopyToAsync(stream);
                }
                image2Path = "/Images/AboutImages/" + uniqueName2;
            }

            string image3Path = existingAbout.Image3;
            if (createAboutDto.ImageFile3 != null)
            {
                var uniqueName3 = Guid.NewGuid().ToString() + Path.GetExtension(createAboutDto.ImageFile3.FileName);
                var filePath3 = Path.Combine(uploadsFolder, uniqueName3);

                using (var stream = new FileStream(filePath3, FileMode.Create))
                {
                    await createAboutDto.ImageFile3.CopyToAsync(stream);
                }
                image3Path = "/Images/AboutImages/" + uniqueName3;
            }

            // Veriyi güncelleyerek yeni About nesnesini oluşturuyoruz
            var updatedAbout = new About
            {
                AboutDescription = createAboutDto.AboutDescription,
                Image1 = image1Path,
                Image2 = image2Path,
                Image3 = image3Path
            };

            // Güncellenmiş veriyi veritabanına kaydediyoruz
            _aboutService.TUpdate(updatedAbout);

            return Ok("Hakkımızda başarıyla güncellendi.");
        }
        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var values = _aboutService.TGetById(id);
            if (values == null)
            {
                return NotFound("Hakkımızda bulunamadı.");
            }
            var result = _mapper.Map<ResultAboutDto>(values);
            return Ok(result);
        }



        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var values = _aboutService.TGetById(id);
            _aboutService.TDelete(values);
            return Ok("Seçili hakkımızda başarılı bir şekilde silindi.");
        }

    }
}
