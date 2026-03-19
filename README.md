# escape-room-game
Разработка мини-игры
![d632d4bbf773302c4f3c95cf4224841f](https://github.com/user-attachments/assets/bf25fa3a-2591-461c-bcb0-2dd1fe985f5b)


using CarRental.Core.Models;
using CarRental.Core.Validation;

namespace CarRental.Core.Migration;

public static class CarNormalizer
{
    public static bool Normalize(Car car)
    {
        bool changed = false;

        // Проверка Brand
        if (car.Brand == null)
        {
            car.Brand = "";
            changed = true;
        }
        
        var brandTrim = car.Brand.Trim();
        if (brandTrim != car.Brand)
        {
            car.Brand = brandTrim;
            changed = true;
        }
        
        if (car.Brand.Length > CarValidator.BrandMaxLength)
        {
            car.Brand = car.Brand.Substring(0, CarValidator.BrandMaxLength);
            changed = true;
        }

        // Проверка Model
        if (car.Model == null)
        {
            car.Model = "";
            changed = true;
        }
        
        var modelTrim = car.Model.Trim();
        if (modelTrim != car.Model)
        {
            car.Model = modelTrim;
            changed = true;
        }
        
        if (car.Model.Length > CarValidator.ModelMaxLength)
        {
            car.Model = car.Model.Substring(0, CarValidator.ModelMaxLength);
            changed = true;
        }

        // Проверка LicensePlate
        if (car.LicensePlate == null)
        {
            car.LicensePlate = "";
            changed = true;
        }
        
        var plateTrim = car.LicensePlate.Trim().ToUpper();
        if (plateTrim != car.LicensePlate)
        {
            car.LicensePlate = plateTrim;
            changed = true;
        }
        
        if (car.LicensePlate.Length > CarValidator.LicensePlateMaxLength)
        {
            car.LicensePlate = car.LicensePlate.Substring(0, CarValidator.LicensePlateMaxLength);
            changed = true;
        }

        // Проверка Year (если год некорректный, ставим текущий)
        if (car.Year < 2000 || car.Year > DateTime.Now.Year + 1)
        {
            car.Year = DateTime.Now.Year;
            changed = true;
        }

        // Проверка RentalPricePerDay (если цена <= 0, ставим 1000)
        if (car.RentalPricePerDay <= 0)
        {
            car.RentalPricePerDay = 1000;
            changed = true;
        }

        return changed;
    }
}